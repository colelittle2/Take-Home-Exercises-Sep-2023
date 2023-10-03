using System.Reflection;

namespace TrainSystem
{
    public class Engine
    {
        private bool _InService;
        public bool InService { 
            get => _InService; 
            set => InService = value;
        }
        public int _HorsePower;
        public int _Weight;


        public int HorsePower
        {
            get => _HorsePower;
            set
            {
                // Add code to check if InService
                if (! _InService)
                {
                    throw new Exception("Engine is not in service");
                }

                if (! Utilities.InHundreds(value))
                {
                    throw new Exception("Engine horsepower must be positive and non-zero");
                }
                /// Add code to validate value is > 0 and in 100 increments 
                _HorsePower = value;
            }
        }

       
        public string Model { get; private set; }
        public string SerialNumber { get; private set; }
        public int Weight
        {
            get => _Weight;
            set
            {

                if (!_InService)
                {
                    throw new Exception("Engine is not in service");
                }

                if (! Utilities.InHundreds(value))
                {
                    throw new Exception("Engine weight must be positive and non-zero");
                }
                // Add code to InService and if value is > 0 and in 100 increments
                _Weight = value;
            }
        }

        public Engine(string model, string serialNumber, int weight, int horsepower)
        {
            // Missing code to value model and serialNumber

            Model = model;
            SerialNumber = serialNumber;

            Weight = weight;
            HorsePower = horsepower;
            InService = true;
        }

    }

}