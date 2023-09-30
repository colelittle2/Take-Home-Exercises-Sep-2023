using System.Reflection;

namespace TrainSystem
{
    public class Engine
    {
        public int _HorsePower;
        public int _Weight;


        public int HorsePower
        {
            get => _HorsePower;
            set
            {
                // Add code to check if InService
                /// Add code to validate value is > 0 and in 100 increments 
                _HorsePower = value;
            }
        }

        public bool InService { get; set; }
        public string Model { get; private set; }
        public string SerialNumber { get; private set; }
        public int Weight
        {
            get => _Weight;
            set
            {
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

    public static class Utilities
    {
        public static bool InHundreds(int value)
        {
            return value % 100 == 0;
        }

        public static bool IsPostiveNonZero(int value)
        {
            return value > 0;
        }

    }
}