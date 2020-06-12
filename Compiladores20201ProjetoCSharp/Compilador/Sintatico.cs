using System;
using System.Collections;
using System.Linq;
using System.Runtime.InteropServices;

namespace Compiladores20201ProjetoCSharp.Compilador
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

            while (!Step());
        }

        private bool Step()
        {
            if (currentToken == null)
            {
                int pos = 0;
                if (previousToken != null)
                    pos = previousToken.Position + previousToken.Lexeme.Length;

                currentToken = new Token(DOLLAR, "$", 0, pos);
            }

            int token = currentToken.Id;
            int state = (int)stack.Peek();

            int[] cmd = PARSER_TABLE.GetMultyRow(state, token - 1);

            switch (cmd[0])
            {
                case 0:
                    stack.Push(cmd[1]);
                    previousToken = currentToken;
                    currentToken = scanner.NextToken();
                    return false;

                case 1:
                    int[] prod = PRODUCTIONS.GetRow(1);

                    if(stack.Count > 1)
                    {
                        for (int i = 0; i < prod[1]; i++)
                            stack.Pop();
                    }

                    int oldState = (int)stack.Peek();
                    stack.Push(PARSER_TABLE[oldState, prod[0] - 1, 1]);
                    return false;

                case 2:
                    int action = FIRST_SEMANTIC_ACTION + cmd[1] - 1;
                    stack.Push(PARSER_TABLE[state, action, 1]);
                    semanticAnalyser.ExecuteAction(cmd[1], previousToken);
                    return false;

                case 3:
                    return true;

                case 5:
                    throw new SyntaticError(PARSER_ERROR[state], currentToken.Line);
            }
            return false;
        }
    }

    static class ArrayExtension
    {

        public static T[] GetMultyRow<T>(this T[,,] array, int row1, int row2)
        {
            return Enumerable.Range(0, array.GetLength(2))
                .Select(x => array[row1, row2, x])
                .ToArray();
        }

        public static T[] GetRow<T>(this T[,] array, int row)
        {
            return Enumerable.Range(0, array.GetLength(1))
                .Select(x => array[row, x])
                .ToArray();
        }
    }
}