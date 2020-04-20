using System;

namespace Compiladores20201ProjetoCSharp.Compilador
{

    public class AnalysisError : Exception
    {
        public int Position { get; private set; }

        public AnalysisError(string msg, int position) : base(msg)
        {
            this.Position = position;
        }

        public AnalysisError(string msg) : base(msg)
        {
            Position = -1;
        }

        public override string ToString()
        {
            return base.ToString() + ", @ " + Position;
        }
    }
}
