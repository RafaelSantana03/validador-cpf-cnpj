namespace ValidadorDocumentos.Models
{

    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public string DocumentType { get; set; } = string.Empty; // CPF or CNPJ
        public string Message { get; set; } = string.Empty; // Messagem para feedback ao usuário
    }
}