namespace NewDay.DiamondGenerator
{
    internal class Ensure
    {
        internal static void IsValidAlphaChar(char input)
        {
            if (!char.IsLetter(input))
                throw new ArgumentException($"{nameof(input)} is invalid char.");
        }
        internal static void IsEmpty(char input)
        {
            if (!char.IsLetter(input))
                throw new ArgumentException($"{nameof(input)} can not be empty");
        }

        internal static void IsItUpperCase(char input)
        {
            if (!char.IsUpper(input))
                throw new ArgumentException($"{nameof(input)} shoud be entered in upper case.");
        }
    }
}
