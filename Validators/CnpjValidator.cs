using System.Linq;
using ValidadorDocumentos.Models;

namespace ValidadorDocumentos.Validators
{
    public class CnpjValidator : DocumentValidator
    {
        public override ValidationResult Validate(string input)
        {
            string cleanCnpj = CleanInput(input);
            if (cleanCnpj.Length != 14 || cleanCnpj.Distinct().Count() == 1)
            {
                return new ValidationResult
                {
                    IsValid = false,
                    DocumentType = "CNPJ",
                    Message = "CNPJ deve conter 14 dígitos e não pode ter todos os dígitos iguais."
                };
            }

            int[] peso1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] peso2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int sum = 0;
            for (int i = 0; i < 12; i++)
                sum += (cleanCnpj[i] - '0') * peso1[i];

            int firstDigit = sum % 11;
            firstDigit = firstDigit < 2 ? 0 : 11 - firstDigit;

            sum = 0;
            for (int i = 0; i < 13; i++)
                sum += (cleanCnpj[i] - '0') * peso2[i];

            int secondDigit = sum % 11;
            secondDigit = secondDigit < 2 ? 0 : 11 - secondDigit;

            bool isValid = cleanCnpj[12] - '0' == firstDigit && cleanCnpj[13] - '0' == secondDigit;

            return new ValidationResult
            {
                IsValid = isValid,
                DocumentType = "CNPJ",
                Message = isValid ? "CNPJ válido." : "CNPJ inválido."
            };
        }
    }
}
