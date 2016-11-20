using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animation_Sequencing_Mockup
{
    public class Actions
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
        public string GlobalRating { get; set; }
        public Introduction Sequence1 { get; set; }
        public Solution Sequence2 { get; set; }
        public Conclusion Sequence3 { get; set; }
    }
}