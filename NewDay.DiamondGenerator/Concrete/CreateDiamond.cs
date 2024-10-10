using System.Text;

namespace NewDay.DiamondGenerator
{
    public class CreateDiamond : IDesignGenerator
    {
        private readonly int _indexOfFirstLetter = 65;
        private readonly char _firstLetter = 'A';

        /// <summary>
        /// Given a character from the alphabet, print a diamond of its output with that character being the midpoint of the diamond.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<string> Create(char input)
        {
            Ensure.IsValidAphaChar(input);
            Ensure.IsEmpty(input);
            Ensure.IsItUpperCase(input);

            var result = await GetDiamondPart(input);

            return result;
        }

        /// <summary>
        /// Render diamond
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private async Task<string> GetDiamondPart(char input)
        {
            var diamond = new StringBuilder();
            int prefixSpaceCount = input - _indexOfFirstLetter;
                        
            var alphabet = Enumerable.Range(_firstLetter, Convert.ToInt16(input) % 32).Select(n => (char)n);

            var index = 0;
            foreach (var value in alphabet)
            {
                diamond.Append(await PrintRow(value, index++, prefixSpaceCount));
            }

            for (index = prefixSpaceCount - 1; index >= 0; index--)
            {
                diamond.Append(await PrintRow(alphabet.ElementAt(index), index, prefixSpaceCount));
            }
            return diamond.ToString();
        }

        /// <summary>
        /// Print letters on each row
        /// </summary>
        /// <param name="letter">Letter to be printed</param>
        /// <param name="index">Index of selected letter from List</param>
        /// <param name="prefixSpaceCount">value to give space in front of each line</param>
        /// <returns></returns>
        private async Task<string> PrintRow(char letter, int index, int prefixSpaceCount)
        {
            var diamond = new StringBuilder();
            diamond.Append(new string(' ', prefixSpaceCount - index));
            diamond.Append(letter);
            if (index > 0)
            {
                diamond.Append(new string(' ', 2 * index - 1));
                diamond.Append(letter);
            }

            diamond.AppendLine();

            return await Task.FromResult(diamond.ToString().TrimEnd());
        }
    }
}
