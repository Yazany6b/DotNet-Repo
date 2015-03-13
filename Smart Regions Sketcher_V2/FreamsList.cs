using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart_Regions_Sketcher
{
    public class FreamsList : List<AnimationFream>
    {
        public ISketcher ActiveSketcher { get; set; }
        public void ReplaceSketcher(ISketcher oldSkechter, ISketcher newSketcher)
        {
            foreach (var item in this)
            {
                if (item.Sketcher == oldSkechter)
                    item.Sketcher = newSketcher;
            }
        }

        public int IndexOfSketcher(ISketcher sketcher)
        {
            int index = -1;
            foreach (var item in this)
            {
                index++;
                if (item.Sketcher == sketcher)
                    return index;
            }

            return -1;
        }
    }
}
