namespace Exceptions
{
    public static class HandlingExceptions
    {
        public static bool CatchArgumentOutOfRangeException1(int i, Func<int, bool> foo)
        {
            try
            {
                return foo(i);
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
        }

        public static string CatchArgumentOutOfRangeException2(int i, object o, string s, out string errorMessage)
        {
            errorMessage = null;

            try
            {
                return DoSomething(i, o, s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                errorMessage = e.Message;
                return "K139";
            }
        }

        public static string CatchArgumentNullException3(object o, Func<object, string> foo)
        {
            try
            {
                foo(o);
            }
            catch (ArgumentNullException)
            {
                return "P456";
            }

            return foo(o);
        }

        public static string CatchArgumentNullException4(int i, object o, string s, out string errorMessage)
        {
            errorMessage = null;
            try
            {
                DoSomething(i, o, s);
            }
            catch (ArgumentNullException e)
            {
                errorMessage = e.Message;
                return "A732";
            }

            return DoSomething(i, o, s);
        }

        public static int CatchArgumentException5(int[] integers, Func<int[], int> foo)
        {
            try
            {
                foo(integers);
            }
            catch (ArgumentException)
            {
                return 0;
            }

            return foo(integers);
        }

        public static string CatchArgumentException6(int i, object o, string s, out string errorMessage)
        {
            errorMessage = null;
            try
            {
                DoSomething(i, o, s);
            }
            catch (ArgumentException e)
            {
                errorMessage = e.Message;
                return "D948";
            }

            return DoSomething(i, o, s);
        }

        public static string CatchArgumentException7(int i, object o, string s, out string errorMessage)
        {
            errorMessage = null;
            try
            {
                DoSomething(i, o, s);
            }
            catch (ArgumentNullException a)
            {
                errorMessage = a.Message;
                return "W694";
            }
            catch (ArgumentOutOfRangeException b)
            {
                errorMessage = b.Message;
                return "Z029";
            }
            catch (ArgumentException e)
            {
                errorMessage = e.Message;
                return "J954";
            }

            return DoSomething(i, o, s);
        }

        public static string DoSomething(int i, object o, string s)
        {
            if (i < -10 || i > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(i), "i should be in [-10, 10] interval.");
            }

            if (o is null)
            {
                throw new ArgumentNullException(nameof(o), "o is null.");
            }

            if (s is null)
            {
                throw new ArgumentNullException(nameof(s), "s is null.");
            }

            if (s.Length == 0)
            {
                throw new ArgumentException("s string is empty.", nameof(s));
            }

            return $"{i}{o}{s}";
        }
    }
}


