public class Lexico implements Constants
{
    private int position;
    private String input;

    public Lexico()
    {
        this(new java.io.StringReader(""));
    }

    public Lexico(java.io.Reader input)
    {
        setInput(input);
    }

    public void setInput(java.io.Reader input)
    {
        StringBuffer bfr = new StringBuffer();
        try
        {
            int c = input.read();
            while (c != -1)
            {
                bfr.append((char)c);
                c = input.read();
            }
            this.input = bfr.toString();
        }
        catch (java.io.IOException e)
        {
            e.printStackTrace();
        }

        setPosition(0);
    }

    public void setPosition(int pos)
    {
        position = pos;
    }

    public Token nextToken() throws LexicalError
    {
        if ( ! hasInput() )
            return null;

        int start = position;

        int state = 0;
        int lastState = 0;
        int endState = -1;
        int end = -1;

        while (hasInput())
        {
            lastState = state;
            state = nextState(nextChar(), state);

            if (state < 0)
                break;

            else
            {
                if (tokenForState(state) >= 0)
                {
                    endState = state;
                    end = position;
                }
            }
        }
        if (endState < 0 || (endState != state && tokenForState(lastState) == -2))
            throw new LexicalError(SCANNER_ERROR[lastState], start);

        position = end;

        int token = tokenForState(endState);

        if (token == 0)
            return nextToken();
        else
        {
            String lexeme = input.substring(start, end);
            token = lookupToken(token, lexeme);
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
                    case 9: return 1;
                    case 10: return 1;
                    case 32: return 1;
                    case 33: return 2;
                    case 34: return 3;
                    case 35: return 4;
                    case 38: return 5;
                    case 40: return 6;
                    case 41: return 7;
                    case 42: return 8;
                    case 43: return 9;
                    case 44: return 10;
                    case 45: return 11;
                    case 46: return 12;
                    case 47: return 13;
                    case 48: return 14;
                    case 49: return 15;
                    case 50: return 15;
                    case 51: return 15;
                    case 52: return 15;
                    case 53: return 15;
                    case 54: return 15;
                    case 55: return 15;
                    case 56: return 15;
                    case 57: return 15;
                    case 58: return 16;
                    case 59: return 17;
                    case 60: return 18;
                    case 61: return 19;
                    case 62: return 20;
                    case 65: return 21;
                    case 66: return 21;
                    case 67: return 21;
                    case 68: return 21;
                    case 69: return 21;
                    case 70: return 21;
                    case 71: return 21;
                    case 72: return 21;
                    case 73: return 21;
                    case 74: return 21;
                    case 75: return 21;
                    case 76: return 21;
                    case 77: return 21;
                    case 78: return 21;
                    case 79: return 21;
                    case 80: return 21;
                    case 81: return 21;
                    case 82: return 21;
                    case 83: return 21;
                    case 84: return 21;
                    case 85: return 21;
                    case 86: return 21;
                    case 87: return 21;
                    case 88: return 21;
                    case 89: return 21;
                    case 90: return 21;
                    case 97: return 21;
                    case 98: return 21;
                    case 99: return 21;
                    case 100: return 21;
                    case 101: return 21;
                    case 102: return 21;
                    case 103: return 21;
                    case 104: return 21;
                    case 105: return 21;
                    case 106: return 21;
                    case 107: return 21;
                    case 108: return 21;
                    case 109: return 21;
                    case 110: return 21;
                    case 111: return 21;
                    case 112: return 21;
                    case 113: return 21;
                    case 114: return 21;
                    case 115: return 21;
                    case 116: return 21;
                    case 117: return 21;
                    case 118: return 21;
                    case 119: return 21;
                    case 120: return 21;
                    case 121: return 21;
                    case 122: return 21;
                    case 124: return 22;
                    default: return -1;
                }
            case 2:
                switch (c)
                {
                    case 61: return 23;
                    default: return -1;
                }
            case 3:
                switch (c)
                {
                    case 9: return 3;
                    case 13: return 3;
                    case 32: return 3;
                    case 33: return 3;
                    case 34: return 24;
                    case 35: return 3;
                    case 36: return 3;
                    case 37: return 3;
                    case 38: return 3;
                    case 39: return 3;
                    case 40: return 3;
                    case 41: return 3;
                    case 42: return 3;
                    case 43: return 3;
                    case 44: return 3;
                    case 45: return 3;
                    case 46: return 3;
                    case 47: return 3;
                    case 48: return 3;
                    case 49: return 3;
                    case 50: return 3;
                    case 51: return 3;
                    case 52: return 3;
                    case 53: return 3;
                    case 54: return 3;
                    case 55: return 3;
                    case 56: return 3;
                    case 57: return 3;
                    case 58: return 3;
                    case 59: return 3;
                    case 60: return 3;
                    case 61: return 3;
                    case 62: return 3;
                    case 63: return 3;
                    case 64: return 3;
                    case 65: return 3;
                    case 66: return 3;
                    case 67: return 3;
                    case 68: return 3;
                    case 69: return 3;
                    case 70: return 3;
                    case 71: return 3;
                    case 72: return 3;
                    case 73: return 3;
                    case 74: return 3;
                    case 75: return 3;
                    case 76: return 3;
                    case 77: return 3;
                    case 78: return 3;
                    case 79: return 3;
                    case 80: return 3;
                    case 81: return 3;
                    case 82: return 3;
                    case 83: return 3;
                    case 84: return 3;
                    case 85: return 3;
                    case 86: return 3;
                    case 87: return 3;
                    case 88: return 3;
                    case 89: return 3;
                    case 90: return 3;
                    case 91: return 3;
                    case 93: return 3;
                    case 94: return 3;
                    case 95: return 3;
                    case 96: return 3;
                    case 97: return 3;
                    case 98: return 3;
                    case 99: return 3;
                    case 100: return 3;
                    case 101: return 3;
                    case 102: return 3;
                    case 103: return 3;
                    case 104: return 3;
                    case 105: return 3;
                    case 106: return 3;
                    case 107: return 3;
                    case 108: return 3;
                    case 109: return 3;
                    case 110: return 3;
                    case 111: return 3;
                    case 112: return 3;
                    case 113: return 3;
                    case 114: return 3;
                    case 115: return 3;
                    case 116: return 3;
                    case 117: return 3;
                    case 118: return 3;
                    case 119: return 3;
                    case 120: return 3;
                    case 121: return 3;
                    case 122: return 3;
                    case 123: return 3;
                    case 124: return 3;
                    case 125: return 3;
                    case 126: return 3;
                    case 161: return 3;
                    case 162: return 3;
                    case 163: return 3;
                    case 164: return 3;
                    case 165: return 3;
                    case 166: return 3;
                    case 167: return 3;
                    case 168: return 3;
                    case 169: return 3;
                    case 170: return 3;
                    case 171: return 3;
                    case 172: return 3;
                    case 173: return 3;
                    case 174: return 3;
                    case 175: return 3;
                    case 176: return 3;
                    case 177: return 3;
                    case 178: return 3;
                    case 179: return 3;
                    case 180: return 3;
                    case 181: return 3;
                    case 182: return 3;
                    case 183: return 3;
                    case 184: return 3;
                    case 185: return 3;
                    case 186: return 3;
                    case 187: return 3;
                    case 188: return 3;
                    case 189: return 3;
                    case 190: return 3;
                    case 191: return 3;
                    case 192: return 3;
                    case 193: return 3;
                    case 194: return 3;
                    case 195: return 3;
                    case 196: return 3;
                    case 197: return 3;
                    case 198: return 3;
                    case 199: return 3;
                    case 200: return 3;
                    case 201: return 3;
                    case 202: return 3;
                    case 203: return 3;
                    case 204: return 3;
                    case 205: return 3;
                    case 206: return 3;
                    case 207: return 3;
                    case 208: return 3;
                    case 209: return 3;
                    case 210: return 3;
                    case 211: return 3;
                    case 212: return 3;
                    case 213: return 3;
                    case 214: return 3;
                    case 215: return 3;
                    case 216: return 3;
                    case 217: return 3;
                    case 218: return 3;
                    case 219: return 3;
                    case 220: return 3;
                    case 221: return 3;
                    case 222: return 3;
                    case 223: return 3;
                    case 224: return 3;
                    case 225: return 3;
                    case 226: return 3;
                    case 227: return 3;
                    case 228: return 3;
                    case 229: return 3;
                    case 230: return 3;
                    case 231: return 3;
                    case 232: return 3;
                    case 233: return 3;
                    case 234: return 3;
                    case 235: return 3;
                    case 236: return 3;
                    case 237: return 3;
                    case 238: return 3;
                    case 239: return 3;
                    case 240: return 3;
                    case 241: return 3;
                    case 242: return 3;
                    case 243: return 3;
                    case 244: return 3;
                    case 245: return 3;
                    case 246: return 3;
                    case 247: return 3;
                    case 248: return 3;
                    case 249: return 3;
                    case 250: return 3;
                    case 251: return 3;
                    case 252: return 3;
                    case 253: return 3;
                    case 254: return 3;
                    case 255: return 3;
                    default: return -1;
                }
            case 4:
                switch (c)
                {
                    case 66: return 25;
                    case 88: return 26;
                    case 98: return 25;
                    case 120: return 26;
                    default: return -1;
                }
            case 9:
                switch (c)
                {
                    case 61: return 27;
                    default: return -1;
                }
            case 11:
                switch (c)
                {
                    case 42: return 28;
                    case 45: return 29;
                    case 61: return 30;
                    default: return -1;
                }
            case 14:
                switch (c)
                {
                    case 46: return 31;
                    default: return -1;
                }
            case 15:
                switch (c)
                {
                    case 46: return 31;
                    case 48: return 15;
                    case 49: return 15;
                    case 50: return 15;
                    case 51: return 15;
                    case 52: return 15;
                    case 53: return 15;
                    case 54: return 15;
                    case 55: return 15;
                    case 56: return 15;
                    case 57: return 15;
                    default: return -1;
                }
            case 19:
                switch (c)
                {
                    case 61: return 32;
                    default: return -1;
                }
            case 21:
                switch (c)
                {
                    case 48: return 33;
                    case 49: return 33;
                    case 50: return 33;
                    case 51: return 33;
                    case 52: return 33;
                    case 53: return 33;
                    case 54: return 33;
                    case 55: return 33;
                    case 56: return 33;
                    case 57: return 33;
                    case 65: return 33;
                    case 66: return 33;
                    case 67: return 33;
                    case 68: return 33;
                    case 69: return 33;
                    case 70: return 33;
                    case 71: return 33;
                    case 72: return 33;
                    case 73: return 33;
                    case 74: return 33;
                    case 75: return 33;
                    case 76: return 33;
                    case 77: return 33;
                    case 78: return 33;
                    case 79: return 33;
                    case 80: return 33;
                    case 81: return 33;
                    case 82: return 33;
                    case 83: return 33;
                    case 84: return 33;
                    case 85: return 33;
                    case 86: return 33;
                    case 87: return 33;
                    case 88: return 33;
                    case 89: return 33;
                    case 90: return 33;
                    case 91: return 33;
                    case 92: return 33;
                    case 93: return 33;
                    case 94: return 33;
                    case 95: return 34;
                    case 96: return 33;
                    case 97: return 33;
                    case 98: return 33;
                    case 99: return 33;
                    case 100: return 33;
                    case 101: return 33;
                    case 102: return 33;
                    case 103: return 33;
                    case 104: return 33;
                    case 105: return 33;
                    case 106: return 33;
                    case 107: return 33;
                    case 108: return 33;
                    case 109: return 33;
                    case 110: return 33;
                    case 111: return 33;
                    case 112: return 33;
                    case 113: return 33;
                    case 114: return 33;
                    case 115: return 33;
                    case 116: return 33;
                    case 117: return 33;
                    case 118: return 33;
                    case 119: return 33;
                    case 120: return 33;
                    case 121: return 33;
                    case 122: return 33;
                    default: return -1;
                }
            case 25:
                switch (c)
                {
                    case 48: return 35;
                    case 49: return 35;
                    default: return -1;
                }
            case 26:
                switch (c)
                {
                    case 48: return 36;
                    case 49: return 36;
                    case 50: return 36;
                    case 51: return 36;
                    case 52: return 36;
                    case 53: return 36;
                    case 54: return 36;
                    case 55: return 36;
                    case 56: return 36;
                    case 57: return 36;
                    case 97: return 36;
                    case 98: return 36;
                    case 99: return 36;
                    case 100: return 36;
                    case 101: return 36;
                    case 102: return 36;
                    default: return -1;
                }
            case 28:
                switch (c)
                {
                    case 9: return 28;
                    case 10: return 28;
                    case 13: return 28;
                    case 32: return 28;
                    case 33: return 28;
                    case 34: return 28;
                    case 35: return 28;
                    case 36: return 37;
                    case 37: return 28;
                    case 38: return 28;
                    case 39: return 28;
                    case 40: return 28;
                    case 41: return 28;
                    case 42: return 28;
                    case 43: return 28;
                    case 44: return 28;
                    case 45: return 28;
                    case 46: return 28;
                    case 47: return 28;
                    case 48: return 28;
                    case 49: return 28;
                    case 50: return 28;
                    case 51: return 28;
                    case 52: return 28;
                    case 53: return 28;
                    case 54: return 28;
                    case 55: return 28;
                    case 56: return 28;
                    case 57: return 28;
                    case 58: return 28;
                    case 59: return 28;
                    case 60: return 28;
                    case 61: return 28;
                    case 62: return 28;
                    case 63: return 28;
                    case 64: return 28;
                    case 65: return 28;
                    case 66: return 28;
                    case 67: return 28;
                    case 68: return 28;
                    case 69: return 28;
                    case 70: return 28;
                    case 71: return 28;
                    case 72: return 28;
                    case 73: return 28;
                    case 74: return 28;
                    case 75: return 28;
                    case 76: return 28;
                    case 77: return 28;
                    case 78: return 28;
                    case 79: return 28;
                    case 80: return 28;
                    case 81: return 28;
                    case 82: return 28;
                    case 83: return 28;
                    case 84: return 28;
                    case 85: return 28;
                    case 86: return 28;
                    case 87: return 28;
                    case 88: return 28;
                    case 89: return 28;
                    case 90: return 28;
                    case 91: return 28;
                    case 92: return 38;
                    case 93: return 28;
                    case 94: return 28;
                    case 95: return 28;
                    case 96: return 28;
                    case 97: return 28;
                    case 98: return 28;
                    case 99: return 28;
                    case 100: return 28;
                    case 101: return 28;
                    case 102: return 28;
                    case 103: return 28;
                    case 104: return 28;
                    case 105: return 28;
                    case 106: return 28;
                    case 107: return 28;
                    case 108: return 28;
                    case 109: return 28;
                    case 110: return 28;
                    case 111: return 28;
                    case 112: return 28;
                    case 113: return 28;
                    case 114: return 28;
                    case 115: return 28;
                    case 116: return 28;
                    case 117: return 28;
                    case 118: return 28;
                    case 119: return 28;
                    case 120: return 28;
                    case 121: return 28;
                    case 122: return 28;
                    case 123: return 28;
                    case 124: return 28;
                    case 125: return 28;
                    case 126: return 28;
                    case 161: return 28;
                    case 162: return 28;
                    case 163: return 28;
                    case 164: return 28;
                    case 165: return 28;
                    case 166: return 28;
                    case 167: return 28;
                    case 168: return 28;
                    case 169: return 28;
                    case 170: return 28;
                    case 171: return 28;
                    case 172: return 28;
                    case 173: return 28;
                    case 174: return 28;
                    case 175: return 28;
                    case 176: return 28;
                    case 177: return 28;
                    case 178: return 28;
                    case 179: return 28;
                    case 180: return 28;
                    case 181: return 28;
                    case 182: return 28;
                    case 183: return 28;
                    case 184: return 28;
                    case 185: return 28;
                    case 186: return 28;
                    case 187: return 28;
                    case 188: return 28;
                    case 189: return 28;
                    case 190: return 28;
                    case 191: return 28;
                    case 192: return 28;
                    case 193: return 28;
                    case 194: return 28;
                    case 195: return 28;
                    case 196: return 28;
                    case 197: return 28;
                    case 198: return 28;
                    case 199: return 28;
                    case 200: return 28;
                    case 201: return 28;
                    case 202: return 28;
                    case 203: return 28;
                    case 204: return 28;
                    case 205: return 28;
                    case 206: return 28;
                    case 207: return 28;
                    case 208: return 28;
                    case 209: return 28;
                    case 210: return 28;
                    case 211: return 28;
                    case 212: return 28;
                    case 213: return 28;
                    case 214: return 28;
                    case 215: return 28;
                    case 216: return 28;
                    case 217: return 28;
                    case 218: return 28;
                    case 219: return 28;
                    case 220: return 28;
                    case 221: return 28;
                    case 222: return 28;
                    case 223: return 28;
                    case 224: return 28;
                    case 225: return 28;
                    case 226: return 28;
                    case 227: return 28;
                    case 228: return 28;
                    case 229: return 28;
                    case 230: return 28;
                    case 231: return 28;
                    case 232: return 28;
                    case 233: return 28;
                    case 234: return 28;
                    case 235: return 28;
                    case 236: return 28;
                    case 237: return 28;
                    case 238: return 28;
                    case 239: return 28;
                    case 240: return 28;
                    case 241: return 28;
                    case 242: return 28;
                    case 243: return 28;
                    case 244: return 28;
                    case 245: return 28;
                    case 246: return 28;
                    case 247: return 28;
                    case 248: return 28;
                    case 249: return 28;
                    case 250: return 28;
                    case 251: return 28;
                    case 252: return 28;
                    case 253: return 28;
                    case 254: return 28;
                    case 255: return 28;
                    default: return -1;
                }
            case 29:
                switch (c)
                {
                    case 9: return 29;
                    case 13: return 29;
                    case 32: return 29;
                    case 33: return 29;
                    case 34: return 29;
                    case 35: return 29;
                    case 36: return 29;
                    case 37: return 29;
                    case 38: return 29;
                    case 39: return 29;
                    case 40: return 29;
                    case 41: return 29;
                    case 42: return 29;
                    case 43: return 29;
                    case 44: return 29;
                    case 45: return 29;
                    case 46: return 29;
                    case 47: return 29;
                    case 48: return 29;
                    case 49: return 29;
                    case 50: return 29;
                    case 51: return 29;
                    case 52: return 29;
                    case 53: return 29;
                    case 54: return 29;
                    case 55: return 29;
                    case 56: return 29;
                    case 57: return 29;
                    case 58: return 29;
                    case 59: return 29;
                    case 60: return 29;
                    case 61: return 29;
                    case 62: return 29;
                    case 63: return 29;
                    case 64: return 29;
                    case 65: return 29;
                    case 66: return 29;
                    case 67: return 29;
                    case 68: return 29;
                    case 69: return 29;
                    case 70: return 29;
                    case 71: return 29;
                    case 72: return 29;
                    case 73: return 29;
                    case 74: return 29;
                    case 75: return 29;
                    case 76: return 29;
                    case 77: return 29;
                    case 78: return 29;
                    case 79: return 29;
                    case 80: return 29;
                    case 81: return 29;
                    case 82: return 29;
                    case 83: return 29;
                    case 84: return 29;
                    case 85: return 29;
                    case 86: return 29;
                    case 87: return 29;
                    case 88: return 29;
                    case 89: return 29;
                    case 90: return 29;
                    case 91: return 29;
                    case 92: return 29;
                    case 93: return 29;
                    case 94: return 29;
                    case 95: return 29;
                    case 96: return 29;
                    case 97: return 29;
                    case 98: return 29;
                    case 99: return 29;
                    case 100: return 29;
                    case 101: return 29;
                    case 102: return 29;
                    case 103: return 29;
                    case 104: return 29;
                    case 105: return 29;
                    case 106: return 29;
                    case 107: return 29;
                    case 108: return 29;
                    case 109: return 29;
                    case 110: return 29;
                    case 111: return 29;
                    case 112: return 29;
                    case 113: return 29;
                    case 114: return 29;
                    case 115: return 29;
                    case 116: return 29;
                    case 117: return 29;
                    case 118: return 29;
                    case 119: return 29;
                    case 120: return 29;
                    case 121: return 29;
                    case 122: return 29;
                    case 123: return 29;
                    case 124: return 29;
                    case 125: return 29;
                    case 126: return 29;
                    case 161: return 29;
                    case 162: return 29;
                    case 163: return 29;
                    case 164: return 29;
                    case 165: return 29;
                    case 166: return 29;
                    case 167: return 29;
                    case 168: return 29;
                    case 169: return 29;
                    case 170: return 29;
                    case 171: return 29;
                    case 172: return 29;
                    case 173: return 29;
                    case 174: return 29;
                    case 175: return 29;
                    case 176: return 29;
                    case 177: return 29;
                    case 178: return 29;
                    case 179: return 29;
                    case 180: return 29;
                    case 181: return 29;
                    case 182: return 29;
                    case 183: return 29;
                    case 184: return 29;
                    case 185: return 29;
                    case 186: return 29;
                    case 187: return 29;
                    case 188: return 29;
                    case 189: return 29;
                    case 190: return 29;
                    case 191: return 29;
                    case 192: return 29;
                    case 193: return 29;
                    case 194: return 29;
                    case 195: return 29;
                    case 196: return 29;
                    case 197: return 29;
                    case 198: return 29;
                    case 199: return 29;
                    case 200: return 29;
                    case 201: return 29;
                    case 202: return 29;
                    case 203: return 29;
                    case 204: return 29;
                    case 205: return 29;
                    case 206: return 29;
                    case 207: return 29;
                    case 208: return 29;
                    case 209: return 29;
                    case 210: return 29;
                    case 211: return 29;
                    case 212: return 29;
                    case 213: return 29;
                    case 214: return 29;
                    case 215: return 29;
                    case 216: return 29;
                    case 217: return 29;
                    case 218: return 29;
                    case 219: return 29;
                    case 220: return 29;
                    case 221: return 29;
                    case 222: return 29;
                    case 223: return 29;
                    case 224: return 29;
                    case 225: return 29;
                    case 226: return 29;
                    case 227: return 29;
                    case 228: return 29;
                    case 229: return 29;
                    case 230: return 29;
                    case 231: return 29;
                    case 232: return 29;
                    case 233: return 29;
                    case 234: return 29;
                    case 235: return 29;
                    case 236: return 29;
                    case 237: return 29;
                    case 238: return 29;
                    case 239: return 29;
                    case 240: return 29;
                    case 241: return 29;
                    case 242: return 29;
                    case 243: return 29;
                    case 244: return 29;
                    case 245: return 29;
                    case 246: return 29;
                    case 247: return 29;
                    case 248: return 29;
                    case 249: return 29;
                    case 250: return 29;
                    case 251: return 29;
                    case 252: return 29;
                    case 253: return 29;
                    case 254: return 29;
                    case 255: return 29;
                    default: return -1;
                }
            case 31:
                switch (c)
                {
                    case 48: return 39;
                    case 49: return 39;
                    case 50: return 39;
                    case 51: return 39;
                    case 52: return 39;
                    case 53: return 39;
                    case 54: return 39;
                    case 55: return 39;
                    case 56: return 39;
                    case 57: return 39;
                    default: return -1;
                }
            case 33:
                switch (c)
                {
                    case 48: return 33;
                    case 49: return 33;
                    case 50: return 33;
                    case 51: return 33;
                    case 52: return 33;
                    case 53: return 33;
                    case 54: return 33;
                    case 55: return 33;
                    case 56: return 33;
                    case 57: return 33;
                    case 65: return 33;
                    case 66: return 33;
                    case 67: return 33;
                    case 68: return 33;
                    case 69: return 33;
                    case 70: return 33;
                    case 71: return 33;
                    case 72: return 33;
                    case 73: return 33;
                    case 74: return 33;
                    case 75: return 33;
                    case 76: return 33;
                    case 77: return 33;
                    case 78: return 33;
                    case 79: return 33;
                    case 80: return 33;
                    case 81: return 33;
                    case 82: return 33;
                    case 83: return 33;
                    case 84: return 33;
                    case 85: return 33;
                    case 86: return 33;
                    case 87: return 33;
                    case 88: return 33;
                    case 89: return 33;
                    case 90: return 33;
                    case 91: return 33;
                    case 92: return 33;
                    case 93: return 33;
                    case 94: return 33;
                    case 95: return 34;
                    case 96: return 33;
                    case 97: return 33;
                    case 98: return 33;
                    case 99: return 33;
                    case 100: return 33;
                    case 101: return 33;
                    case 102: return 33;
                    case 103: return 33;
                    case 104: return 33;
                    case 105: return 33;
                    case 106: return 33;
                    case 107: return 33;
                    case 108: return 33;
                    case 109: return 33;
                    case 110: return 33;
                    case 111: return 33;
                    case 112: return 33;
                    case 113: return 33;
                    case 114: return 33;
                    case 115: return 33;
                    case 116: return 33;
                    case 117: return 33;
                    case 118: return 33;
                    case 119: return 33;
                    case 120: return 33;
                    case 121: return 33;
                    case 122: return 33;
                    default: return -1;
                }
            case 34:
                switch (c)
                {
                    case 48: return 33;
                    case 49: return 33;
                    case 50: return 33;
                    case 51: return 33;
                    case 52: return 33;
                    case 53: return 33;
                    case 54: return 33;
                    case 55: return 33;
                    case 56: return 33;
                    case 57: return 33;
                    case 65: return 33;
                    case 66: return 33;
                    case 67: return 33;
                    case 68: return 33;
                    case 69: return 33;
                    case 70: return 33;
                    case 71: return 33;
                    case 72: return 33;
                    case 73: return 33;
                    case 74: return 33;
                    case 75: return 33;
                    case 76: return 33;
                    case 77: return 33;
                    case 78: return 33;
                    case 79: return 33;
                    case 80: return 33;
                    case 81: return 33;
                    case 82: return 33;
                    case 83: return 33;
                    case 84: return 33;
                    case 85: return 33;
                    case 86: return 33;
                    case 87: return 33;
                    case 88: return 33;
                    case 89: return 33;
                    case 90: return 33;
                    case 91: return 33;
                    case 92: return 33;
                    case 93: return 33;
                    case 94: return 33;
                    case 95: return 34;
                    case 96: return 33;
                    case 97: return 33;
                    case 98: return 33;
                    case 99: return 33;
                    case 100: return 33;
                    case 101: return 33;
                    case 102: return 33;
                    case 103: return 33;
                    case 104: return 33;
                    case 105: return 33;
                    case 106: return 33;
                    case 107: return 33;
                    case 108: return 33;
                    case 109: return 33;
                    case 110: return 33;
                    case 111: return 33;
                    case 112: return 33;
                    case 113: return 33;
                    case 114: return 33;
                    case 115: return 33;
                    case 116: return 33;
                    case 117: return 33;
                    case 118: return 33;
                    case 119: return 33;
                    case 120: return 33;
                    case 121: return 33;
                    case 122: return 33;
                    default: return -1;
                }
            case 35:
                switch (c)
                {
                    case 48: return 35;
                    case 49: return 35;
                    default: return -1;
                }
            case 36:
                switch (c)
                {
                    case 48: return 36;
                    case 49: return 36;
                    case 50: return 36;
                    case 51: return 36;
                    case 52: return 36;
                    case 53: return 36;
                    case 54: return 36;
                    case 55: return 36;
                    case 56: return 36;
                    case 57: return 36;
                    case 97: return 36;
                    case 98: return 36;
                    case 99: return 36;
                    case 100: return 36;
                    case 101: return 36;
                    case 102: return 36;
                    default: return -1;
                }
            case 38:
                switch (c)
                {
                    case 9: return 28;
                    case 10: return 28;
                    case 13: return 28;
                    case 32: return 28;
                    case 33: return 28;
                    case 34: return 28;
                    case 35: return 28;
                    case 36: return 40;
                    case 37: return 28;
                    case 38: return 28;
                    case 39: return 28;
                    case 40: return 28;
                    case 41: return 28;
                    case 42: return 28;
                    case 43: return 28;
                    case 44: return 28;
                    case 45: return 28;
                    case 46: return 28;
                    case 47: return 28;
                    case 48: return 28;
                    case 49: return 28;
                    case 50: return 28;
                    case 51: return 28;
                    case 52: return 28;
                    case 53: return 28;
                    case 54: return 28;
                    case 55: return 28;
                    case 56: return 28;
                    case 57: return 28;
                    case 58: return 28;
                    case 59: return 28;
                    case 60: return 28;
                    case 61: return 28;
                    case 62: return 28;
                    case 63: return 28;
                    case 64: return 28;
                    case 65: return 28;
                    case 66: return 28;
                    case 67: return 28;
                    case 68: return 28;
                    case 69: return 28;
                    case 70: return 28;
                    case 71: return 28;
                    case 72: return 28;
                    case 73: return 28;
                    case 74: return 28;
                    case 75: return 28;
                    case 76: return 28;
                    case 77: return 28;
                    case 78: return 28;
                    case 79: return 28;
                    case 80: return 28;
                    case 81: return 28;
                    case 82: return 28;
                    case 83: return 28;
                    case 84: return 28;
                    case 85: return 28;
                    case 86: return 28;
                    case 87: return 28;
                    case 88: return 28;
                    case 89: return 28;
                    case 90: return 28;
                    case 91: return 28;
                    case 92: return 38;
                    case 93: return 28;
                    case 94: return 28;
                    case 95: return 28;
                    case 96: return 28;
                    case 97: return 28;
                    case 98: return 28;
                    case 99: return 28;
                    case 100: return 28;
                    case 101: return 28;
                    case 102: return 28;
                    case 103: return 28;
                    case 104: return 28;
                    case 105: return 28;
                    case 106: return 28;
                    case 107: return 28;
                    case 108: return 28;
                    case 109: return 28;
                    case 110: return 28;
                    case 111: return 28;
                    case 112: return 28;
                    case 113: return 28;
                    case 114: return 28;
                    case 115: return 28;
                    case 116: return 28;
                    case 117: return 28;
                    case 118: return 28;
                    case 119: return 28;
                    case 120: return 28;
                    case 121: return 28;
                    case 122: return 28;
                    case 123: return 28;
                    case 124: return 28;
                    case 125: return 28;
                    case 126: return 28;
                    case 161: return 28;
                    case 162: return 28;
                    case 163: return 28;
                    case 164: return 28;
                    case 165: return 28;
                    case 166: return 28;
                    case 167: return 28;
                    case 168: return 28;
                    case 169: return 28;
                    case 170: return 28;
                    case 171: return 28;
                    case 172: return 28;
                    case 173: return 28;
                    case 174: return 28;
                    case 175: return 28;
                    case 176: return 28;
                    case 177: return 28;
                    case 178: return 28;
                    case 179: return 28;
                    case 180: return 28;
                    case 181: return 28;
                    case 182: return 28;
                    case 183: return 28;
                    case 184: return 28;
                    case 185: return 28;
                    case 186: return 28;
                    case 187: return 28;
                    case 188: return 28;
                    case 189: return 28;
                    case 190: return 28;
                    case 191: return 28;
                    case 192: return 28;
                    case 193: return 28;
                    case 194: return 28;
                    case 195: return 28;
                    case 196: return 28;
                    case 197: return 28;
                    case 198: return 28;
                    case 199: return 28;
                    case 200: return 28;
                    case 201: return 28;
                    case 202: return 28;
                    case 203: return 28;
                    case 204: return 28;
                    case 205: return 28;
                    case 206: return 28;
                    case 207: return 28;
                    case 208: return 28;
                    case 209: return 28;
                    case 210: return 28;
                    case 211: return 28;
                    case 212: return 28;
                    case 213: return 28;
                    case 214: return 28;
                    case 215: return 28;
                    case 216: return 28;
                    case 217: return 28;
                    case 218: return 28;
                    case 219: return 28;
                    case 220: return 28;
                    case 221: return 28;
                    case 222: return 28;
                    case 223: return 28;
                    case 224: return 28;
                    case 225: return 28;
                    case 226: return 28;
                    case 227: return 28;
                    case 228: return 28;
                    case 229: return 28;
                    case 230: return 28;
                    case 231: return 28;
                    case 232: return 28;
                    case 233: return 28;
                    case 234: return 28;
                    case 235: return 28;
                    case 236: return 28;
                    case 237: return 28;
                    case 238: return 28;
                    case 239: return 28;
                    case 240: return 28;
                    case 241: return 28;
                    case 242: return 28;
                    case 243: return 28;
                    case 244: return 28;
                    case 245: return 28;
                    case 246: return 28;
                    case 247: return 28;
                    case 248: return 28;
                    case 249: return 28;
                    case 250: return 28;
                    case 251: return 28;
                    case 252: return 28;
                    case 253: return 28;
                    case 254: return 28;
                    case 255: return 28;
                    default: return -1;
                }
            case 39:
                switch (c)
                {
                    case 48: return 41;
                    case 49: return 39;
                    case 50: return 39;
                    case 51: return 39;
                    case 52: return 39;
                    case 53: return 39;
                    case 54: return 39;
                    case 55: return 39;
                    case 56: return 39;
                    case 57: return 39;
                    default: return -1;
                }
            case 40:
                switch (c)
                {
                    case 9: return 28;
                    case 10: return 28;
                    case 13: return 28;
                    case 32: return 28;
                    case 33: return 28;
                    case 34: return 28;
                    case 35: return 28;
                    case 36: return 37;
                    case 37: return 28;
                    case 38: return 28;
                    case 39: return 28;
                    case 40: return 28;
                    case 41: return 28;
                    case 42: return 28;
                    case 43: return 28;
                    case 44: return 28;
                    case 45: return 28;
                    case 46: return 28;
                    case 47: return 28;
                    case 48: return 28;
                    case 49: return 28;
                    case 50: return 28;
                    case 51: return 28;
                    case 52: return 28;
                    case 53: return 28;
                    case 54: return 28;
                    case 55: return 28;
                    case 56: return 28;
                    case 57: return 28;
                    case 58: return 28;
                    case 59: return 28;
                    case 60: return 28;
                    case 61: return 28;
                    case 62: return 28;
                    case 63: return 28;
                    case 64: return 28;
                    case 65: return 28;
                    case 66: return 28;
                    case 67: return 28;
                    case 68: return 28;
                    case 69: return 28;
                    case 70: return 28;
                    case 71: return 28;
                    case 72: return 28;
                    case 73: return 28;
                    case 74: return 28;
                    case 75: return 28;
                    case 76: return 28;
                    case 77: return 28;
                    case 78: return 28;
                    case 79: return 28;
                    case 80: return 28;
                    case 81: return 28;
                    case 82: return 28;
                    case 83: return 28;
                    case 84: return 28;
                    case 85: return 28;
                    case 86: return 28;
                    case 87: return 28;
                    case 88: return 28;
                    case 89: return 28;
                    case 90: return 28;
                    case 91: return 28;
                    case 92: return 38;
                    case 93: return 28;
                    case 94: return 28;
                    case 95: return 28;
                    case 96: return 28;
                    case 97: return 28;
                    case 98: return 28;
                    case 99: return 28;
                    case 100: return 28;
                    case 101: return 28;
                    case 102: return 28;
                    case 103: return 28;
                    case 104: return 28;
                    case 105: return 28;
                    case 106: return 28;
                    case 107: return 28;
                    case 108: return 28;
                    case 109: return 28;
                    case 110: return 28;
                    case 111: return 28;
                    case 112: return 28;
                    case 113: return 28;
                    case 114: return 28;
                    case 115: return 28;
                    case 116: return 28;
                    case 117: return 28;
                    case 118: return 28;
                    case 119: return 28;
                    case 120: return 28;
                    case 121: return 28;
                    case 122: return 28;
                    case 123: return 28;
                    case 124: return 28;
                    case 125: return 28;
                    case 126: return 28;
                    case 161: return 28;
                    case 162: return 28;
                    case 163: return 28;
                    case 164: return 28;
                    case 165: return 28;
                    case 166: return 28;
                    case 167: return 28;
                    case 168: return 28;
                    case 169: return 28;
                    case 170: return 28;
                    case 171: return 28;
                    case 172: return 28;
                    case 173: return 28;
                    case 174: return 28;
                    case 175: return 28;
                    case 176: return 28;
                    case 177: return 28;
                    case 178: return 28;
                    case 179: return 28;
                    case 180: return 28;
                    case 181: return 28;
                    case 182: return 28;
                    case 183: return 28;
                    case 184: return 28;
                    case 185: return 28;
                    case 186: return 28;
                    case 187: return 28;
                    case 188: return 28;
                    case 189: return 28;
                    case 190: return 28;
                    case 191: return 28;
                    case 192: return 28;
                    case 193: return 28;
                    case 194: return 28;
                    case 195: return 28;
                    case 196: return 28;
                    case 197: return 28;
                    case 198: return 28;
                    case 199: return 28;
                    case 200: return 28;
                    case 201: return 28;
                    case 202: return 28;
                    case 203: return 28;
                    case 204: return 28;
                    case 205: return 28;
                    case 206: return 28;
                    case 207: return 28;
                    case 208: return 28;
                    case 209: return 28;
                    case 210: return 28;
                    case 211: return 28;
                    case 212: return 28;
                    case 213: return 28;
                    case 214: return 28;
                    case 215: return 28;
                    case 216: return 28;
                    case 217: return 28;
                    case 218: return 28;
                    case 219: return 28;
                    case 220: return 28;
                    case 221: return 28;
                    case 222: return 28;
                    case 223: return 28;
                    case 224: return 28;
                    case 225: return 28;
                    case 226: return 28;
                    case 227: return 28;
                    case 228: return 28;
                    case 229: return 28;
                    case 230: return 28;
                    case 231: return 28;
                    case 232: return 28;
                    case 233: return 28;
                    case 234: return 28;
                    case 235: return 28;
                    case 236: return 28;
                    case 237: return 28;
                    case 238: return 28;
                    case 239: return 28;
                    case 240: return 28;
                    case 241: return 28;
                    case 242: return 28;
                    case 243: return 28;
                    case 244: return 28;
                    case 245: return 28;
                    case 246: return 28;
                    case 247: return 28;
                    case 248: return 28;
                    case 249: return 28;
                    case 250: return 28;
                    case 251: return 28;
                    case 252: return 28;
                    case 253: return 28;
                    case 254: return 28;
                    case 255: return 28;
                    default: return -1;
                }
            case 41:
                switch (c)
                {
                    case 48: return 41;
                    case 49: return 39;
                    case 50: return 39;
                    case 51: return 39;
                    case 52: return 39;
                    case 53: return 39;
                    case 54: return 39;
                    case 55: return 39;
                    case 56: return 39;
                    case 57: return 39;
                    default: return -1;
                }
            default: return -1;
        }
    }

    private int tokenForState(int state)
    {
        if (state < 0 || state >= TOKEN_STATE.length)
            return -1;

        return TOKEN_STATE[state];
    }

    public int lookupToken(int base, String key)
    {
        int start = SPECIAL_CASES_INDEXES[base];
        int end   = SPECIAL_CASES_INDEXES[base+1]-1;

        while (start <= end)
        {
            int half = (start+end)/2;
            int comp = SPECIAL_CASES_KEYS[half].compareTo(key);

            if (comp == 0)
                return SPECIAL_CASES_VALUES[half];
            else if (comp < 0)
                start = half+1;
            else  //(comp > 0)
                end = half-1;
        }

        return base;
    }

    private boolean hasInput()
    {
        return position < input.length();
    }

    private char nextChar()
    {
        if (hasInput())
            return input.charAt(position++);
        else
            return (char) -1;
    }
}
