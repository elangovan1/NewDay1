using NewDay.DiamondGenerator.Extention;
using System.Text;

namespace NewDay.DiamondGenerator
{
    public class CreateDiamond : IDesignGenerator
    {
        private readonly int _indexOfFirstLetter = 65;        
        private readonly char _emptyChar = ' ';

        /// <summary>
        /// Given a character from the alphabet, print a diamond of its output with that character being the midpoint of the diamond.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<string> Create(char input)
        {
            Ensure.IsValidAlphaChar(input, nameof(input));
            Ensure.IsEmpty(input, nameof(input));
            Ensure.IsItUpperCase(input, nameof(input));

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

            var alphabet = input.GetCharsUpTo();
                        
            var index = -1;

            //Get Top layer
            index = await GetUpperPartOfDiamond(diamond, prefixSpaceCount, alphabet, index);

            //Get bottom layer            
            index = await GetLowerPartOfDiamond(diamond, prefixSpaceCount, alphabet, index);

            return diamond.ToString();
        }

        /// <summary>
        /// Get Top layer
        /// </summary>
        /// <param name="diamond"></param>
        /// <param name="prefixSpaceCount"></param>
        /// <param name="alphabet"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private async Task<int> GetLowerPartOfDiamond(StringBuilder diamond, int prefixSpaceCount, IEnumerable<char> alphabet, int index)
        {
            foreach (var value in alphabet.Take(alphabet.Count() - 1).Reverse())
            {
                diamond.Append(await PrintRow(value, --index, prefixSpaceCount));
            }
            return index;
        }

        /// <summary>
        /// Get bottom layer     
        /// </summary>
        /// <param name="diamond"></param>
        /// <param name="prefixSpaceCount"></param>
        /// <param name="alphabet"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private async Task<int> GetUpperPartOfDiamond(StringBuilder diamond, int prefixSpaceCount, IEnumerable<char> alphabet, int index)
        {
            foreach (var value in alphabet)
            {
                diamond.Append(await PrintRow(value, ++index, prefixSpaceCount));
            }

            return index;
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
            diamond.Append(letter.ToString().FillPrefixWithSpaces(_emptyChar, prefixSpaceCount - index));
            if (index > 0)
            {                
                diamond.Append(letter.ToString().FillPrefixWithSpaces(_emptyChar, 2 * index - 1));
            }
            diamond.AppendLine();

            return await Task.FromResult(diamond.ToString().TrimEnd());
        }
    }
}
