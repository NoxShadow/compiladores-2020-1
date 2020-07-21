using System.Collections;

namespace Compiladores20201ProjetoCSharp.Compilador
{
    public class Sintatico : Constants
    {
        private Stack stack = new Stack();
        private Token currentToken;
        private Token previousToken;
        private Lexico scanner;
        public Semantico semanticAnalyser;

        private static bool IsTerminal(int x)
        {
            return x < FIRST_NON_TERMINAL;
        }

        private static bool IsNonTerminal(int x)
        {
            return x >= FIRST_NON_TERMINAL && x < FIRST_SEMANTIC_ACTION;
        }

        private static bool IsSemanticAction(int x)
        {
            return x >= FIRST_SEMANTIC_ACTION;
        }

        private bool Step()
        {
            if (currentToken == null)
            {
                int pos = 0;
                if (previousToken != null)
                {
                    pos = previousToken.Position + previousToken.Lexeme.Length;
                }

                currentToken = new Token(DOLLAR, "$", 0, pos);
            }

            int x = (int)stack.Pop();
            int a = currentToken.Id;

            if (x == EPSILON)
            {
                return false;
            }
            else if (IsTerminal(x))
            {
                if (x == a)
                {
                    if (stack.Count == 0)
                    {
                        return true;
                    }
                    else
                    {
                        previousToken = currentToken;
                        currentToken = scanner.NextToken();
                        return false;
                    }
                }
                else
                {
                    return ThrowSemanticError(x, currentToken?.Lexeme, currentToken.Line);
                }
            }
            else if (IsNonTerminal(x))
            {
                if (PushProduction(x, a))
                {
                    return false;
                }
                else
                {
                    return ThrowSemanticError(x, currentToken?.Lexeme, currentToken.Line);
                }
            }
            else // isSemanticAction(x)
            {
                semanticAnalyser.ExecuteAction(x - FIRST_SEMANTIC_ACTION, previousToken);
                return false;
            }
        }

        private bool ThrowSemanticError(int errorIndex, string lexeme, int line)
        {
            if (lexeme == "$")
            {
                lexeme = "EOF";
            }

            throw new SemanticError(string.Format(PARSER_ERROR[errorIndex], lexeme ?? "\" \""), currentToken.Line);
        }

        private bool PushProduction(int topStack, int tokenInput)
        {
            int p = PARSER_TABLE[topStack - FIRST_NON_TERMINAL][tokenInput - 1];
            if (p >= 0)
            {
                int[] production = PRODUCTIONS[p];
                //empilha a produção em ordem reversa
                for (int i = production.Length - 1; i >= 0; i--)
                {
                    stack.Push(production[i]);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Parse(Lexico scanner, Semantico semanticAnalyser)
        {
            this.scanner = scanner;
            this.semanticAnalyser = semanticAnalyser;

            stack.Clear();
            stack.Push(DOLLAR);
            stack.Push(START_SYMBOL);

            currentToken = scanner.NextToken();

            while (!Step())
            {
                ;
            }
        }
    }
}