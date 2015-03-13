using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart_Regions_Sketcher
{
    public class AnimationFream
    {
        public ISketcher Sketcher { get;set;}
        public int WaitMs { get; set; }

        public AnimationFream(ISketcher sketcher)
        {
            Sketcher = sketcher;
        }

        public AnimationFream(ISketcher sketcher, int waitms)
        {
            Sketcher = sketcher;
            WaitMs = waitms;
        }
    }
}
