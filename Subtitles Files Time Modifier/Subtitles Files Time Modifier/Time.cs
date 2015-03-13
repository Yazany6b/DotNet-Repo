using System;
using System.Collections.Generic;
using System.Text;

namespace Subtitles_Files_Time_Modifier
{
    public class Time
    {
        private bool minus = false;

        public static Time Empty = new Time(0, 0, 0);

        public Time(int h, int m, int s) { Hours = h; Minutes = m; Seconds = s; }
        private Time(int h, int m, int s, bool min) { Hours = h; Minutes = m; Seconds = s; minus = min; }
        public Time(int h, int m, int s, int ms) { Hours = h; Minutes = m; Seconds = s; MilieSeconds = ms; }
        private Time(int h, int m, int s, int ms, bool min) { Hours = h; Minutes = m; Seconds = s; MilieSeconds = ms; minus = min; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public int MilieSeconds { get; set; }
        public bool Negative { get { return minus; } }


        public static Time FromString(string time)
        {
            try
            {
                string[] ts = time.Split(':');

                for (int i = 0; i < ts.Length; i++)
                    ts[i] = ts[i].Trim().Trim(':');

                if (ts[2].Length == 1)
                    ts[2] += "0";

                return new Time(int.Parse(ts[0]), int.Parse(ts[1]), int.Parse(ts[2]));
            }
            catch (NullReferenceException n)
            {
                return null;
            }
            catch(Exception e)
            {
                throw new FormatException("Wrong Time Format");
            }
        }

        public static Time FromSeconds(long seconds)
        {
            if (seconds == 0)
                return Empty;

            bool minus = false;

            if (seconds < 0)
            {
                minus = true;
                seconds *= -1;
            }

            int minutes = 0;
            int hours = 0;

            while (seconds > 59)
            {
                minutes++;

                while (minutes > 59)
                {
                    hours++;
                    minutes -= 60;
                }

                seconds -= 60;

            }

            return new Time(hours, minutes,(int) seconds ,0, minus);
        }

        public static Time FromMilieSeconds(long milieSeconds)
        {
            if (milieSeconds == 0)
                return Empty;

            bool minus = false;

            if (milieSeconds < 0)
            {
                minus = true;
                milieSeconds *= -1;
            }

            string ms = (milieSeconds / 1000).ToString();

            int extraMilies = 0;

            if (ms.Contains("."))
                extraMilies = int.Parse(ms.Substring(ms.IndexOf('.') + 1));

            long seconds = milieSeconds / 1000;
            int minutes = 0;
            int hours = 0;

            while (seconds > 59)
            {
                minutes++;

                while (minutes > 59)
                {
                    hours++;
                    minutes -= 60;
                }

                seconds -= 60;

            }

            return new Time(hours, minutes, (int)seconds, extraMilies,minus);
        }

        public long ToMilieSeconds()
        {
            return ( ((((Hours * 60) * 60) + (Minutes * 60) + Seconds) * 1000) + MilieSeconds) * (minus ? -1 : 1);
        }

        public long ToSeconds()
        {
            return (((Hours * 60) * 60) + (Minutes * 60) + Seconds) * (minus ? -1 : 1);
        }

        public long ToMinutes()
        {
            return ToSeconds() / 60;
        }

        public long ToHours()
        {
            return ToMinutes() / 60;
        }

        private void increaseMilieSeconds(int milieSeconds)
        {
            long ms = ToMilieSeconds() * (minus ? -1 : 1);

            ms += milieSeconds;

            if (ms < 0)
            {
                ms = 0;
            }

            Time time = Time.FromMilieSeconds(ms);

            Hours = time.Hours;
            Minutes = time.Minutes;
            Seconds = time.Seconds;
            MilieSeconds = time.MilieSeconds;
        }

        private void decreaseMilieSeconds(int milieSeconds)
        {
            long ms = ToMilieSeconds() * (minus ? -1 : 1);

            ms -= milieSeconds;

            if (ms < 0)
                ms = 0;

            Time time = Time.FromMilieSeconds(ms);

            Hours = time.Hours;
            Minutes = time.Minutes;
            Seconds = time.Seconds;
            MilieSeconds = time.MilieSeconds;
        }

        private void increaseSeconds(int seconds)
        {
            long sec = ToSeconds() * (minus ? -1 : 1);

            sec += seconds;

            if (sec < 0)
            {
                sec = 0;
            }

            Time time = Time.FromSeconds(sec);

            Hours = time.Hours;
            Minutes = time.Minutes;
            Seconds = time.Seconds;
        }

        private void decreaseSeconds(int seconds)
        {
            long sec = ToSeconds() * (minus ? -1 : 1);

            sec -= seconds;

            if (sec < 0)
                sec = 0;

            Time time = Time.FromSeconds(sec);

            Hours = time.Hours;
            Minutes = time.Minutes;
            Seconds = time.Seconds;
        }


        public void AddSeconds(int seconds)
        {
            if (seconds > 0)
                if (!minus)
                    increaseSeconds(seconds);
                else
                    decreaseSeconds(seconds);
            else
                if (seconds < 0)
                    if (!minus)
                        decreaseSeconds(seconds * -1);
                    else
                        increaseSeconds(seconds * -1);
        }

        public void AddMilieSeconds(int milieSeconds)
        {
            if (milieSeconds > 0)
                if (!minus)
                    increaseMilieSeconds(milieSeconds);
                else
                    decreaseMilieSeconds(milieSeconds);
            else
                if (milieSeconds < 0)
                    if (!minus)
                        decreaseMilieSeconds(milieSeconds * -1);
                    else
                        increaseMilieSeconds(milieSeconds * -1);
        }

        public static Time AddTime(Time time1 , Time time2)
        {
            return Time.FromMilieSeconds(time1.ToMilieSeconds() + time2.ToMilieSeconds());
        }

        public static Time SubtractTime(Time time1, Time time2)
        {
            return Time.FromMilieSeconds(time1.ToMilieSeconds() - time2.ToMilieSeconds());
        }

        public static Time MultiplayTime(Time time1, Time time2)
        {
            return Time.FromMilieSeconds(time1.ToMilieSeconds() * time2.ToMilieSeconds());
        }

        public static Time DivideTime(Time time1, Time time2)
        {
            try
            {
                return Time.FromMilieSeconds(time1.ToMilieSeconds() / time2.ToMilieSeconds());
            }
            catch { return Empty; }
        }

        public override string ToString()
        {
            return (minus ? "-" :"") + (Hours > 9 ? Hours + "" : "0" + Hours) + ":"
                + (Minutes > 9 ? Minutes + "" : "0" + Minutes) + ":"
                + (Seconds > 9 ? Seconds + "" : "0" + Seconds) + ","+MilieSeconds;
        }

        public override bool Equals(object obj)
        {
            if (obj is Time)
            {
                Time t = obj as Time;

                if (t.Hours == Hours && t.Seconds == Seconds && t.Minutes == Minutes && minus == t.Negative)
                    return true;
                else
                    return false;
            }

            return false;
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}
