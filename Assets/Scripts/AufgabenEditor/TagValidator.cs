class TagValidator
{
    private class Validator
    {
        public bool Validate(string tag)
        {
            if (tag == null || tag.Length == 0)
            {
                return false;
            }
            return true;
        }

        public bool Validate(string[] tags)
        {
            if (tags == null || tags.Length == 0)
            {
                return false;
            }
            foreach (string tag in tags)
            {
                if (!Validate(tag))
                {
                    return false;
                }
            }
            return true;
        }
    }

    private static readonly Validator instance = new Validator();

    public static bool Validate(string tag)
    {
        return instance.Validate(tag);
    }

    public static bool Validate(string[] tags)
    {
        return instance.Validate(tags);
    }
}