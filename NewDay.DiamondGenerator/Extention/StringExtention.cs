namespace NewDay.DiamondGenerator.Extention
{
    public static class StringExtensions
    {
        private static readonly char _firstLetter = 'A';
        public static string FillPrefixWithSpaces(this string source, char prefix, int spacesNeeded)
        {
            Ensure.IsNullOrEmpty(source, nameof(source));
            Ensure.IsLessThanZero(spacesNeeded, nameof(spacesNeeded));

            if (spacesNeeded <= 0)
                return source;

            return new string(prefix, spacesNeeded) + source;
        }
        public static IEnumerable<char> GetCharsUpTo(this char letter)
        {
            for (char ch = _firstLetter; ch <= letter; ch++)
            {
                yield return ch;
            }
        }
    }
}
