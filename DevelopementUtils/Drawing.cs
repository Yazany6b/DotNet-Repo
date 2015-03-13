using System;
using System.Collections.Generic;
using System.Text;

namespace Development.Utilities.Statics
{
    /// <summary>
    /// Conatines some operations may needed when dealing with drawing objects
    /// </summary>
    public static class Drawing
    {
        /// <summary>
        /// Create another deep copy of points list
        /// </summary>
        /// <param name="source">the source list of the points</param>
        /// <returns>a copy of the source list</returns>
        public static List<System.Drawing.Point> ClonePointsList(List<System.Drawing.Point> source)
        {
            List<System.Drawing.Point> destination = new List<System.Drawing.Point>();

            foreach (System.Drawing.Point x in source)
            {
                destination.Add(new System.Drawing.Point(x.X, x.Y));
            }

            return destination;
        }

        /// <summary>
        /// Create another deep copy of points array
        /// </summary>
        /// <param name="source">the source array of the points</param>
        /// <returns>a copy of the source list</returns>
        public static System.Drawing.Point [] ClonePointsArray(System.Drawing.Point [] source)
        {
            System.Drawing.Point[] destination = new System.Drawing.Point[source.Length];

            for (int i = 0; i < source.Length; i++)
                destination[i] = new System.Drawing.Point(source[i].X, source[i].Y);

            return destination;
        }
    }
}
