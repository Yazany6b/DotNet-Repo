using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Development.Utilities.Statics
{
    /// <summary>
    /// Containes a needed operations when dealing with collections an arrays
    /// </summary>
    public static class Collections
    {
        /// <summary>
        /// Remove duplicate from a list
        /// </summary>
        /// <typeparam name="T">The list values data type</typeparam>
        /// <param name="list">the list that containes values</param>
        /// <returns>a new list without duplication</returns>
        public static List<T> RemovedDuplicate<T>(List<T> list)
        {
            List<T> temp = new List<T>();
            for (int i = 0; i < list.Count; i++)
                if (!temp.Contains(list[i]))
                    temp.Add(list[i]);
            return temp;
        }

        /// <summary>
        /// Remove duplicate from a array
        /// </summary>
        /// <typeparam name="T">The array values data type</typeparam>
        /// <param name="list">the array that containes values</param>
        /// <returns>a new array without duplication</returns>
        public static T [] RemovedDuplicate<T>(T[] list)
        {
            List<T> temp = new List<T>();
            for (int i = 0; i < list.Length; i++)
                if (!temp.Contains(list[i]))
                    temp.Add(list[i]);
            return temp.ToArray();
        }

        /// <summary>
        /// cut a part of array 
        /// </summary>
        /// <typeparam name="T">The array values data type</typeparam>
        /// <param name="start"> start index</param>
        /// <param name="end">end index</param>
        /// <param name="array">An array of T data type to cut from</param>
        /// <returns>the cut array</returns>
        public static T[] Cut<T>(int start, int end, T[] array)
        {
            T[] arr = new T[(end - start) + 1];
            int index = 0;
            for (int i = start; i <= end; i++, index++)
            {
                arr[i - start] = array[i];
            }
            return arr;
        }

        /// <summary>
        /// Gets how many time a value has be repated in a list
        /// </summary>
        /// <typeparam name="T">The list values data types</typeparam>
        /// <param name="list">the list of values</param>
        /// <param name="value">the value to be search for</param>
        /// <returns>the number of the repations</returns>
        public static int NumberOfRepation<T>(List<T> list, T value)
        {
            int count = 0;
            for (int i = 0; i < list.Count; i++)
                if (list[i].Equals(value))
                    count++;
            return count;
        }

        /// <summary>
        /// Sort an array of values ascending
        /// </summary>
        /// <typeparam name="T">The values data type</typeparam>
        /// <param name="array">the array that containes the values</param>
        /// <returns>a new sorted array</returns>
        public static T[] SortAscending<T>(T[] array)
        {
            var sorter = from a in array orderby a ascending select a;
            return sorter.ToArray<T>();
        }

        /// <summary>
        /// Sort an array of values descending
        /// </summary>
        /// <typeparam name="T">The values data type</typeparam>
        /// <param name="array">the array that containes the values</param>
        /// <returns>a new sorted array</returns>
        public static T[] SortDescending<T>(T[] array)
        {
            var sorter = from a in array orderby a descending select a;
            return sorter.ToArray<T>();
        }

        
        /// <summary>
        /// convert a list of objects to a string object 
        /// </summary>
        /// <typeparam name="T">the type you want to convert from</typeparam>
        /// <param name="list">the list of values that you want to convert</param>
        /// <remarks>all list values will be separated by \n character in the string object </remarks>
        /// <returns>System.String a string object that containes the list</returns>
        public static string ToString<T>(System.Collections.Generic.List<T> list)
        {
            if (list.Count == 0)
                return "";
            string tem = "";
            for (int i = 0; i < list.Count; i++)
            {
                tem += list[i].ToString() + Environment.NewLine;
            }
            return tem;
        }

        /// <summary>
        /// convert a list of objects to a string object 
        /// </summary>
        /// <typeparam name="T">the values Data type </typeparam>
        /// <param name="list">the list of values that you want to convert</param>
        /// <remarks>all list values will be separated by \n character in the string object </remarks>
        /// <returns>System.String a string object that containes the list</returns>
        public static string ToString<T>(T[] list)
        {
            if (list.Length == 0)
                return "";
            string tem = "";
            for (int i = 0; i < list.Length; i++)
            {
                tem += list[i].ToString() + Environment.NewLine;
            }
            return tem;
        }


        /// <summary>
        /// convert a list of arrays to a string object 
        /// </summary>
        /// <typeparam name="T">the values Data type </typeparam>
        /// <param name="list">the list of values that you want to convert</param>
        /// <param name="serarator">the string to separate each array from the other in the parent list </param>
        /// <remarks>each array values will be separated by \n character in the string object </remarks>
        /// <returns>System.String a string object that containes the list</returns>
        public static string ToString<T>(List<T[]> list, string serarator = "----------------------------------")
        {
            string tem = "";
            for (int i = 0; i < list.Count; i++)
            {
                tem +=  serarator + Environment.NewLine;
                for (int ii = 0; ii < list[i].Length; ii++)
                {

                    tem += list[i][ii] + Environment.NewLine;

                }
                tem += serarator + Environment.NewLine;
            }
            return tem;
        }

        /// <summary>
        /// convert a list of lists to a string object 
        /// </summary>
        /// <typeparam name="T">the values Data type </typeparam>
        /// <param name="list">the list of values that you want to convert</param>
        /// <param name="serarator">the string to separate each sublist from the other in the parent list </param>
        /// <remarks>each sublist values will be separated by \n character in the string object </remarks>
        /// <returns>System.String a string object that containes the list</returns>
        public static string ToString<T>(List<List<T>> list, string serarator = "----------------------------------")
        {
            string tem = "";
            for (int i = 0; i < list.Count; i++)
            {
                tem += serarator + Environment.NewLine;
                for (int ii = 0; ii < list[i].Count; ii++)
                {

                    tem += list[i][ii] + Environment.NewLine;

                }
                tem += serarator + Environment.NewLine;
            }
            return tem;
        }


        /// <summary>
        /// convert a dictionary of objects to a string object 
        /// </summary>
        /// <typeparam name="K">the Key values data type </typeparam>
        /// <typeparam name="V">the Value values data type </typeparam>
        /// <param name="dic">the dictionary of keys-values that you want to convert</param>
        /// <param name="keyValueSeparator">the string to separate between each key and his value </param>
        /// <remarks>each dictionary key-value will be separated by \n character in the string object </remarks>
        /// <returns>System.String a string object that containes the list</returns>
        public static string ToString<K, V>(Dictionary<K, V> dic, string keyValueSeparator = "   -   ")
        {
            string tem = "";
            for (int i = 0; i < dic.Count; i++)
            {
                tem += dic.ElementAt(i).Key.ToString() + keyValueSeparator + dic.ElementAt(i).Value.ToString() + Environment.NewLine;
            }
            return tem;
        }
       
    }
}
