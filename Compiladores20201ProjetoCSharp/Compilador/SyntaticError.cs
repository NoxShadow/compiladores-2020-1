namespace Compiladores20201ProjetoCSharp.Compilador
{
    public class SyntaticError : AnalysisError
    {
        public string Encontrado { get; set; }

        public SyntaticError(string encontrado, string msg, int line) : base(msg, line)
        {
        }

        public SyntaticError(string encontrado, string msg) : base(msg)
        {
        }
    }
}