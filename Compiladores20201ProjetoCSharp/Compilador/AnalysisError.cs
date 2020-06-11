using System;

namespace Compiladores20201ProjetoCSharp.Compilador
{
    public class AnalysisError : Exception
    {
        public int Line { get; private set; }

        public AnalysisError(string msg, int line) : base(msg)
        {
            Line = line;
        }

        public AnalysisError(string msg) : base(msg)
        {
            Line = -1;
        }

        public override string ToString()
        {
            return base.ToString() + ", @ " + Line;
        }
    }
}