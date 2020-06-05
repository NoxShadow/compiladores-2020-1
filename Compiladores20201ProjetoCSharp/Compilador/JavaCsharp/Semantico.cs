using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores20201ProjetoCSharp.Compilador.JavaCsharp
{
    public class Semantico : Constants
    {
        public void executeAction(int action, Token token)
        {
            System.out.println(("Ação #"
                            + (action + (", Token: " + token))));
        }
    }
}
