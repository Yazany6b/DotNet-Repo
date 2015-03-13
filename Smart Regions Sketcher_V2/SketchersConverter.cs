using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart_Regions_Sketcher
{
    public static class SketchersConverter
    {
        public static ISketcher ConvertFrom(ISketcher isketcher)
        {
            ISketcher sketcher = null;
            if (isketcher is LinesSketcher)
            {                
                sketcher = ConvertToPolygons(isketcher);   
            }
            else
            {
                sketcher = ConvertToLines(isketcher);
            }

            return sketcher;
        }

        public static LinesSketcher ConvertToLines(ISketcher polySketcher)
        {
            LinesSketcher sketcher = new LinesSketcher(polySketcher.Graphics);


            sketcher.SketchPoints = polySketcher.SketchPoints;
            sketcher.SketchColor = polySketcher.SketchColor;
            sketcher.UnSketchColor = polySketcher.UnSketchColor;

            return sketcher;
        }

        public static PolygonSketcher ConvertToPolygons(ISketcher lineSketcher)
        {
            PolygonSketcher sketcher = new PolygonSketcher(lineSketcher.Graphics);

            sketcher.SketchPoints = lineSketcher.SketchPoints;
            sketcher.SketchColor = lineSketcher.SketchColor;
            sketcher.UnSketchColor = lineSketcher.UnSketchColor;

            return sketcher;
        }

    }
}
