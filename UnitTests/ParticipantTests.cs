using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    [TestClass]
    public class ParticipantTests
    {
        [TestMethod]
        public void TestForCorrectInput() // tests if the created participant can be found
        {
            bool serialnumberfound = false;
            ParticipantController.AddParticipant(new Participant { ID = 1, FirstName = "Anders", LastName = "Pedersen", Email = "Anderskp11@hotmail.com", SerialNumberID = "2679-351E-54BB-4AF5" });
            ParticipantController.AddParticipant(new Participant { ID = 2, FirstName = "Anders1", LastName = "Pedersen1", Email = "Anderskp11@hotmail.com1", SerialNumberID = "2679-351E-54BB-4AF5" });
            ParticipantController.AddParticipant(new Participant { ID = 3, FirstName = "Anders2", LastName = "Pedersen2", Email = "Anderskp11@hotmail.com2", SerialNumberID = "2679-351E-54BB-4AF5" });


            List<Participant> participants = ParticipantController.GetParticipants();


            foreach (var participant in participants)
            {
                if (participant.FirstName == "Anders1" && participant.LastName == "Pedersen1" && participant.ID == 2 && participant.SerialNumberID == "2679-351E-54BB-4AF5") // Randomly selected Serialnumber
                {
                    serialnumberfound = true;
                }
            }

            Assert.AreEqual(true, serialnumberfound);
        }

        [TestMethod]

        public void TestparticipantsCounter() // tests that Participantcontroller can add and return lists and get proper count.
        {
            List<Participant> participants = ParticipantController.GetParticipants();
            Assert.AreEqual(3, participants.Count);
        }
   
       
    }
}

