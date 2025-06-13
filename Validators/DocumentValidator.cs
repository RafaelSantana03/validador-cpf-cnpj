using System.Text.RegularExpressions;
using ValidadorDocumentos.Models;

namespace ValidadorDocumentos.Validators
{
    public abstract class DocumentValidator
    {
        public static string CleanInput(string input)
        {
            return Regex.Replace(input, "[^0-9]", "");
        }

        public abstract ValidationResult Validate(string input);
    }
}
