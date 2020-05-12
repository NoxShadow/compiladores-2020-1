
namespace Compiladores20201ProjetoCSharp.Compilador
{
    public class LexicalError : AnalysisError
    {
        public LexicalError(string msg, int position) : base(msg, position)
        {

        }

        public LexicalError(string msg) : base(msg)
        {

        }
    }
}