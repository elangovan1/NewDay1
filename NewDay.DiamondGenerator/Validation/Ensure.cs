namespace NewDay.DiamondGenerator
{
    internal class Ensure
    {
        internal static void IsNullOrEmpty(string input, string name)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException($"{name} is invalid string.");
        }
        internal static void IsValidAlphaChar(char input, string name)
        {
            if (!char.IsLetter(input))
                throw new ArgumentException($"{name} is invalid char.");
        }
        internal static void IsEmpty(char input, string name)
        {
            if (!char.IsLetter(input))
                throw new ArgumentException($"{name} can not be empty");
        }

        internal static void IsItUpperCase(char input, string name)
        {
            if (!char.IsUpper(input))
                throw new ArgumentException($"{name} shoud be entered in upper case.");
        }

        internal static void IsLessThanZero(int length, string name)
        {
            if (length < 0) 
                throw new ArgumentOutOfRangeException($"{name} Length must be non-negative.");
        }
    }
}
