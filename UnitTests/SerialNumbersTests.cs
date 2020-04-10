using ClassLibrary;
using Homework4Umbraco;
using Homework4Umbraco.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace UnitTests
{
    [TestClass]
    public class SerialNumbersTest
    {
        [TestMethod]
       
        public void TesTCountOfSerialNumbers() // Insures that the 100 Serialnumbers from the .txt is loaded correctly.
        {
        
            string[] lines = File.ReadAllLines(@"SerialNumbers.txt"); //Loads Serialnumbers from .txt

            foreach (string line in lines)
            {                
                SerialNumberController.AddSerialNumber(new SerialNumber { SerialNumberID = line.ToString() });
            }


            List<SerialNumber> serialNumbers = SerialNumberController.GetSerialNumbers();


            Assert.AreEqual(100, serialNumbers.Count);
        }
        [TestMethod]
        public void TestForCorrectinput() // Check if a randomly chosen Serialnumber is in the list
        {
            bool serialnumberfound = false;
            string[] lines = File.ReadAllLines(@"SerialNumbers.txt"); //Loads Serialnumbers from .txt

            foreach (string line in lines)
            {
                SerialNumberController.AddSerialNumber(new SerialNumber { SerialNumberID = line.ToString() });
            }

            List<SerialNumber> serialNumbers = SerialNumberController.GetSerialNumbers();
            foreach (var serialnumber in serialNumbers)
            {
                if (serialnumber.SerialNumberID == "3766-8C11-BFA8-40EA") // Randomly selected Serialnumber
                {
                    serialnumberfound = true;
                }
            }


            Assert.AreEqual(true, serialnumberfound);

        }
    }
}
