using FluentAssertions;
using System.Diagnostics.Contracts;
using TrainSystem;

namespace UnitTestingEx2
{
	public class TrainSystemTests
	{
		/*
		  | Class item | Success/Fail | Specifications |
		| ---- | --------- | ------------------- |
		| Train  | Success | A train was successfully created with an engine.   |
		| Train  | Success | MaxGrossWeight calculates correctly.   |
		| Train  | Fail | There is no engine instance supplied. Use ArgumentNullExpection().   |
		| AddCar  | Success | Adds a rail car to the train. First_Car.  |
		| AddCar  | Success | Adds a rail car to the train. After_First_Car.  |
		| AddCar  | Fail | There is no railcar instance supplied. Use ArgumentNullExpection(). Message must contain `RailCar required`   |
		| AddCar  | Fail | Adding a rail car where serial number already exists on the train. Use ArgumentExpection(). Include serial number.|  
		| AddCar  | Fail | Adding a rail car exceeds the MaxGrossWeight limits. Use ArgumentExpection(). |  
		| DetachCar  | Success | Remaining cars are in the correct order.  | 
		| DetachCar  | Success | Returns the detached rail car. |  
		| DetachCar  | Fail | There is no railcar serial number supplied. Use ArgumentNullExpection(). Message must contain `SerialNumber required`| 
		| DetachCar  | Fail | Serial Number of car not found on train. Use ArgumentExpection(). Message must contain serial number. | 
		The Train should be able to hold a collection of RailCars. When the Train is created, ensure an empty collection is available to hold any added railcar.

### Train : Behaviours (methods)

`Add(RailCar car)` method:

- Ensure the supplied object is not `null`. If it is, throw an `ArgumentNullException` with proper values for the parameter name and the error message.
- Ensure there are no duplicate serial numbers in the train. If the supplied car's serial number already exists, throw an `ArgumentException` with a message of `"The railcar {car.SerialNumber} is already attached to the train"`.
- Add the railcar to the railcar collection if possible.

 `DetachCar(string SerialNumber)`. The method must remove the railcar that matches the supplied serial number from the train. 

- Ensure the supplied string is not `null`. If it is, throw an `ArgumentNullException` with proper values for the parameter name and the error message.
- Ensure the serial numbers is part of the train. If the supplied car's serial number does not exists, throw an `ArgumentException` with a message of `"The railcar {car.SerialNumber} is not attached to the train"`.
- Remove the railcar from the railcar collection if possible and return the detached railcar.

For example, assume the train's rail car serial numbers follow this order:

> "GATX 220455", "GATX 259314", "GATX 150687", "GATX 220587", "GATX 225963", "TILX 261848", "TILX 286721"

If the train is asked to detach the railcar serial number "GATX 225963", then the remaining list of cars would be the following:

> "GATX 220455", "GATX 259314", "GATX 150687", "GATX 220587", "TILX 261848", "TILX 286721"

		 */

		//railcar requires all parameters 
		//{SerialNumber},{LightWeight},{Capacity},{LoadLimit},{Type},{Inservice}
		[Fact]
		public void Create_A_Good_Train()
		{
			//Given - Arrange
			Engine engine = new Engine("CP 8002", "12345", 147000, 4400);
			//When - Act
			Train actual = new Train(engine);
			RailCar railCar = new RailCar("12345", 147000, 4400, 5500, 0);


			//Then - Assert
			actual.Engine.Should().Be(engine);
			
		}

		[Fact]
		public void Calculate_Max_Gross_Weight()
		{
			//Given - Arrange
			Engine engine = new Engine("CP 8002", "12345", 147000, 4400);
			//When - Act
			Train actual = new Train(engine);
			RailCar railCar = new RailCar("12345", 147000, 4400, 5500, 0);
			//Then - Assert
			actual.MaxGrossWeight.Should().Be(4400 * 1);
		}

		[Fact]
		public void Create_A_Train_With_No_Engine()
		{
			//Given - Arrange
			Engine engine = null;
			//When - Act
			Action actual = () => new Train(engine);
			RailCar railCar = new RailCar("12345", 147000, 4400, 5500, 0);
			//Then - Assert
			actual.Should().Throw<ArgumentNullException>("Engine cannot be null");
		}

		[Theory]
		[InlineData("12345")]
		public void Add_A_RailCar_To_The_Train_First_Car(string serialnumber)
		{//{SerialNumber},{LightWeight},{Capacity},{LoadLimit},{Type},{Inservice}
		 //Given - Arrange
			Engine engine = new Engine("CP 8002", "12345", 147000, 4400);
			Train train = new Train(engine);
			RailCar railCar = new RailCar("12345", 147000, 4400, 5500, 0);
			//When - Act
			train.AddRailCar(railCar);
			//Then - Assert
			train.RailCars.Should().Contain(railCar);
		}

		[Theory]
		[InlineData("12345")]
		public void Add_A_RailCar_To_The_Train_After_First_Car_With_Duplicate_Serial_Number(string serialnumber)
		{
			// Given - Arrange
			Engine engine = new Engine("CP 8002", "12345", 147000, 4400);
			Train train = new Train(engine);
			RailCar railCar = new RailCar("12345", 147000, 4400, 5500, 0);

			// When - Act
			train.AddRailCar(railCar); // Add the first rail car
			Action actual = () => train.AddRailCar(railCar); // Try to add a rail car with the same serial number

			// Then - Assert
			actual.Should().Throw<ArgumentException>().WithMessage("The railcar " + serialnumber + " is already attached to the train");
		}

		[Theory]
		[InlineData(null)]
		public void Add_A_RailCar_To_The_Train_With_No_RailCar(string serialnumber)
		{
			//Given - Arrange
			Engine engine = new Engine("CP 8002", "12345", 147000, 4400);
			Train train = new Train(engine);
			RailCar railCar = null;
			//When - Act
			Action actual = () => train.AddRailCar(railCar);
			//Then - Assert
			actual.Should().Throw<ArgumentNullException>("RailCar cannot be null");
		}
		//remove this
		[Fact]
		public void Add_A_RailCar_To_The_Train_With_Same_Serial_Number()
		{
			//Given - Arrange
			Engine engine = new Engine("CP 8002", "12345", 147000, 4400);
			Train train = new Train(engine);
			RailCar railCar = new RailCar("12345", 147000, 4400, 2000, 0);
			RailCar railCar2 = new RailCar("12345", 147000, 4400, 2000, 0);
			//When - Act
			train.AddRailCar(railCar);
			Action actual = () => train.AddRailCar(railCar2);
			//Then - Assert
			actual.Should().Throw<ArgumentException>().WithMessage("The railcar 12345 is already attached to the train");
		}

		[Fact]
		public void Add_A_RailCar_To_The_Train_With_Exceed_MaxGrossWeight()
		{
			//Given - Arrange
			Engine engine = new Engine("CP 8002", "12345", 147000, 4400);
			Train train = new Train(engine);
			RailCar railCar = new RailCar("12345", 147000, 5500, 5500, 0);
			//When - Act
			Action actual = () => train.AddRailCar(railCar);
			//Then - Assert
			actual.Should().Throw<ArgumentException>("The railcar 12345 exceeds the MaxGrossWeight");
		}

		/*[Theory]
		[InlineData("12345")]
		public void Detach_A_RailCar_From_The_Train_With_SerialNumber(string serialNumber)
		{
			// Given - Arrange
			Engine engine = new Engine("CP 8002", "12345", 147000, 5000);
			Train train = new Train(engine);
			RailCar railCar = new RailCar("12345", 147000, 4400, 5500, 0);
			RailCar railcar2 = new RailCar("12346", 147000, 4400, 5500, 0);

			// When - Act
			train.AddRailCar(railCar);
			train.AddRailCar(railcar2);
			Action action = () => train.DetachRailCar(serialNumber);
			

			// Then - Assert
			
		}*/

		[Fact]

		public void Detach_A_RailCar_From_The_Train_With_No_SerialNumber()
		{
			//Given - Arrange
			Engine engine = new Engine("CP 8002", "12345", 147000, 5000);
			Train train = new Train(engine);
			RailCar railCar = new RailCar("12345", 147000, 4400, 5500, 0);
			RailCar railcar2 = new RailCar("12346", 147000, 4400, 5500, 0);
			
			//When - Act
			Action actual = () => train.DetachRailCar(null);
			//Then - Assert
			actual.Should().Throw<ArgumentNullException>("SerialNumber cannot be null");
		}

		



	}
}
