using System.Reflection;

namespace TrainSystem
{
public class Engine
    {
        public int _HorsePower;
        public int _Weight;


        public int HorsePower { get; set; }
        public bool InService { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public int Weight { get; set; }

        public Engine(string model, string serialNumber, int weight, int horsepower)
        {
            Model = model;
            SerialNumber = serialNumber;
            Weight = weight;
            HorsePower = horsepower;
        }

    }

    public class Utilities
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