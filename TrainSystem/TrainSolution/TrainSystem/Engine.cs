using System.Reflection;

namespace TrainSystem
{
	public class Engine
	{
		private int _horsePower;
		private int _weight;

		public Engine(string model, string serialNumber, int weight, int horsePower)
		{
			if (string.IsNullOrWhiteSpace(model) || string.IsNullOrWhiteSpace(serialNumber))
			{
				throw new ArgumentNullException();
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
					throw new InvalidOperationException("Invalid horsepower value.");
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
					throw new InvalidOperationException("Invalid weight value.");
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