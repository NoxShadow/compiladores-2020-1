
namespace Compiladores20201ProjetoCSharp.Compilador
{
    public class SemanticError : AnalysisError
    {
        public SemanticError(string msg, int line) : base(msg, line)
        {

        }

        public SemanticError(string msg) : base(msg)
        {

        }
    }
}