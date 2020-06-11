using System;

namespace Compiladores20201ProjetoCSharp.Compilador.JavaCsharp
{
    public class Semantico : Constants
    {
        public void ExecuteAction(int action, Token token)
        {
            Console.WriteLine(("Ação #" + (action + (", Token: " + token))));
        }
    }
}