using System.Collections;
using System.Collections.Generic;

public class StringValidator
{
    private class Validator
    {
        public bool IsLongerThan(string str, int size)
        {
            return (str != null && str.Length > size);
        }
    }

    private static readonly Validator instance = new Validator();

    public static bool IsLongerThan(string str, int size)
    {
        return instance.IsLongerThan(str, size);
    }

    public static bool Validate(string str)
    {
        return instance.IsLongerThan(str, 0);
    }
}
