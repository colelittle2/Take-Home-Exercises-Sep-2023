using System.Reflection;

namespace TrainSystem
{
	public class Engine
	{
		private int _horsePower;
		private int _weight;

		public Engine(string model, string serialNumber, int weight, int horsePower)
		{
			if (string.IsNullOrWhiteSpace(model))
			{
				throw new ArgumentNullException("model cannot be null or whitespace");
			}

			if (string.IsNullOrWhiteSpace(serialNumber))
			{
				throw new ArgumentNullException("serial number cannot be null or whitespace");
			}

			if (weight <= 0 || horsePower <=0 )
			{
				throw new ArgumentException("value must be above zero");
			}

			Model = model;
			SerialNumber = serialNumber;
			Weight = weight;
			HorsePower = horsePower;
			InService = true;
		}

		public int HorsePower
		{
			get => _horsePower;
			set
			{
				if (InService)
				{
					throw new InvalidOperationException("Engine is not in service.");
				}

				if (!Utilities.InHundreds(value))
				{
					throw new ArgumentException("Invalid horsepower value.");
				}

				if(value < 3500 || value > 5500)
				{
					throw new ArgumentException("Invalid horsepower value.");
				}

				_horsePower = value;
			}
		}

	

		public int Weight
		{
			get => _weight;
			set
			{
				if (InService)
				{
					throw new InvalidOperationException("Engine is not in service.");
				}

				if (! Utilities.InHundreds(value))
				{
					throw new ArgumentException("Invalid weight value.");
				}
				
				if(value < 147000 || value > 148000)
				{
					throw new ArgumentException("Invalid weight value.");
				}

				_weight = value;
			}
		}

		public bool InService { get; set; }
		public string Model { get; set; }
		public string SerialNumber { get; set; }

		public override string ToString()
		{
			return $"{Model},{SerialNumber},{Weight},{HorsePower},{InService}";
		}
	}

}