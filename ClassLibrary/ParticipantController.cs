using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ParticipantController // Handle add and get list of participants

    {
        public static List<Participant> participants = new List<Participant>();

        public static void AddParticipant(Participant participant)
        {
            participants.Add(participant);
        }
        public static List<Participant> GetParticipants()
        {
            return participants;
        }
        public static void RemoveParticipant(Participant participant)
        {
            participants.Remove(participant);
         
        }
    }
}
