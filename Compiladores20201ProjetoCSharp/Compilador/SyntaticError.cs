
namespace Compiladores20201ProjetoCSharp.Compilador
{
    public class SyntaticError : AnalysisError
    {
        public SyntaticError(string msg, int line) : base(msg, line)
        {

        }

        public SyntaticError(string msg) : base(msg)
        {

        }
    }
}