using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame.Models
{
    internal class PlayerStats
    {
        public string PlayerName { get; set; }
        public string DifficultyLevel { get; set; }
        public int Attempts { get; set; }
        public DateTime DatePlayed { get; set; }
    }
}
