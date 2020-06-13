namespace Compiladores20201ProjetoCSharp.Compilador
{
    public class LexicalError : AnalysisError
    {
        public LexicalError(string msg, int line) : base(msg, line)
        {
        }

        public LexicalError(string msg) : base(msg)
        {
        }
    }
}