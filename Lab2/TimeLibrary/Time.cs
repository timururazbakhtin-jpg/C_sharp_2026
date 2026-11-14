using System;

namespace TimeLibrary
{
    public class Time : ITime
    {
        private int _hours;
        private int _minutes;
        private int _seconds;

        public int Hours
        {
            get => _hours;
            set
            {
                if (value < 0 || value > 23)
                    throw new ArgumentOutOfRangeException(nameof(value), "Години: 0..23.");
                _hours = value;
            }
        }

        public int Minutes
        {
            get => _minutes;
            set
            {
                if (value < 0 || value > 59)
                    throw new ArgumentOutOfRangeException(nameof(value), "Хвилини: 0..59.");
                _minutes = value;
            }
        }

        public int Seconds
        {
            get => _seconds;
            set
            {
                if (value < 0 || value > 59)
                    throw new ArgumentOutOfRangeException(nameof(value), "Секунди: 0..59.");
                _seconds = value;
            }
        }


        public Time() : this(0, 0, 0) { }

        public Time(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public Time(Time other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            Hours = other.Hours;
            Minutes = other.Minutes;
            Seconds = other.Seconds;
        }

        public void Input()
        {
            Console.Write("Введіть години (0-23): ");
            Hours = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Введіть хвилини (0-59): ");
            Minutes = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Введіть секунди (0-59): ");
            Seconds = int.Parse(Console.ReadLine() ?? "0");
        }

        public override string ToString()
        {
            return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";
        }

        public static int operator -(Time t1, Time t2)
        {
            if (t1 is null || t2 is null)
                throw new ArgumentNullException("Об'єкти часу не можуть бути null.");

            return (int)t1 - (int)t2;
        }

        public static Time operator ++(Time t)
        {
            if (t is null)
                throw new ArgumentNullException(nameof(t));

            int nextSeconds = ((int)t + 1) % 86400;
            return new Time(nextSeconds / 3600, (nextSeconds % 3600) / 60, nextSeconds % 60);
        }

        public static Time operator --(Time t)
        {
            if (t is null)
                throw new ArgumentNullException(nameof(t));

            int prevSeconds = ((int)t - 1 + 86400) % 86400;
            return new Time(prevSeconds / 3600, (prevSeconds % 3600) / 60, prevSeconds % 60);
        }

        public static bool operator true(Time t)
        {
            return t is not null && (int)t > 0;
        }

        public static bool operator false(Time t)
        {
            return t is null || (int)t == 0;
        }

        public static implicit operator int(Time t)
        {
            if (t is null)
                throw new ArgumentNullException(nameof(t));

            return t.Hours * 3600 + t.Minutes * 60 + t.Seconds;
        }

        public static explicit operator Time(int totalSeconds)
        {
            if (totalSeconds < 0 || totalSeconds >= 86400)
                throw new ArgumentOutOfRangeException(nameof(totalSeconds), "Секунди: 0..86399.");

            return new Time(totalSeconds / 3600, (totalSeconds % 3600) / 60, totalSeconds % 60);
        }

 
        public static bool operator ==(Time? t1, Time? t2)
        {
            if (ReferenceEquals(t1, t2)) return true;
            if (t1 is null || t2 is null) return false;
            return (int)t1 == (int)t2;
        }

        public static bool operator !=(Time? t1, Time? t2)
        {
            return !(t1 == t2);
        }

        public static bool operator <(Time t1, Time t2)
        {
            return (int)t1 < (int)t2;
        }

        public static bool operator >(Time t1, Time t2)
        {
            return (int)t1 > (int)t2;
        }

        public static bool operator <=(Time t1, Time t2)
        {
            return (int)t1 <= (int)t2;
        }

        public static bool operator >=(Time t1, Time t2)
        {
            return (int)t1 >= (int)t2;
        }

        public override bool Equals(object? obj)
        {
            return obj is Time other && this == other;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Hours, Minutes, Seconds);
        }
    }
}