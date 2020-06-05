using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores20201ProjetoCSharp.Compilador.JavaCsharp
{
    public class Lexico : Constants
    {

        private int position;

        private String input;

        public Lexico() :
                this(new java.io.StringReader(""))
        {
            this.(new java.io.StringReader(""));
        }

        public Lexico(java.io.Reader input)
        {
            this.setInput(this.input);
        }

        public void setInput(java.io.Reader input)
        {
            StringBuffer bfr = new StringBuffer();
            try
            {
                int c = this.input.read();
                while ((c != -1))
                {
                    bfr.append(((char)(c)));
                    c = this.input.read();
                }

                this.input = bfr.toString();
            }
            catch (java.io.IOException e)
            {
                e.printStackTrace();
            }

            this.setPosition(0);
        }

        public void setPosition(int pos)
        {
            this.position = pos;
        }

        public Token nextToken()
        {
            if (!this.hasInput())
            {
                return null;
            }

            int start = this.position;
            int state = 0;
            int lastState = 0;
            int endState = -1;
            int end = -1;
            while (this.hasInput())
            {
                lastState = state;
                state = this.nextState(this.nextChar(), state);
                if ((state < 0))
                {
                    break;
                }
                else if ((this.tokenForState(state) >= 0))
                {
                    endState = state;
                    end = this.position;
                }

            }

            if (((endState < 0)
                        || ((endState != state)
                        && (this.tokenForState(lastState) == -2))))
            {
                throw new LexicalError(SCANNER_ERROR[lastState], start);
            }

            this.position = end;
            int token = this.tokenForState(endState);
            if ((token == 0))
            {
                return this.nextToken();
            }
            else
            {
                String lexeme = this.input.substring(start, end);
                token = this.lookupToken(token, lexeme);
                return new Token(token, lexeme, start);
            }

        }

        private int nextState(char c, int state)
        {
            switch (state)
            {
                case 0:
                    switch (c)
                    {
                        case 9:
                            return 1;
                            break;
                        case 10:
                            return 1;
                            break;
                        case 32:
                            return 1;
                            break;
                        case 33:
                            return 2;
                            break;
                        case 34:
                            return 3;
                            break;
                        case 35:
                            return 4;
                            break;
                        case 38:
                            return 5;
                            break;
                        case 40:
                            return 6;
                            break;
                        case 41:
                            return 7;
                            break;
                        case 42:
                            return 8;
                            break;
                        case 43:
                            return 9;
                            break;
                        case 44:
                            return 10;
                            break;
                        case 45:
                            return 11;
                            break;
                        case 46:
                            return 12;
                            break;
                        case 47:
                            return 13;
                            break;
                        case 48:
                            return 14;
                            break;
                        case 49:
                            return 15;
                            break;
                        case 50:
                            return 15;
                            break;
                        case 51:
                            return 15;
                            break;
                        case 52:
                            return 15;
                            break;
                        case 53:
                            return 15;
                            break;
                        case 54:
                            return 15;
                            break;
                        case 55:
                            return 15;
                            break;
                        case 56:
                            return 15;
                            break;
                        case 57:
                            return 15;
                            break;
                        case 58:
                            return 16;
                            break;
                        case 59:
                            return 17;
                            break;
                        case 60:
                            return 18;
                            break;
                        case 61:
                            return 19;
                            break;
                        case 62:
                            return 20;
                            break;
                        case 65:
                            return 21;
                            break;
                        case 66:
                            return 21;
                            break;
                        case 67:
                            return 21;
                            break;
                        case 68:
                            return 21;
                            break;
                        case 69:
                            return 21;
                            break;
                        case 70:
                            return 21;
                            break;
                        case 71:
                            return 21;
                            break;
                        case 72:
                            return 21;
                            break;
                        case 73:
                            return 21;
                            break;
                        case 74:
                            return 21;
                            break;
                        case 75:
                            return 21;
                            break;
                        case 76:
                            return 21;
                            break;
                        case 77:
                            return 21;
                            break;
                        case 78:
                            return 21;
                            break;
                        case 79:
                            return 21;
                            break;
                        case 80:
                            return 21;
                            break;
                        case 81:
                            return 21;
                            break;
                        case 82:
                            return 21;
                            break;
                        case 83:
                            return 21;
                            break;
                        case 84:
                            return 21;
                            break;
                        case 85:
                            return 21;
                            break;
                        case 86:
                            return 21;
                            break;
                        case 87:
                            return 21;
                            break;
                        case 88:
                            return 21;
                            break;
                        case 89:
                            return 21;
                            break;
                        case 90:
                            return 21;
                            break;
                        case 97:
                            return 21;
                            break;
                        case 98:
                            return 21;
                            break;
                        case 99:
                            return 21;
                            break;
                        case 100:
                            return 21;
                            break;
                        case 101:
                            return 21;
                            break;
                        case 102:
                            return 21;
                            break;
                        case 103:
                            return 21;
                            break;
                        case 104:
                            return 21;
                            break;
                        case 105:
                            return 21;
                            break;
                        case 106:
                            return 21;
                            break;
                        case 107:
                            return 21;
                            break;
                        case 108:
                            return 21;
                            break;
                        case 109:
                            return 21;
                            break;
                        case 110:
                            return 21;
                            break;
                        case 111:
                            return 21;
                            break;
                        case 112:
                            return 21;
                            break;
                        case 113:
                            return 21;
                            break;
                        case 114:
                            return 21;
                            break;
                        case 115:
                            return 21;
                            break;
                        case 116:
                            return 21;
                            break;
                        case 117:
                            return 21;
                            break;
                        case 118:
                            return 21;
                            break;
                        case 119:
                            return 21;
                            break;
                        case 120:
                            return 21;
                            break;
                        case 121:
                            return 21;
                            break;
                        case 122:
                            return 21;
                            break;
                        case 124:
                            return 22;
                            break;
                        default:
                            return -1;
                            break;
                    }
                    break;
                case 2:
                    switch (c)
                    {
                        case 61:
                            return 23;
                            break;
                        default:
                            return -1;
                            break;
                    }
                    break;
                case 3:
                    switch (c)
                    {
                        case 9:
                            return 3;
                            break;
                        case 13:
                            return 3;
                            break;
                        case 32:
                            return 3;
                            break;
                        case 33:
                            return 3;
                            break;
                        case 34:
                            return 24;
                            break;
                        case 35:
                            return 3;
                            break;
                        case 36:
                            return 3;
                            break;
                        case 37:
                            return 3;
                            break;
                        case 38:
                            return 3;
                            break;
                        case 39:
                            return 3;
                            break;
                        case 40:
                            return 3;
                            break;
                        case 41:
                            return 3;
                            break;
                        case 42:
                            return 3;
                            break;
                        case 43:
                            return 3;
                            break;
                        case 44:
                            return 3;
                            break;
                        case 45:
                            return 3;
                            break;
                        case 46:
                            return 3;
                            break;
                        case 47:
                            return 3;
                            break;
                        case 48:
                            return 3;
                            break;
                        case 49:
                            return 3;
                            break;
                        case 50:
                            return 3;
                            break;
                        case 51:
                            return 3;
                            break;
                        case 52:
                            return 3;
                            break;
                        case 53:
                            return 3;
                            break;
                        case 54:
                            return 3;
                            break;
                        case 55:
                            return 3;
                            break;
                        case 56:
                            return 3;
                            break;
                        case 57:
                            return 3;
                            break;
                        case 58:
                            return 3;
                            break;
                        case 59:
                            return 3;
                            break;
                        case 60:
                            return 3;
                            break;
                        case 61:
                            return 3;
                            break;
                        case 62:
                            return 3;
                            break;
                        case 63:
                            return 3;
                            break;
                        case 64:
                            return 3;
                            break;
                        case 65:
                            return 3;
                            break;
                        case 66:
                            return 3;
                            break;
                        case 67:
                            return 3;
                            break;
                        case 68:
                            return 3;
                            break;
                        case 69:
                            return 3;
                            break;
                        case 70:
                            return 3;
                            break;
                        case 71:
                            return 3;
                            break;
                        case 72:
                            return 3;
                            break;
                        case 73:
                            return 3;
                            break;
                        case 74:
                            return 3;
                            break;
                        case 75:
                            return 3;
                            break;
                        case 76:
                            return 3;
                            break;
                        case 77:
                            return 3;
                            break;
                        case 78:
                            return 3;
                            break;
                        case 79:
                            return 3;
                            break;
                        case 80:
                            return 3;
                            break;
                        case 81:
                            return 3;
                            break;
                        case 82:
                            return 3;
                            break;
                        case 83:
                            return 3;
                            break;
                        case 84:
                            return 3;
                            break;
                        case 85:
                            return 3;
                            break;
                        case 86:
                            return 3;
                            break;
                        case 87:
                            return 3;
                            break;
                        case 88:
                            return 3;
                            break;
                        case 89:
                            return 3;
                            break;
                        case 90:
                            return 3;
                            break;
                        case 91:
                            return 3;
                            break;
                        case 93:
                            return 3;
                            break;
                        case 94:
                            return 3;
                            break;
                        case 95:
                            return 3;
                            break;
                        case 96:
                            return 3;
                            break;
                        case 97:
                            return 3;
                            break;
                        case 98:
                            return 3;
                            break;
                        case 99:
                            return 3;
                            break;
                        case 100:
                            return 3;
                            break;
                        case 101:
                            return 3;
                            break;
                        case 102:
                            return 3;
                            break;
                        case 103:
                            return 3;
                            break;
                        case 104:
                            return 3;
                            break;
                        case 105:
                            return 3;
                            break;
                        case 106:
                            return 3;
                            break;
                        case 107:
                            return 3;
                            break;
                        case 108:
                            return 3;
                            break;
                        case 109:
                            return 3;
                            break;
                        case 110:
                            return 3;
                            break;
                        case 111:
                            return 3;
                            break;
                        case 112:
                            return 3;
                            break;
                        case 113:
                            return 3;
                            break;
                        case 114:
                            return 3;
                            break;
                        case 115:
                            return 3;
                            break;
                        case 116:
                            return 3;
                            break;
                        case 117:
                            return 3;
                            break;
                        case 118:
                            return 3;
                            break;
                        case 119:
                            return 3;
                            break;
                        case 120:
                            return 3;
                            break;
                        case 121:
                            return 3;
                            break;
                        case 122:
                            return 3;
                            break;
                        case 123:
                            return 3;
                            break;
                        case 124:
                            return 3;
                            break;
                        case 125:
                            return 3;
                            break;
                        case 126:
                            return 3;
                            break;
                        case 161:
                            return 3;
                            break;
                        case 162:
                            return 3;
                            break;
                        case 163:
                            return 3;
                            break;
                        case 164:
                            return 3;
                            break;
                        case 165:
                            return 3;
                            break;
                        case 166:
                            return 3;
                            break;
                        case 167:
                            return 3;
                            break;
                        case 168:
                            return 3;
                            break;
                        case 169:
                            return 3;
                            break;
                        case 170:
                            return 3;
                            break;
                        case 171:
                            return 3;
                            break;
                        case 172:
                            return 3;
                            break;
                        case 173:
                            return 3;
                            break;
                        case 174:
                            return 3;
                            break;
                        case 175:
                            return 3;
                            break;
                        case 176:
                            return 3;
                            break;
                        case 177:
                            return 3;
                            break;
                        case 178:
                            return 3;
                            break;
                        case 179:
                            return 3;
                            break;
                        case 180:
                            return 3;
                            break;
                        case 181:
                            return 3;
                            break;
                        case 182:
                            return 3;
                            break;
                        case 183:
                            return 3;
                            break;
                        case 184:
                            return 3;
                            break;
                        case 185:
                            return 3;
                            break;
                        case 186:
                            return 3;
                            break;
                        case 187:
                            return 3;
                            break;
                        case 188:
                            return 3;
                            break;
                        case 189:
                            return 3;
                            break;
                        case 190:
                            return 3;
                            break;
                        case 191:
                            return 3;
                            break;
                        case 192:
                            return 3;
                            break;
                        case 193:
                            return 3;
                            break;
                        case 194:
                            return 3;
                            break;
                        case 195:
                            return 3;
                            break;
                        case 196:
                            return 3;
                            break;
                        case 197:
                            return 3;
                            break;
                        case 198:
                            return 3;
                            break;
                        case 199:
                            return 3;
                            break;
                        case 200:
                            return 3;
                            break;
                        case 201:
                            return 3;
                            break;
                        case 202:
                            return 3;
                            break;
                        case 203:
                            return 3;
                            break;
                        case 204:
                            return 3;
                            break;
                        case 205:
                            return 3;
                            break;
                        case 206:
                            return 3;
                            break;
                        case 207:
                            return 3;
                            break;
                        case 208:
                            return 3;
                            break;
                        case 209:
                            return 3;
                            break;
                        case 210:
                            return 3;
                            break;
                        case 211:
                            return 3;
                            break;
                        case 212:
                            return 3;
                            break;
                        case 213:
                            return 3;
                            break;
                        case 214:
                            return 3;
                            break;
                        case 215:
                            return 3;
                            break;
                        case 216:
                            return 3;
                            break;
                        case 217:
                            return 3;
                            break;
                        case 218:
                            return 3;
                            break;
                        case 219:
                            return 3;
                            break;
                        case 220:
                            return 3;
                            break;
                        case 221:
                            return 3;
                            break;
                        case 222:
                            return 3;
                            break;
                        case 223:
                            return 3;
                            break;
                        case 224:
                            return 3;
                            break;
                        case 225:
                            return 3;
                            break;
                        case 226:
                            return 3;
                            break;
                        case 227:
                            return 3;
                            break;
                        case 228:
                            return 3;
                            break;
                        case 229:
                            return 3;
                            break;
                        case 230:
                            return 3;
                            break;
                        case 231:
                            return 3;
                            break;
                        case 232:
                            return 3;
                            break;
                        case 233:
                            return 3;
                            break;
                        case 234:
                            return 3;
                            break;
                        case 235:
                            return 3;
                            break;
                        case 236:
                            return 3;
                            break;
                        case 237:
                            return 3;
                            break;
                        case 238:
                            return 3;
                            break;
                        case 239:
                            return 3;
                            break;
                        case 240:
                            return 3;
                            break;
                        case 241:
                            return 3;
                            break;
                        case 242:
                            return 3;
                            break;
                        case 243:
                            return 3;
                            break;
                        case 244:
                            return 3;
                            break;
                        case 245:
                            return 3;
                            break;
                        case 246:
                            return 3;
                            break;
                        case 247:
                            return 3;
                            break;
                        case 248:
                            return 3;
                            break;
                        case 249:
                            return 3;
                            break;
                        case 250:
                            return 3;
                            break;
                        case 251:
                            return 3;
                            break;
                        case 252:
                            return 3;
                            break;
                        case 253:
                            return 3;
                            break;
                        case 254:
                            return 3;
                            break;
                        case 255:
                            return 3;
                            break;
                        default:
                            return -1;
                            break;
                    }
                    break;
                case 4:
                    switch (c)
                    {
                        case 66:
                            return 25;
                            break;
                        case 88:
                            return 26;
                            break;
                        case 98:
                            return 25;
                            break;
                        case 120:
                            return 26;
                            break;
                        default:
                            return -1;
                            break;
                    }
                    break;
                case 9:
                    switch (c)
                    {
                        case 61:
                            return 27;
                            break;
                        default:
                            return -1;
                            break;
                    }
                    break;
                case 11:
                    switch (c)
                    {
                        case 42:
                            return 28;
                            break;
                        case 45:
                            return 29;
                            break;
                        case 61:
                            return 30;
                            break;
                        default:
                            return -1;
                            break;
                    }
                    break;
                case 14:
                    switch (c)
                    {
                        case 46:
                            return 31;
                            break;
                        default:
                            return -1;
                            break;
                    }
                    break;
                case 15:
                    switch (c)
                    {
                        case 46:
                            return 31;
                            break;
                        case 48:
                            return 15;
                            break;
                        case 49:
                            return 15;
                            break;
                        case 50:
                            return 15;
                            break;
                        case 51:
                            return 15;
                            break;
                        case 52:
                            return 15;
                            break;
                        case 53:
                            return 15;
                            break;
                        case 54:
                            return 15;
                            break;
                        case 55:
                            return 15;
                            break;
                        case 56:
                            return 15;
                            break;
                        case 57:
                            return 15;
                            break;
                        default:
                            return -1;
                            break;
                    }
                    break;
                case 19:
                    switch (c)
                    {
                        case 61:
                            return 32;
                            break;
                        default:
                            return -1;
                            break;
                    }
                    break;
                case 21:
                    switch (c)
                    {
                        case 48:
                            return 33;
                            break;
                        case 49:
                            return 33;
                            break;
                        case 50:
                            return 33;
                            break;
                        case 51:
                            return 33;
                            break;
                        case 52:
                            return 33;
                            break;
                        case 53:
                            return 33;
                            break;
                        case 54:
                            return 33;
                            break;
                        case 55:
                            return 33;
                            break;
                        case 56:
                            return 33;
                            break;
                        case 57:
                            return 33;
                            break;
                        case 65:
                            return 33;
                            break;
                        case 66:
                            return 33;
                            break;
                        case 67:
                            return 33;
                            break;
                        case 68:
                            return 33;
                            break;
                        case 69:
                            return 33;
                            break;
                        case 70:
                            return 33;
                            break;
                        case 71:
                            return 33;
                            break;
                        case 72:
                            return 33;
                            break;
                        case 73:
                            return 33;
                            break;
                        case 74:
                            return 33;
                            break;
                        case 75:
                            return 33;
                            break;
                        case 76:
                            return 33;
                            break;
                        case 77:
                            return 33;
                            break;
                        case 78:
                            return 33;
                            break;
                        case 79:
                            return 33;
                            break;
                        case 80:
                            return 33;
                            break;
                        case 81:
                            return 33;
                            break;
                        case 82:
                            return 33;
                            break;
                        case 83:
                            return 33;
                            break;
                        case 84:
                            return 33;
                            break;
                        case 85:
                            return 33;
                            break;
                        case 86:
                            return 33;
                            break;
                        case 87:
                            return 33;
                            break;
                        case 88:
                            return 33;
                            break;
                        case 89:
                            return 33;
                            break;
                        case 90:
                            return 33;
                            break;
                        case 95:
                            return 34;
                            break;
                        case 97:
                            return 33;
                            break;
                        case 98:
                            return 33;
                            break;
                        case 99:
                            return 33;
                            break;
                        case 100:
                            return 33;
                            break;
                        case 101:
                            return 33;
                            break;
                        case 102:
                            return 33;
                            break;
                        case 103:
                            return 33;
                            break;
                        case 104:
                            return 33;
                            break;
                        case 105:
                            return 33;
                            break;
                        case 106:
                            return 33;
                            break;
                        case 107:
                            return 33;
                            break;
                        case 108:
                            return 33;
                            break;
                        case 109:
                            return 33;
                            break;
                        case 110:
                            return 33;
                            break;
                        case 111:
                            return 33;
                            break;
                        case 112:
                            return 33;
                            break;
                        case 113:
                            return 33;
                            break;
                        case 114:
                            return 33;
                            break;
                        case 115:
                            return 33;
                            break;
                        case 116:
                            return 33;
                            break;
                        case 117:
                            return 33;
                            break;
                        case 118:
                            return 33;
                            break;
                        case 119:
                            return 33;
                            break;
                        case 120:
                            return 33;
                            break;
                        case 121:
                            return 33;
                            break;
                        case 122:
                            return 33;
                            break;
                        default:
                            return -1;
                            break;
                    }
                    break;
                case 25:
                    switch (c)
                    {
                        case 48:
                            return 35;
                            break;
                        case 49:
                            return 35;
                            break;
                        default:
                            return -1;
                            break;
                    }
                    break;
                case 26:
                    switch (c)
                    {
                        case 48:
                            return 36;
                            break;
                        case 49:
                            return 36;
                            break;
                        case 50:
                            return 36;
                            break;
                        case 51:
                            return 36;
                            break;
                        case 52:
                            return 36;
                            break;
                        case 53:
                            return 36;
                            break;
                        case 54:
                            return 36;
                            break;
                        case 55:
                            return 36;
                            break;
                        case 56:
                            return 36;
                            break;
                        case 57:
                            return 36;
                            break;
                        case 97:
                            return 36;
                            break;
                        case 98:
                            return 36;
                            break;
                        case 99:
                            return 36;
                            break;
                        case 100:
                            return 36;
                            break;
                        case 101:
                            return 36;
                            break;
                        case 102:
                            return 36;
                            break;
                        default:
                            return -1;
                            break;
                    }
                    break;
                case 28:
                    switch (c)
                    {
                        case 9:
                            return 28;
                            break;
                        case 10:
                            return 28;
                            break;
                        case 13:
                            return 28;
                            break;
                        case 32:
                            return 28;
                            break;
                        case 33:
                            return 28;
                            break;
                        case 34:
                            return 28;
                            break;
                        case 35:
                            return 28;
                            break;
                        case 36:
                            return 37;
                            break;
                        case 37:
                            return 28;
                            break;
                        case 38:
                            return 28;
                            break;
                        case 39:
                            return 28;
                            break;
                        case 40:
                            return 28;
                            break;
                        case 41:
                            return 28;
                            break;
                        case 42:
                            return 28;
                            break;
                        case 43:
                            return 28;
                            break;
                        case 44:
                            return 28;
                            break;
                        case 45:
                            return 28;
                            break;
                        case 46:
                            return 28;
                            break;
                        case 47:
                            return 28;
                            break;
                        case 48:
                            return 28;
                            break;
                        case 49:
                            return 28;
                            break;
                        case 50:
                            return 28;
                            break;
                        case 51:
                            return 28;
                            break;
                        case 52:
                            return 28;
                            break;
                        case 53:
                            return 28;
                            break;
                        case 54:
                            return 28;
                            break;
                        case 55:
                            return 28;
                            break;
                        case 56:
                            return 28;
                            break;
                        case 57:
                            return 28;
                            break;
                        case 58:
                            return 28;
                            break;
                        case 59:
                            return 28;
                            break;
                        case 60:
                            return 28;
                            break;
                        case 61:
                            return 28;
                            break;
                        case 62:
                            return 28;
                            break;
                        case 63:
                            return 28;
                            break;
                        case 64:
                            return 28;
                            break;
                        case 65:
                            return 28;
                            break;
                        case 66:
                            return 28;
                            break;
                        case 67:
                            return 28;
                            break;
                        case 68:
                            return 28;
                            break;
                        case 69:
                            return 28;
                            break;
                        case 70:
                            return 28;
                            break;
                        case 71:
                            return 28;
                            break;
                        case 72:
                            return 28;
                            break;
                        case 73:
                            return 28;
                            break;
                        case 74:
                            return 28;
                            break;
                        case 75:
                            return 28;
                            break;
                        case 76:
                            return 28;
                            break;
                        case 77:
                            return 28;
                            break;
                        case 78:
                            return 28;
                            break;
                        case 79:
                            return 28;
                            break;
                        case 80:
                            return 28;
                            break;
                        case 81:
                            return 28;
                            break;
                        case 82:
                            return 28;
                            break;
                        case 83:
                            return 28;
                            break;
                        case 84:
                            return 28;
                            break;
                        case 85:
                            return 28;
                            break;
                        case 86:
                            return 28;
                            break;
                        case 87:
                            return 28;
                            break;
                        case 88:
                            return 28;
                            break;
                        case 89:
                            return 28;
                            break;
                        case 90:
                            return 28;
                            break;
                        case 91:
                            return 28;
                            break;
                        case 92:
                            return 38;
                            break;
                        case 93:
                            return 28;
                            break;
                        case 94:
                            return 28;
                            break;
                        case 95:
                            return 28;
                            break;
                        case 96:
                            return 28;
                            break;
                        case 97:
                            return 28;
                            break;
                        case 98:
                            return 28;
                            break;
                        case 99:
                            return 28;
                            break;
                        case 100:
                            return 28;
                            break;
                        case 101:
                            return 28;
                            break;
                        case 102:
                            return 28;
                            break;
                        case 103:
                            return 28;
                            break;
                        case 104:
                            return 28;
                            break;
                        case 105:
                            return 28;
                            break;
                        case 106:
                            return 28;
                            break;
                        case 107:
                            return 28;
                            break;
                        case 108:
                            return 28;
                            break;
                        case 109:
                            return 28;
                            break;
                        case 110:
                            return 28;
                            break;
                        case 111:
                            return 28;
                            break;
                        case 112:
                            return 28;
                            break;
                        case 113:
                            return 28;
                            break;
                        case 114:
                            return 28;
                            break;
                        case 115:
                            return 28;
                            break;
                        case 116:
                            return 28;
                            break;
                        case 117:
                            return 28;
                            break;
                        case 118:
                            return 28;
                            break;
                        case 119:
                            return 28;
                            break;
                        case 120:
                            return 28;
                            break;
                        case 121:
                            return 28;
                            break;
                        case 122:
                            return 28;
                            break;
                        case 123:
                            return 28;
                            break;
                        case 124:
                            return 28;
                            break;
                        case 125:
                            return 28;
                            break;
                        case 126:
                            return 28;
                            break;
                        case 161:
                            return 28;
                            break;
                        case 162:
                            return 28;
                            break;
                        case 163:
                            return 28;
                            break;
                        case 164:
                            return 28;
                            break;
                        case 165:
                            return 28;
                            break;
                        case 166:
                            return 28;
                            break;
                        case 167:
                            return 28;
                            break;
                        case 168:
                            return 28;
                            break;
                        case 169:
                            return 28;
                            break;
                        case 170:
                            return 28;
                            break;
                        case 171:
                            return 28;
                            break;
                        case 172:
                            return 28;
                            break;
                        case 173:
                            return 28;
                            break;
                        case 174:
                            return 28;
                            break;
                        case 175:
                            return 28;
                            break;
                        case 176:
                            return 28;
                            break;
                        case 177:
                            return 28;
                            break;
                        case 178:
                            return 28;
                            break;
                        case 179:
                            return 28;
                            break;
                        case 180:
                            return 28;
                            break;
                        case 181:
                            return 28;
                            break;
                        case 182:
                            return 28;
                            break;
                        case 183:
                            return 28;
                            break;
                        case 184:
                            return 28;
                            break;
                        case 185:
                            return 28;
                            break;
                        case 186:
                            return 28;
                            break;
                        case 187:
                            return 28;
                            break;
                        case 188:
                            return 28;
                            break;
                        case 189:
                            return 28;
                            break;
                        case 190:
                            return 28;
                            break;
                        case 191:
                            return 28;
                            break;
                        case 192:
                            return 28;
                            break;
                        case 193:
                            return 28;
                            break;
                        case 194:
                            return 28;
                            break;
                        case 195:
                            return 28;
                            break;
                        case 196:
                            return 28;
                            break;
                        case 197:
                            return 28;
                            break;
                        case 198:
                            return 28;
                            break;
                        case 199:
                            return 28;
                            break;
                        case 200:
                            return 28;
                            break;
                        case 201:
                            return 28;
                            break;
                        case 202:
                            return 28;
                            break;
                        case 203:
                            return 28;
                            break;
                        case 204:
                            return 28;
                            break;
                        case 205:
                            return 28;
                            break;
                        case 206:
                            return 28;
                            break;
                        case 207:
                            return 28;
                            break;
                        case 208:
                            return 28;
                            break;
                        case 209:
                            return 28;
                            break;
                        case 210:
                            return 28;
                            break;
                        case 211:
                            return 28;
                            break;
                        case 212:
                            return 28;
                            break;
                        case 213:
                            return 28;
                            break;
                        case 214:
                            return 28;
                            break;
                        case 215:
                            return 28;
                            break;
                        case 216:
                            return 28;
                            break;
                        case 217:
                            return 28;
                            break;
                        case 218:
                            return 28;
                            break;
                        case 219:
                            return 28;
                            break;
                        case 220:
                            return 28;
                            break;
                        case 221:
                            return 28;
                            break;
                        case 222:
                            return 28;
                            break;
                        case 223:
                            return 28;
                            break;
                        case 224:
                            return 28;
                            break;
                        case 225:
                            return 28;
                            break;
                        case 226:
                            return 28;
                            break;
                        case 227:
                            return 28;
                            break;
                        case 228:
                            return 28;
                            break;
                        case 229:
                            return 28;
                            break;
                        case 230:
                            return 28;
                            break;
                        case 231:
                            return 28;
                            break;
                        case 232:
                            return 28;
                            break;
                        case 233:
                            return 28;
                            break;
                        case 234:
                            return 28;
                            break;
                        case 235:
                            return 28;
                            break;
                        case 236:
                            return 28;
                            break;
                        case 237:
                            return 28;
                            break;
                        case 238:
                            return 28;
                            break;
                        case 239:
                            return 28;
                            break;
                        case 240:
                            return 28;
                            break;
                        case 241:
                            return 28;
                            break;
                        case 242:
                            return 28;
                            break;
                        case 243:
                            return 28;
                            break;
                        case 244:
                            return 28;
                            break;
                        case 245:
                            return 28;
                            break;
                        case 246:
                            return 28;
                            break;
                        case 247:
                            return 28;
                            break;
                        case 248:
                            return 28;
                            break;
                        case 249:
                            return 28;
                            break;
                        case 250:
                            return 28;
                            break;
                        case 251:
                            return 28;
                            break;
                        case 252:
                            return 28;
                            break;
                        case 253:
                            return 28;
                            break;
                        case 254:
                            return 28;
                            break;
                        case 255:
                            return 28;
                            break;
                        default:
                            return -1;
                            break;
                    }
                    break;
                case 29:
                    switch (c)
                    {
                        case 9:
                            return 29;
                            break;
                        case 13:
                            return 29;
                            break;
                        case 32:
                            return 29;
                            break;
                        case 33:
                            return 29;
                            break;
                        case 34:
                            return 29;
                            break;
                        case 35:
                            return 29;
                            break;
                        case 36:
                            return 29;
                            break;
                        case 37:
                            return 29;
                            break;
                        case 38:
                            return 29;
                            break;
                        case 39:
                            return 29;
                            break;
                        case 40:
                            return 29;
                            break;
                        case 41:
                            return 29;
                            break;
                        case 42:
                            return 29;
                            break;
                        case 43:
                            return 29;
                            break;
                        case 44:
                            return 29;
                            break;
                        case 45:
                            return 29;
                            break;
                        case 46:
                            return 29;
                            break;
                        case 47:
                            return 29;
                            break;
                        case 48:
                            return 29;
                            break;
                        case 49:
                            return 29;
                            break;
                        case 50:
                            return 29;
                            break;
                        case 51:
                            return 29;
                            break;
                        case 52:
                            return 29;
                            break;
                        case 53:
                            return 29;
                            break;
                        case 54:
                            return 29;
                            break;
                        case 55:
                            return 29;
                            break;
                        case 56:
                            return 29;
                            break;
                        case 57:
                            return 29;
                            break;
                        case 58:
                            return 29;
                            break;
                        case 59:
                            return 29;
                            break;
                        case 60:
                            return 29;
                            break;
                        case 61:
                            return 29;
                            break;
                        case 62:
                            return 29;
                            break;
                        case 63:
                            return 29;
                            break;
                        case 64:
                            return 29;
                            break;
                        case 65:
                            return 29;
                            break;
                        case 66:
                            return 29;
                            break;
                        case 67:
                            return 29;
                            break;
                        case 68:
                            return 29;
                            break;
                        case 69:
                            return 29;
                            break;
                        case 70:
                            return 29;
                            break;
                        case 71:
                            return 29;
                            break;
                        case 72:
                            return 29;
                            break;
                        case 73:
                            return 29;
                            break;
                        case 74:
                            return 29;
                            break;
                        case 75:
                            return 29;
                            break;
                        case 76:
                            return 29;
                            break;
                        case 77:
                            return 29;
                            break;
                        case 78:
                            return 29;
                            break;
                        case 79:
                            return 29;
                            break;
                        case 80:
                            return 29;
                            break;
                        case 81:
                            return 29;
                            break;
                        case 82:
                            return 29;
                            break;
                        case 83:
                            return 29;
                            break;
                        case 84:
                            return 29;
                            break;
                        case 85:
                            return 29;
                            break;
                        case 86:
                            return 29;
                            break;
                        case 87:
                            return 29;
                            break;
                        case 88:
                            return 29;
                            break;
                        case 89:
                            return 29;
                            break;
                        case 90:
                            return 29;
                            break;
                        case 91:
                            return 29;
                            break;
                        case 92:
                            return 29;
                            break;
                        case 93:
                            return 29;
                            break;
                        case 94:
                            return 29;
                            break;
                        case 95:
                            return 29;
                            break;
                        case 96:
                            return 29;
                            break;
                        case 97:
                            return 29;
                            break;
                        case 98:
                            return 29;
                            break;
                        case 99:
                            return 29;
                            break;
                        case 100:
                            return 29;
                            break;
                        case 101:
                            return 29;
                            break;
                        case 102:
                            return 29;
                            break;
                        case 103:
                            return 29;
                            break;
                        case 104:
                            return 29;
                            break;
                        case 105:
                            return 29;
                            break;
                        case 106:
                            return 29;
                            break;
                        case 107:
                            return 29;
                            break;
                        case 108:
                            return 29;
                            break;
                        case 109:
                            return 29;
                            break;
                        case 110:
                            return 29;
                            break;
                        case 111:
                            return 29;
                            break;
                        case 112:
                            return 29;
                            break;
                        case 113:
                            return 29;
                            break;
                        case 114:
                            return 29;
                            break;
                        case 115:
                            return 29;
                            break;
                        case 116:
                            return 29;
                            break;
                        case 117:
                            return 29;
                            break;
                        case 118:
                            return 29;
                            break;
                        case 119:
                            return 29;
                            break;
                        case 120:
                            return 29;
                            break;
                        case 121:
                            return 29;
                            break;
                        case 122:
                            return 29;
                            break;
                        case 123:
                            return 29;
                            break;
                        case 124:
                            return 29;
                            break;
                        case 125:
                            return 29;
                            break;
                        case 126:
                            return 29;
                            break;
                        case 161:
                            return 29;
                            break;
                        case 162:
                            return 29;
                            break;
                        case 163:
                            return 29;
                            break;
                        case 164:
                            return 29;
                            break;
                        case 165:
                            return 29;
                            break;
                        case 166:
                            return 29;
                            break;
                        case 167:
                            return 29;
                            break;
                        case 168:
                            return 29;
                            break;
                        case 169:
                            return 29;
                            break;
                        case 170:
                            return 29;
                            break;
                        case 171:
                            return 29;
                            break;
                        case 172:
                            return 29;
                            break;
                        case 173:
                            return 29;
                            break;
                        case 174:
                            return 29;
                            break;
                        case 175:
                            return 29;
                            break;
                        case 176:
                            return 29;
                            break;
                        case 177:
                            return 29;
                            break;
                        case 178:
                            return 29;
                            break;
                        case 179:
                            return 29;
                            break;
                        case 180:
                            return 29;
                            break;
                        case 181:
                            return 29;
                            break;
                        case 182:
                            return 29;
                            break;
                        case 183:
                            return 29;
                            break;
                        case 184:
                            return 29;
                            break;
                        case 185:
                            return 29;
                            break;
                        case 186:
                            return 29;
                            break;
                        case 187:
                            return 29;
                            break;
                        case 188:
                            return 29;
                            break;
                        case 189:
                            return 29;
                            break;
                        case 190:
                            return 29;
                            break;
                        case 191:
                            return 29;
                            break;
                        case 192:
                            return 29;
                            break;
                        case 193:
                            return 29;
                            break;
                        case 194:
                            return 29;
                            break;
                        case 195:
                            return 29;
                            break;
                        case 196:
                            return 29;
                            break;
                        case 197:
                            return 29;
                            break;
                        case 198:
                            return 29;
                            break;
                        case 199:
                            return 29;
                            break;
                        case 200:
                            return 29;
                            break;
                        case 201:
                            return 29;
                            break;
                        case 202:
                            return 29;
                            break;
                        case 203:
                            return 29;
                            break;
                        case 204:
                            return 29;
                            break;
                        case 205:
                            return 29;
                            break;
                        case 206:
                            return 29;
                            break;
                        case 207:
                            return 29;
                            break;
                        case 208:
                            return 29;
                            break;
                        case 209:
                            return 29;
                            break;
                        case 210:
                            return 29;
                            break;
                        case 211:
                            return 29;
                            break;
                        case 212:
                            return 29;
                            break;
                        case 213:
                            return 29;
                            break;
                        case 214:
                            return 29;
                            break;
                        case 215:
                            return 29;
                            break;
                        case 216:
                            return 29;
                            break;
                        case 217:
                            return 29;
                            break;
                        case 218:
                            return 29;
                            break;
                        case 219:
                            return 29;
                            break;
                        case 220:
                            return 29;
                            break;
                        case 221:
                            return 29;
                            break;
                        case 222:
                            return 29;
                            break;
                        case 223:
                            return 29;
                            break;
                        case 224:
                            return 29;
                            break;
                        case 225:
                            return 29;
                            break;
                        case 226:
                            return 29;
                            break;
                        case 227:
                            return 29;
                            break;
                        case 228:
                            return 29;
                            break;
                        case 229:
                            return 29;
                            break;
                        case 230:
                            return 29;
                            break;
                        case 231:
                            return 29;
                            break;
                        case 232:
                            return 29;
                            break;
                        case 233:
                            return 29;
                            break;
                        case 234:
                            return 29;
                            break;
                        case 235:
                            return 29;
                            break;
                        case 236:
                            return 29;
                            break;
                        case 237:
                            return 29;
                            break;
                        case 238:
                            return 29;
                            break;
                        case 239:
                            return 29;
                            break;
                        case 240:
                            return 29;
                            break;
                        case 241:
                            return 29;
                            break;
                        case 242:
                            return 29;
                            break;
                        case 243:
                            return 29;
                            break;
                        case 244:
                            return 29;
                            break;
                        case 245:
                            return 29;
                            break;
                        case 246:
                            return 29;
                            break;
                        case 247:
                            return 29;
                            break;
                        case 248:
                            return 29;
                            break;
                        case 249:
                            return 29;
                            break;
                        case 250:
                            return 29;
                            break;
                        case 251:
                            return 29;
                            break;
                        case 252:
                            return 29;
                            break;
                        case 253:
                            return 29;
                            break;
                        case 254:
                            return 29;
                            break;
                        case 255:
                            return 29;
                            break;
                        default:
                            return -1;
                            break;
                    }
                    break;
                case 31:
                    switch (c)
                    {
                        case 48:
                            return 39;
                            break;
                        case 49:
                            return 39;
                            break;
                        case 50:
                            return 39;
                            break;
                        case 51:
                            return 39;
                            break;
                        case 52:
                            return 39;
                            break;
                        case 53:
                            return 39;
                            break;
                        case 54:
                            return 39;
                            break;
                        case 55:
                            return 39;
                            break;
                        case 56:
                            return 39;
                            break;
                        case 57:
                            return 39;
                            break;
                        default:
                            return -1;
                            break;
                    }
                    break;
                case 33:
                    switch (c)
                    {
                        case 48:
                            return 33;
                            break;
                        case 49:
                            return 33;
                            break;
                        case 50:
                            return 33;
                            break;
                        case 51:
                            return 33;
                            break;
                        case 52:
                            return 33;
                            break;
                        case 53:
                            return 33;
                            break;
                        case 54:
                            return 33;
                            break;
                        case 55:
                            return 33;
                            break;
                        case 56:
                            return 33;
                            break;
                        case 57:
                            return 33;
                            break;
                        case 65:
                            return 33;
                            break;
                        case 66:
                            return 33;
                            break;
                        case 67:
                            return 33;
                            break;
                        case 68:
                            return 33;
                            break;
                        case 69:
                            return 33;
                            break;
                        case 70:
                            return 33;
                            break;
                        case 71:
                            return 33;
                            break;
                        case 72:
                            return 33;
                            break;
                        case 73:
                            return 33;
                            break;
                        case 74:
                            return 33;
                            break;
                        case 75:
                            return 33;
                            break;
                        case 76:
                            return 33;
                            break;
                        case 77:
                            return 33;
                            break;
                        case 78:
                            return 33;
                            break;
                        case 79:
                            return 33;
                            break;
                        case 80:
                            return 33;
                            break;
                        case 81:
                            return 33;
                            break;
                        case 82:
                            return 33;
                            break;
                        case 83:
                            return 33;
                            break;
                        case 84:
                            return 33;
                            break;
                        case 85:
                            return 33;
                            break;
                        case 86:
                            return 33;
                            break;
                        case 87:
                            return 33;
                            break;
                        case 88:
                            return 33;
                            break;
                        case 89:
                            return 33;
                            break;
                        case 90:
                            return 33;
                            break;
                        case 95:
                            return 40;
                            break;
                        case 97:
                            return 33;
                            break;
                        case 98:
                            return 33;
                            break;
                        case 99:
                            return 33;
                            break;
                        case 100:
                            return 33;
                            break;
                        case 101:
                            return 33;
                            break;
                        case 102:
                            return 33;
                            break;
                        case 103:
                            return 33;
                            break;
                        case 104:
                            return 33;
                            break;
                        case 105:
                            return 33;
                            break;
                        case 106:
                            return 33;
                            break;
                        case 107:
                            return 33;
                            break;
                        case 108:
                            return 33;
                            break;
                        case 109:
                            return 33;
                            break;
                        case 110:
                            return 33;
                            break;
                        case 111:
                            return 33;
                            break;
                        case 112:
                            return 33;
                            break;
                        case 113:
                            return 33;
                            break;
                        case 114:
                            return 33;
                            break;
                        case 115:
                            return 33;
                            break;
                        case 116:
                            return 33;
                            break;
                        case 117:
                            return 33;
                            break;
                        case 118:
                            return 33;
                            break;
                        case 119:
                            return 33;
                            break;
                        case 120:
                            return 33;
                            break;
                        case 121:
                            return 33;
                            break;
                        case 122:
                            return 33;
                            break;
                        default:
                            return -1;
                            break;
                    }
                    break;
                case 34:
                    switch (c)
                    {
                        case 48:
                            return 41;
                            break;
                        case 49:
                            return 41;
                            break;
                        case 50:
                            return 41;
                            break;
                        case 51:
                            return 41;
                            break;
                        case 52:
                            return 41;
                            break;
                        case 53:
                            return 41;
                            break;
                        case 54:
                            return 41;
                            break;
                        case 55:
                            return 41;
                            break;
                        case 56:
                            return 41;
                            break;
                        case 57:
                            return 41;
                            break;
                        case 65:
                            return 41;
                            break;
                        case 66:
                            return 41;
                            break;
                        case 67:
                            return 41;
                            break;
                        case 68:
                            return 41;
                            break;
                        case 69:
                            return 41;
                            break;
                        case 70:
                            return 41;
                            break;
                        case 71:
                            return 41;
                            break;
                        case 72:
                            return 41;
                            break;
                        case 73:
                            return 41;
                            break;
                        case 74:
                            return 41;
                            break;
                        case 75:
                            return 41;
                            break;
                        case 76:
                            return 41;
                            break;
                        case 77:
                            return 41;
                            break;
                        case 78:
                            return 41;
                            break;
                        case 79:
                            return 41;
                            break;
                        case 80:
                            return 41;
                            break;
                        case 81:
                            return 41;
                            break;
                        case 82:
                            return 41;
                            break;
                        case 83:
                            return 41;
                            break;
                        case 84:
                            return 41;
                            break;
                        case 85:
                            return 41;
                            break;
                        case 86:
                            return 41;
                            break;
                        case 87:
                            return 41;
                            break;
                        case 88:
                            return 41;
                            break;
                        case 89:
                            return 41;
                            break;
                        case 90:
                            return 41;
                            break;
                        case 97:
                            return 41;
                            break;
                        case 98:
                            return 41;
                            break;
                        case 99:
                            return 41;
                            break;
                        case 100:
                            return 41;
                            break;
                        case 101:
                            return 41;
                            break;
                        case 102:
                            return 41;
                            break;
                        case 103:
                            return 41;
                            break;
                        case 104:
                            return 41;
                            break;
                        case 105:
                            return 41;
                            break;
                        case 106:
                            return 41;
                            break;
                        case 107:
                            return 41;
                            break;
                        case 108:
                            return 41;
                            break;
                        case 109:
                            return 41;
                            break;
                        case 110:
                            return 41;
                            break;
                        case 111:
                            return 41;
                            break;
                        case 112:
                            return 41;
                            break;
                        case 113:
                            return 41;
                            break;
                        case 114:
                            return 41;
                            break;
                        case 115:
                            return 41;
                            break;
                        case 116:
                            return 41;
                            break;
                        case 117:
                            return 41;
                            break;
                        case 118:
                            return 41;
                            break;
                        case 119:
                            return 41;
                            break;
                        case 120:
                            return 41;
                            break;
                        case 121:
                            return 41;
                            break;
                        case 122:
                            return 41;
                            break;
                        default:
                            return -1;
                            break;
                    }
                    break;
                case 35:
                    switch (c)
                    {
                        case 48:
                            return 35;
                            break;
                        case 49:
                            return 35;
                            break;
                        default:
                            return -1;
                            break;
                    }
                    break;
                case 36:
                    switch (c)
                    {
                        case 48:
                            return 36;
                            break;
                        case 49:
                            return 36;
                            break;
                        case 50:
                            return 36;
                            break;
                        case 51:
                            return 36;
                            break;
                        case 52:
                            return 36;
                            break;
                        case 53:
                            return 36;
                            break;
                        case 54:
                            return 36;
                            break;
                        case 55:
                            return 36;
                            break;
                        case 56:
                            return 36;
                            break;
                        case 57:
                            return 36;
                            break;
                        case 97:
                            return 36;
                            break;
                        case 98:
                            return 36;
                            break;
                        case 99:
                            return 36;
                            break;
                        case 100:
                            return 36;
                            break;
                        case 101:
                            return 36;
                            break;
                        case 102:
                            return 36;
                            break;
                        default:
                            return -1;
                            break;
                    }
                    break;
                case 38:
                    switch (c)
                    {
                        case 9:
                            return 28;
                            break;
                        case 10:
                            return 28;
                            break;
                        case 13:
                            return 28;
                            break;
                        case 32:
                            return 28;
                            break;
                        case 33:
                            return 28;
                            break;
                        case 34:
                            return 28;
                            break;
                        case 35:
                            return 28;
                            break;
                        case 36:
                            return 42;
                            break;
                        case 37:
                            return 28;
                            break;
                        case 38:
                            return 28;
                            break;
                        case 39:
                            return 28;
                            break;
                        case 40:
                            return 28;
                            break;
                        case 41:
                            return 28;
                            break;
                        case 42:
                            return 28;
                            break;
                        case 43:
                            return 28;
                            break;
                        case 44:
                            return 28;
                            break;
                        case 45:
                            return 28;
                            break;
                        case 46:
                            return 28;
                            break;
                        case 47:
                            return 28;
                            break;
                        case 48:
                            return 28;
                            break;
                        case 49:
                            return 28;
                            break;
                        case 50:
                            return 28;
                            break;
                        case 51:
                            return 28;
                            break;
                        case 52:
                            return 28;
                            break;
                        case 53:
                            return 28;
                            break;
                        case 54:
                            return 28;
                            break;
                        case 55:
                            return 28;
                            break;
                        case 56:
                            return 28;
                            break;
                        case 57:
                            return 28;
                            break;
                        case 58:
                            return 28;
                            break;
                        case 59:
                            return 28;
                            break;
                        case 60:
                            return 28;
                            break;
                        case 61:
                            return 28;
                            break;
                        case 62:
                            return 28;
                            break;
                        case 63:
                            return 28;
                            break;
                        case 64:
                            return 28;
                            break;
                        case 65:
                            return 28;
                            break;
                        case 66:
                            return 28;
                            break;
                        case 67:
                            return 28;
                            break;
                        case 68:
                            return 28;
                            break;
                        case 69:
                            return 28;
                            break;
                        case 70:
                            return 28;
                            break;
                        case 71:
                            return 28;
                            break;
                        case 72:
                            return 28;
                            break;
                        case 73:
                            return 28;
                            break;
                        case 74:
                            return 28;
                            break;
                        case 75:
                            return 28;
                            break;
                        case 76:
                            return 28;
                            break;
                        case 77:
                            return 28;
                            break;
                        case 78:
                            return 28;
                            break;
                        case 79:
                            return 28;
                            break;
                        case 80:
                            return 28;
                            break;
                        case 81:
                            return 28;
                            break;
                        case 82:
                            return 28;
                            break;
                        case 83:
                            return 28;
                            break;
                        case 84:
                            return 28;
                            break;
                        case 85:
                            return 28;
                            break;
                        case 86:
                            return 28;
                            break;
                        case 87:
                            return 28;
                            break;
                        case 88:
                            return 28;
                            break;
                        case 89:
                            return 28;
                            break;
                        case 90:
                            return 28;
                            break;
                        case 91:
                            return 28;
                            break;
                        case 92:
                            return 38;
                            break;
                        case 93:
                            return 28;
                            break;
                        case 94:
                            return 28;
                            break;
                        case 95:
                            return 28;
                            break;
                        case 96:
                            return 28;
                            break;
                        case 97:
                            return 28;
                            break;
                        case 98:
                            return 28;
                            break;
                        case 99:
                            return 28;
                            break;
                        case 100:
                            return 28;
                            break;
                        case 101:
                            return 28;
                            break;
                        case 102:
                            return 28;
                            break;
                        case 103:
                            return 28;
                            break;
                        case 104:
                            return 28;
                            break;
                        case 105:
                            return 28;
                            break;
                        case 106:
                            return 28;
                            break;
                        case 107:
                            return 28;
                            break;
                        case 108:
                            return 28;
                            break;
                        case 109:
                            return 28;
                            break;
                        case 110:
                            return 28;
                            break;
                        case 111:
                            return 28;
                            break;
                        case 112:
                            return 28;
                            break;
                        case 113:
                            return 28;
                            break;
                        case 114:
                            return 28;
                            break;
                        case 115:
                            return 28;
                            break;
                        case 116:
                            return 28;
                            break;
                        case 117:
                            return 28;
                            break;
                        case 118:
                            return 28;
                            break;
                        case 119:
                            return 28;
                            break;
                        case 120:
                            return 28;
                            break;
                        case 121:
                            return 28;
                            break;
                        case 122:
                            return 28;
                            break;
                        case 123:
                            return 28;
                            break;
                        case 124:
                            return 28;
                            break;
                        case 125:
                            return 28;
                            break;
                        case 126:
                            return 28;
                            break;
                        case 161:
                            return 28;
                            break;
                        case 162:
                            return 28;
                            break;
                        case 163:
                            return 28;
                            break;
                        case 164:
                            return 28;
                            break;
                        case 165:
                            return 28;
                            break;
                        case 166:
                            return 28;
                            break;
                        case 167:
                            return 28;
                            break;
                        case 168:
                            return 28;
                            break;
                        case 169:
                            return 28;
                            break;
                        case 170:
                            return 28;
                            break;
                        case 171:
                            return 28;
                            break;
                        case 172:
                            return 28;
                            break;
                        case 173:
                            return 28;
                            break;
                        case 174:
                            return 28;
                            break;
                        case 175:
                            return 28;
                            break;
                        case 176:
                            return 28;
                            break;
                        case 177:
                            return 28;
                            break;
                        case 178:
                            return 28;
                            break;
                        case 179:
                            return 28;
                            break;
                        case 180:
                            return 28;
                            break;
                        case 181:
                            return 28;
                            break;
                        case 182:
                            return 28;
                            break;
                        case 183:
                            return 28;
                            break;
                        case 184:
                            return 28;
                            break;
                        case 185:
                            return 28;
                            break;
                        case 186:
                            return 28;
                            break;
                        case 187:
                            return 28;
                            break;
                        case 188:
                            return 28;
                            break;
                        case 189:
                            return 28;
                            break;
                        case 190:
                            return 28;
                            break;
                        case 191:
                            return 28;
                            break;
                        case 192:
                            return 28;
                            break;
                        case 193:
                            return 28;
                            break;
                        case 194:
                            return 28;
                            break;
                        case 195:
                            return 28;
                            break;
                        case 196:
                            return 28;
                            break;
                        case 197:
                            return 28;
                            break;
                        case 198:
                            return 28;
                            break;
                        case 199:
                            return 28;
                            break;
                        case 200:
                            return 28;
                            break;
                        case 201:
                            return 28;
                            break;
                        case 202:
                            return 28;
                            break;
                        case 203:
                            return 28;
                            break;
                        case 204:
                            return 28;
                            break;
                        case 205:
                            return 28;
                            break;
                        case 206:
                            return 28;
                            break;
                        case 207:
                            return 28;
                            break;
                        case 208:
                            return 28;
                            break;
                        case 209:
                            return 28;
                            break;
                        case 210:
                            return 28;
                            break;
                        case 211:
                            return 28;
                            break;
                        case 212:
                            return 28;
                            break;
                        case 213:
                            return 28;
                            break;
                        case 214:
                            return 28;
                            break;
                        case 215:
                            return 28;
                            break;
                        case 216:
                            return 28;
                            break;
                        case 217:
                            return 28;
                            break;
                        case 218:
                            return 28;
                            break;
                        case 219:
                            return 28;
                            break;
                        case 220:
                            return 28;
                            break;
                        case 221:
                            return 28;
                            break;
                        case 222:
                            return 28;
                            break;
                        case 223:
                            return 28;
                            break;
                        case 224:
                            return 28;
                            break;
                        case 225:
                            return 28;
                            break;
                        case 226:
                            return 28;
                            break;
                        case 227:
                            return 28;
                            break;
                        case 228:
                            return 28;
                            break;
                        case 229:
                            return 28;
                            break;
                        case 230:
                            return 28;
                            break;
                        case 231:
                            return 28;
                            break;
                        case 232:
                            return 28;
                            break;
                        case 233:
                            return 28;
                            break;
                        case 234:
                            return 28;
                            break;
                        case 235:
                            return 28;
                            break;
                        case 236:
                            return 28;
                            break;
                        case 237:
                            return 28;
                            break;
                        case 238:
                            return 28;
                            break;
                        case 239:
                            return 28;
                            break;
                        case 240:
                            return 28;
                            break;
                        case 241:
                            return 28;
                            break;
                        case 242:
                            return 28;
                            break;
                        case 243:
                            return 28;
                            break;
                        case 244:
                            return 28;
                            break;
                        case 245:
                            return 28;
                            break;
                        case 246:
                            return 28;
                            break;
                        case 247:
                            return 28;
                            break;
                        case 248:
                            return 28;
                            break;
                        case 249:
                            return 28;
                            break;
                        case 250:
                            return 28;
                            break;
                        case 251:
                            return 28;
                            break;
                        case 252:
                            return 28;
                            break;
                        case 253:
                            return 28;
                            break;
                        case 254:
                            return 28;
                            break;
                        case 255:
                            return 28;
                            break;
                        default:
                            return -1;
                            break;
                    }
                    break;
                case 39:
                    switch (c)
                    {
                        case 48:
                            return 43;
                            break;
                        case 49:
                            return 39;
                            break;
                        case 50:
                            return 39;
                            break;
                        case 51:
                            return 39;
                            break;
                        case 52:
                            return 39;
                            break;
                        case 53:
                            return 39;
                            break;
                        case 54:
                            return 39;
                            break;
                        case 55:
                            return 39;
                            break;
                        case 56:
                            return 39;
                            break;
                        case 57:
                            return 39;
                            break;
                        default:
                            return -1;
                            break;
                    }
                    break;
                case 40:
                    switch (c)
                    {
                        case 48:
                            return 33;
                            break;
                        case 49:
                            return 33;
                            break;
                        case 50:
                            return 33;
                            break;
                        case 51:
                            return 33;
                            break;
                        case 52:
                            return 33;
                            break;
                        case 53:
                            return 33;
                            break;
                        case 54:
                            return 33;
                            break;
                        case 55:
                            return 33;
                            break;
                        case 56:
                            return 33;
                            break;
                        case 57:
                            return 33;
                            break;
                        case 65:
                            return 33;
                            break;
                        case 66:
                            return 33;
                            break;
                        case 67:
                            return 33;
                            break;
                        case 68:
                            return 33;
                            break;
                        case 69:
                            return 33;
                            break;
                        case 70:
                            return 33;
                            break;
                        case 71:
                            return 33;
                            break;
                        case 72:
                            return 33;
                            break;
                        case 73:
                            return 33;
                            break;
                        case 74:
                            return 33;
                            break;
                        case 75:
                            return 33;
                            break;
                        case 76:
                            return 33;
                            break;
                        case 77:
                            return 33;
                            break;
                        case 78:
                            return 33;
                            break;
                        case 79:
                            return 33;
                            break;
                        case 80:
                            return 33;
                            break;
                        case 81:
                            return 33;
                            break;
                        case 82:
                            return 33;
                            break;
                        case 83:
                            return 33;
                            break;
                        case 84:
                            return 33;
                            break;
                        case 85:
                            return 33;
                            break;
                        case 86:
                            return 33;
                            break;
                        case 87:
                            return 33;
                            break;
                        case 88:
                            return 33;
                            break;
                        case 89:
                            return 33;
                            break;
                        case 90:
                            return 33;
                            break;
                        case 97:
                            return 33;
                            break;
                        case 98:
                            return 33;
                            break;
                        case 99:
                            return 33;
                            break;
                        case 100:
                            return 33;
                            break;
                        case 101:
                            return 33;
                            break;
                        case 102:
                            return 33;
                            break;
                        case 103:
                            return 33;
                            break;
                        case 104:
                            return 33;
                            break;
                        case 105:
                            return 33;
                            break;
                        case 106:
                            return 33;
                            break;
                        case 107:
                            return 33;
                            break;
                        case 108:
                            return 33;
                            break;
                        case 109:
                            return 33;
                            break;
                        case 110:
                            return 33;
                            break;
                        case 111:
                            return 33;
                            break;
                        case 112:
                            return 33;
                            break;
                        case 113:
                            return 33;
                            break;
                        case 114:
                            return 33;
                            break;
                        case 115:
                            return 33;
                            break;
                        case 116:
                            return 33;
                            break;
                        case 117:
                            return 33;
                            break;
                        case 118:
                            return 33;
                            break;
                        case 119:
                            return 33;
                            break;
                        case 120:
                            return 33;
                            break;
                        case 121:
                            return 33;
                            break;
                        case 122:
                            return 33;
                            break;
                        default:
                            return -1;
                            break;
                    }
                    break;
                case 41:
                    switch (c)
                    {
                        case 48:
                            return 41;
                            break;
                        case 49:
                            return 41;
                            break;
                        case 50:
                            return 41;
                            break;
                        case 51:
                            return 41;
                            break;
                        case 52:
                            return 41;
                            break;
                        case 53:
                            return 41;
                            break;
                        case 54:
                            return 41;
                            break;
                        case 55:
                            return 41;
                            break;
                        case 56:
                            return 41;
                            break;
                        case 57:
                            return 41;
                            break;
                        case 65:
                            return 41;
                            break;
                        case 66:
                            return 41;
                            break;
                        case 67:
                            return 41;
                            break;
                        case 68:
                            return 41;
                            break;
                        case 69:
                            return 41;
                            break;
                        case 70:
                            return 41;
                            break;
                        case 71:
                            return 41;
                            break;
                        case 72:
                            return 41;
                            break;
                        case 73:
                            return 41;
                            break;
                        case 74:
                            return 41;
                            break;
                        case 75:
                            return 41;
                            break;
                        case 76:
                            return 41;
                            break;
                        case 77:
                            return 41;
                            break;
                        case 78:
                            return 41;
                            break;
                        case 79:
                            return 41;
                            break;
                        case 80:
                            return 41;
                            break;
                        case 81:
                            return 41;
                            break;
                        case 82:
                            return 41;
                            break;
                        case 83:
                            return 41;
                            break;
                        case 84:
                            return 41;
                            break;
                        case 85:
                            return 41;
                            break;
                        case 86:
                            return 41;
                            break;
                        case 87:
                            return 41;
                            break;
                        case 88:
                            return 41;
                            break;
                        case 89:
                            return 41;
                            break;
                        case 90:
                            return 41;
                            break;
                        case 95:
                            return 34;
                            break;
                        case 97:
                            return 41;
                            break;
                        case 98:
                            return 41;
                            break;
                        case 99:
                            return 41;
                            break;
                        case 100:
                            return 41;
                            break;
                        case 101:
                            return 41;
                            break;
                        case 102:
                            return 41;
                            break;
                        case 103:
                            return 41;
                            break;
                        case 104:
                            return 41;
                            break;
                        case 105:
                            return 41;
                            break;
                        case 106:
                            return 41;
                            break;
                        case 107:
                            return 41;
                            break;
                        case 108:
                            return 41;
                            break;
                        case 109:
                            return 41;
                            break;
                        case 110:
                            return 41;
                            break;
                        case 111:
                            return 41;
                            break;
                        case 112:
                            return 41;
                            break;
                        case 113:
                            return 41;
                            break;
                        case 114:
                            return 41;
                            break;
                        case 115:
                            return 41;
                            break;
                        case 116:
                            return 41;
                            break;
                        case 117:
                            return 41;
                            break;
                        case 118:
                            return 41;
                            break;
                        case 119:
                            return 41;
                            break;
                        case 120:
                            return 41;
                            break;
                        case 121:
                            return 41;
                            break;
                        case 122:
                            return 41;
                            break;
                        default:
                            return -1;
                            break;
                    }
                    break;
                case 42:
                    switch (c)
                    {
                        case 9:
                            return 28;
                            break;
                        case 10:
                            return 28;
                            break;
                        case 13:
                            return 28;
                            break;
                        case 32:
                            return 28;
                            break;
                        case 33:
                            return 28;
                            break;
                        case 34:
                            return 28;
                            break;
                        case 35:
                            return 28;
                            break;
                        case 36:
                            return 37;
                            break;
                        case 37:
                            return 28;
                            break;
                        case 38:
                            return 28;
                            break;
                        case 39:
                            return 28;
                            break;
                        case 40:
                            return 28;
                            break;
                        case 41:
                            return 28;
                            break;
                        case 42:
                            return 28;
                            break;
                        case 43:
                            return 28;
                            break;
                        case 44:
                            return 28;
                            break;
                        case 45:
                            return 28;
                            break;
                        case 46:
                            return 28;
                            break;
                        case 47:
                            return 28;
                            break;
                        case 48:
                            return 28;
                            break;
                        case 49:
                            return 28;
                            break;
                        case 50:
                            return 28;
                            break;
                        case 51:
                            return 28;
                            break;
                        case 52:
                            return 28;
                            break;
                        case 53:
                            return 28;
                            break;
                        case 54:
                            return 28;
                            break;
                        case 55:
                            return 28;
                            break;
                        case 56:
                            return 28;
                            break;
                        case 57:
                            return 28;
                            break;
                        case 58:
                            return 28;
                            break;
                        case 59:
                            return 28;
                            break;
                        case 60:
                            return 28;
                            break;
                        case 61:
                            return 28;
                            break;
                        case 62:
                            return 28;
                            break;
                        case 63:
                            return 28;
                            break;
                        case 64:
                            return 28;
                            break;
                        case 65:
                            return 28;
                            break;
                        case 66:
                            return 28;
                            break;
                        case 67:
                            return 28;
                            break;
                        case 68:
                            return 28;
                            break;
                        case 69:
                            return 28;
                            break;
                        case 70:
                            return 28;
                            break;
                        case 71:
                            return 28;
                            break;
                        case 72:
                            return 28;
                            break;
                        case 73:
                            return 28;
                            break;
                        case 74:
                            return 28;
                            break;
                        case 75:
                            return 28;
                            break;
                        case 76:
                            return 28;
                            break;
                        case 77:
                            return 28;
                            break;
                        case 78:
                            return 28;
                            break;
                        case 79:
                            return 28;
                            break;
                        case 80:
                            return 28;
                            break;
                        case 81:
                            return 28;
                            break;
                        case 82:
                            return 28;
                            break;
                        case 83:
                            return 28;
                            break;
                        case 84:
                            return 28;
                            break;
                        case 85:
                            return 28;
                            break;
                        case 86:
                            return 28;
                            break;
                        case 87:
                            return 28;
                            break;
                        case 88:
                            return 28;
                            break;
                        case 89:
                            return 28;
                            break;
                        case 90:
                            return 28;
                            break;
                        case 91:
                            return 28;
                            break;
                        case 92:
                            return 38;
                            break;
                        case 93:
                            return 28;
                            break;
                        case 94:
                            return 28;
                            break;
                        case 95:
                            return 28;
                            break;
                        case 96:
                            return 28;
                            break;
                        case 97:
                            return 28;
                            break;
                        case 98:
                            return 28;
                            break;
                        case 99:
                            return 28;
                            break;
                        case 100:
                            return 28;
                            break;
                        case 101:
                            return 28;
                            break;
                        case 102:
                            return 28;
                            break;
                        case 103:
                            return 28;
                            break;
                        case 104:
                            return 28;
                            break;
                        case 105:
                            return 28;
                            break;
                        case 106:
                            return 28;
                            break;
                        case 107:
                            return 28;
                            break;
                        case 108:
                            return 28;
                            break;
                        case 109:
                            return 28;
                            break;
                        case 110:
                            return 28;
                            break;
                        case 111:
                            return 28;
                            break;
                        case 112:
                            return 28;
                            break;
                        case 113:
                            return 28;
                            break;
                        case 114:
                            return 28;
                            break;
                        case 115:
                            return 28;
                            break;
                        case 116:
                            return 28;
                            break;
                        case 117:
                            return 28;
                            break;
                        case 118:
                            return 28;
                            break;
                        case 119:
                            return 28;
                            break;
                        case 120:
                            return 28;
                            break;
                        case 121:
                            return 28;
                            break;
                        case 122:
                            return 28;
                            break;
                        case 123:
                            return 28;
                            break;
                        case 124:
                            return 28;
                            break;
                        case 125:
                            return 28;
                            break;
                        case 126:
                            return 28;
                            break;
                        case 161:
                            return 28;
                            break;
                        case 162:
                            return 28;
                            break;
                        case 163:
                            return 28;
                            break;
                        case 164:
                            return 28;
                            break;
                        case 165:
                            return 28;
                            break;
                        case 166:
                            return 28;
                            break;
                        case 167:
                            return 28;
                            break;
                        case 168:
                            return 28;
                            break;
                        case 169:
                            return 28;
                            break;
                        case 170:
                            return 28;
                            break;
                        case 171:
                            return 28;
                            break;
                        case 172:
                            return 28;
                            break;
                        case 173:
                            return 28;
                            break;
                        case 174:
                            return 28;
                            break;
                        case 175:
                            return 28;
                            break;
                        case 176:
                            return 28;
                            break;
                        case 177:
                            return 28;
                            break;
                        case 178:
                            return 28;
                            break;
                        case 179:
                            return 28;
                            break;
                        case 180:
                            return 28;
                            break;
                        case 181:
                            return 28;
                            break;
                        case 182:
                            return 28;
                            break;
                        case 183:
                            return 28;
                            break;
                        case 184:
                            return 28;
                            break;
                        case 185:
                            return 28;
                            break;
                        case 186:
                            return 28;
                            break;
                        case 187:
                            return 28;
                            break;
                        case 188:
                            return 28;
                            break;
                        case 189:
                            return 28;
                            break;
                        case 190:
                            return 28;
                            break;
                        case 191:
                            return 28;
                            break;
                        case 192:
                            return 28;
                            break;
                        case 193:
                            return 28;
                            break;
                        case 194:
                            return 28;
                            break;
                        case 195:
                            return 28;
                            break;
                        case 196:
                            return 28;
                            break;
                        case 197:
                            return 28;
                            break;
                        case 198:
                            return 28;
                            break;
                        case 199:
                            return 28;
                            break;
                        case 200:
                            return 28;
                            break;
                        case 201:
                            return 28;
                            break;
                        case 202:
                            return 28;
                            break;
                        case 203:
                            return 28;
                            break;
                        case 204:
                            return 28;
                            break;
                        case 205:
                            return 28;
                            break;
                        case 206:
                            return 28;
                            break;
                        case 207:
                            return 28;
                            break;
                        case 208:
                            return 28;
                            break;
                        case 209:
                            return 28;
                            break;
                        case 210:
                            return 28;
                            break;
                        case 211:
                            return 28;
                            break;
                        case 212:
                            return 28;
                            break;
                        case 213:
                            return 28;
                            break;
                        case 214:
                            return 28;
                            break;
                        case 215:
                            return 28;
                            break;
                        case 216:
                            return 28;
                            break;
                        case 217:
                            return 28;
                            break;
                        case 218:
                            return 28;
                            break;
                        case 219:
                            return 28;
                            break;
                        case 220:
                            return 28;
                            break;
                        case 221:
                            return 28;
                            break;
                        case 222:
                            return 28;
                            break;
                        case 223:
                            return 28;
                            break;
                        case 224:
                            return 28;
                            break;
                        case 225:
                            return 28;
                            break;
                        case 226:
                            return 28;
                            break;
                        case 227:
                            return 28;
                            break;
                        case 228:
                            return 28;
                            break;
                        case 229:
                            return 28;
                            break;
                        case 230:
                            return 28;
                            break;
                        case 231:
                            return 28;
                            break;
                        case 232:
                            return 28;
                            break;
                        case 233:
                            return 28;
                            break;
                        case 234:
                            return 28;
                            break;
                        case 235:
                            return 28;
                            break;
                        case 236:
                            return 28;
                            break;
                        case 237:
                            return 28;
                            break;
                        case 238:
                            return 28;
                            break;
                        case 239:
                            return 28;
                            break;
                        case 240:
                            return 28;
                            break;
                        case 241:
                            return 28;
                            break;
                        case 242:
                            return 28;
                            break;
                        case 243:
                            return 28;
                            break;
                        case 244:
                            return 28;
                            break;
                        case 245:
                            return 28;
                            break;
                        case 246:
                            return 28;
                            break;
                        case 247:
                            return 28;
                            break;
                        case 248:
                            return 28;
                            break;
                        case 249:
                            return 28;
                            break;
                        case 250:
                            return 28;
                            break;
                        case 251:
                            return 28;
                            break;
                        case 252:
                            return 28;
                            break;
                        case 253:
                            return 28;
                            break;
                        case 254:
                            return 28;
                            break;
                        case 255:
                            return 28;
                            break;
                        default:
                            return -1;
                            break;
                    }
                    break;
                case 43:
                    switch (c)
                    {
                        case 48:
                            return 43;
                            break;
                        case 49:
                            return 39;
                            break;
                        case 50:
                            return 39;
                            break;
                        case 51:
                            return 39;
                            break;
                        case 52:
                            return 39;
                            break;
                        case 53:
                            return 39;
                            break;
                        case 54:
                            return 39;
                            break;
                        case 55:
                            return 39;
                            break;
                        case 56:
                            return 39;
                            break;
                        case 57:
                            return 39;
                            break;
                        default:
                            return -1;
                            break;
                    }
                    break;
                default:
                    return -1;
                    break;
            }
        }

        private int tokenForState(int state)
        {
            if (((state < 0)
                        || (state >= TOKEN_STATE.length)))
            {
                return -1;
            }

            return TOKEN_STATE[state];
        }

        public int lookupToken(int base, String key)
        {
            int start = SPECIAL_CASES_INDEXES[base];
            int end = (SPECIAL_CASES_INDEXES[(base + 1)] - 1);
            while ((start <= end))
            {
                int half = ((start + end)
                            / 2);
                int comp = SPECIAL_CASES_KEYS[half].compareTo(key);
                if ((comp == 0))
                {
                    return SPECIAL_CASES_VALUES[half];
                }
                else if ((comp < 0))
                {
                    start = (half + 1);
                }
                else
                {
                    end = (half - 1);
                }

            }

            return base;
        }

        private bool hasInput()
        {
            return (this.position < this.input.length());
        }

        private char nextChar()
        {
            if (this.hasInput())
            {
                return this.input.charAt(position++);
            }
            else
            {
                return (char - 1);
            }

        }
    }
}
