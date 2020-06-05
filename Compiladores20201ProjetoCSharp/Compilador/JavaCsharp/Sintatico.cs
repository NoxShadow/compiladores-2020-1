using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores20201ProjetoCSharp.Compilador.JavaCsharp
{
    public class Sintatico : Constants
    {

        private Stack stack = new Stack();

        private Token currentToken;

        private Token previousToken;

        private Lexico scanner;

        private Semantico semanticAnalyser;

        public void parse(Lexico scanner, Semantico semanticAnalyser)
        {
            this.scanner = this.scanner;
            this.semanticAnalyser = this.semanticAnalyser;
            this.stack.clear();
            this.stack.push(new Integer(0));
            this.currentToken = this.scanner.nextToken();
            while (!this.step())
            {

            }

        }

        private bool step()
        {
            if ((this.currentToken == null))
            {
                int pos = 0;
                if ((this.previousToken != null))
                {
                    pos = (this.previousToken.getPosition() + this.previousToken.getLexeme().length());
                }

                this.currentToken = new Token(DOLLAR, "$", pos);
            }

            int token = this.currentToken.getId();
            int state = ((Integer)(this.stack.peek())).intValue();
            int[] cmd = PARSER_TABLE[state][(token - 1)];
            switch (cmd[0])
            {
                case SHIFT:
                    this.stack.push(new Integer(cmd[1]));
                    this.previousToken = this.currentToken;
                    this.currentToken = this.scanner.nextToken();
                    return false;
                    break;
                case REDUCE:
                    int[] prod = PRODUCTIONS[cmd[1]];
                    for (int i = 0; (i < prod[1]); i++)
                    {
                        this.stack.pop();
                    }

                    int oldState = ((Integer)(this.stack.peek())).intValue();
                    this.stack.push(new Integer(PARSER_TABLE[oldState][(prod[0] - 1)][1]));
                    return false;
                    break;
                case ACTION:
                    int action = (FIRST_SEMANTIC_ACTION
                                + (cmd[1] - 1));
                    this.stack.push(new Integer(PARSER_TABLE[state][action][1]));
                    this.semanticAnalyser.executeAction(cmd[1], this.previousToken);
                    return false;
                    break;
                case ACCEPT:
                    return true;
                    break;
                case ERROR:
                    throw new SyntaticError(PARSER_ERROR[state], this.currentToken.getPosition());
                    break;
            }
            return false;
        }
    }
}
