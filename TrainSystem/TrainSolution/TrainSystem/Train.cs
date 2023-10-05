using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem
{
	public class Train
	{
		/*A train is a set of railcars pulled by an engine. A train must have at least a single engine (this may change in the future). Railcars are added/detached to/from the train one-by-one. All mutators (`set`) properties must be `private`, while all accessors (`get`) are public; some properties only have an accessor, because they calculate their values based on the state of the train. You will need a greedy constructor for this data type.

- **Engine** - This is the engine for the train.
- **Maximum Gross Weight** - This is based upon the capacity of the engine. The "rule-of-thumb" that we will be following is that 1 HP can pull 1 Ton (a Ton is 2000 pounds). Thus, a 4400 HP engine can pull about 4400 Tons. Return the value in pounds.
- **Gross Weight** - This is the total gross weight of all the rail cars and the weight of the engine.
- **RailCars** - A collection of railcars.
- **TotalCars** - This is the total of railcars currently attached to the train.*/

		private Engine _engine;
		private int _maxGrossWeight;
		private int _grossWeight;
		private List<RailCar> _railCars;
		private int _totalCars;

		public Engine Engine
		{
			get
			{
				return _engine;
			}
			private set
			{
				if (value == null)
				{
					throw new ArgumentNullException("Engine cannot be null");
				}
				_engine = value;
			}
		}

		public int MaxGrossWeight
		{
			get
			{ //in the Train class the MaxGrossWeight is a computed property where you calculate and return the converted HorsePower of the Engine from Tons to pounds.
				_maxGrossWeight = Engine.HorsePower * 1;
				return _maxGrossWeight;
			}
			private set
			{
				if (!Utilities.IsPostiveNonZero(value))
				{
					throw new ArgumentException("over max grossweight");
				}
				_maxGrossWeight = value;
			}
		}

		public int GrossWeight
		{
			get
			{
				return _grossWeight;
			}
			private set
			{
				if (!Utilities.IsPostiveNonZero(value))
				{
					throw new ArgumentException("Gross Weight cannot be negative");
				}
				_grossWeight = value;
			}
		}

		public List<RailCar> RailCars
		{
			get
			{
				return _railCars;
			}
			private set
			{
				if (value == null)
				{
					throw new ArgumentNullException("Rail Cars cannot be null");
				}
				_railCars = value;
			}
		}

		public int TotalCars
		{
			get
			{

				return _totalCars;
			}
			private set
			{
				if (value <0)
				{
					throw new ArgumentNullException("Total Cars cannot be negative");
				}
				_totalCars = value;
			}
		}

		public Train(Engine engine)
		{
			Engine = engine;
			MaxGrossWeight = engine.HorsePower;
			GrossWeight = engine.Weight;
			RailCars = new List<RailCar>();
			TotalCars = 0;
		}

		public void AddRailCar(RailCar railCar)
		{
			if (RailCars.Any(existingCar => existingCar.SerialNumber == railCar.SerialNumber))
			{
				throw new ArgumentException("The railcar " + railCar.SerialNumber + " is already attached to the train");
			}
			else
			{
				RailCars.Add(railCar);
				GrossWeight += railCar.LightWeight;
				TotalCars++;
				
			}
		}

		public void DetachRailCar(RailCar railCar)
		{
			//check if serial number is null
			if (railCar == null)
			{
				throw new ArgumentNullException("Rail Car cannot be null");
			}
			RailCars.Remove(railCar);
			GrossWeight -= railCar.LightWeight;
			TotalCars--;
		}
	}
}
