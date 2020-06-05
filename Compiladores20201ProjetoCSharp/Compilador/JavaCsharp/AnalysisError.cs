using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores20201ProjetoCSharp.Compilador.JavaCsharp
{
    public class AnalysisError : Exception
    {

        private int position;

        public AnalysisError(String msg, int position) :
                base(msg)
        {
            this.position = this.position;
        }

        public AnalysisError(String msg) :
                base(msg)
        {
            this.position = -1;
        }

        public int getPosition()
        {
            return this.position;
        }

        public String ToString()
        {
            return (base.ToString() + (", @ " + this.position));
        }
    }
}
