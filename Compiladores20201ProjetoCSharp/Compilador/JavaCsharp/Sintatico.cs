using System.Collections;

namespace Compiladores20201ProjetoCSharp.Compilador.JavaCsharp
{
    public class Sintatico : Constants
    {
        private Stack stack = new Stack();
        private Token currentToken;
        private Token previousToken;
        private Lexico scanner;
        private Semantico semanticAnalyser;

        public Sintatico()
        {
        }

        public void Parse(Lexico scanner, Semantico semanticAnalyser)
        {
            this.scanner = scanner;
            this.semanticAnalyser = semanticAnalyser;

            stack.Clear();
            stack.Push(0);

            currentToken = scanner.NextToken();

            while (!Step())
                ;
        }

        private bool Step()
        {
            if (currentToken == null)
            {
                int pos = 0;
                if (previousToken != null)
                    pos = previousToken.GetPosition() + previousToken.Lexeme.Length;

                currentToken = new Token(DOLLAR, "$", pos);
            }

            int token = currentToken.Id;
            int state = (int)stack.Peek();

            int[] cmd = PARSER_TABLE.[state, token - 1];

            switch (cmd[0])
            {
                case 0:
                    stack.Push(cmd[1]);
                    previousToken = currentToken;
                    currentToken = scanner.NextToken();
                    return false;

                case 1:
                    int[] prod = PRODUCTIONS.[cmd[1]];

                    for (int i = 0; i < prod[1]; i++)
                        stack.Pop();

                    int oldState = ((int)stack.Peek();
                    stack.Push(PARSER_TABLE.[oldState][prod[0] - 1][1]);
                    return false;

                case 2:
                    int action = FIRST_SEMANTIC_ACTION + cmd[1] - 1;
                    stack.Push(PARSER_TABLE.[state][action][1]);
                    semanticAnalyser.ExecuteAction(cmd[1], previousToken);
                    return false;

                case 3:
                    return true;

                case 5:
                    throw new SyntaticError(PARSER_ERROR[state], currentToken.GetPosition());
            }
            return false;
        }
    }
}