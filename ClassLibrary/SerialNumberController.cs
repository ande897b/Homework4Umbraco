using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
   public static class SerialNumberController
    {
       public static List<SerialNumber> SerialNumbers = new List<SerialNumber>();

        public static void AddSerialNumber(SerialNumber serialNumber)
        {
            SerialNumbers.Add(serialNumber);
        }
        public static List<SerialNumber> GetSerialNumbers()
        {
            return SerialNumbers;
        }
    }
}
