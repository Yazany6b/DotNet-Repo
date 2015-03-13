using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart_Regions_Sketcher
{
    public static class Utils
    {
        public static void ReplaceSketcher(List<ISketcher> sketchers , ISketcher oldSkechter, ISketcher newSketcher)
        {
            int index = sketchers.IndexOf(oldSkechter);
            if (index < 0)
                return;
            sketchers.RemoveAt(index);
            sketchers.Insert(index, newSketcher);
        }

        public static void UpdateFreamSketcher(List<AnimationFream> freams, ISketcher oldSkechter, ISketcher newSketcher)
        {
            foreach (var item in freams)
            {
                if (item.Sketcher == oldSkechter)
                    item.Sketcher = newSketcher;
            }
        }
    }
}
