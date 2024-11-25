namespace Portal
{
    public class Helper
    {
        public static T TakeInput<T>(T value)
        {
            if (!Config.CurrentEnv.Equals(Env.Dev))
            {
                if (typeof(T) == typeof(int))
                {
                    if (int.TryParse(Console.ReadLine(), out int result))
                    {
                        value = (T)(object)result;
                    }
                }
                if (typeof(T) == typeof(string))
                {
                    value = (T)(object)Console.ReadLine();
                }

            }
            return value;
        }
    }
}
