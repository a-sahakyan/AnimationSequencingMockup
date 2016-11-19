using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animation_Sequencing_Mockup
{
   public class Actions : Color
    {
        public int Id { get; set; }
        public string[] Style { get; set; }
        public string Type { get; set; } 
        public double TotalTime { get; set; } 
        public string[] TargetAudience { get; set; }
        public string[] Purpose { get; set; }
        public string[] VoiceOver { get; set; }
        public Color ColorScheme { get; set; }
        public string[] MusicVFX { get; set; }
        public int GlobalRating { get; set; }
    }
}
