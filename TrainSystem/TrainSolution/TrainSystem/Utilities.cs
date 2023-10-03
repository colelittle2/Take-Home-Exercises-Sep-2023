using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem
{
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
