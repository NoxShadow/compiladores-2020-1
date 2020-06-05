using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores20201ProjetoCSharp.Compilador.JavaCsharp
{
    public class SemanticError : AnalysisError
    {

        public SemanticError(String msg, int position) :
                base(msg, position)
        {
            base.(msg, position);
        }

        public SemanticError(String msg) :
                base(msg)
        {
            base.(msg);
        }
    }
}
