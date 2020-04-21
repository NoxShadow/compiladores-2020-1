
namespace Compiladores20201ProjetoCSharp.Compilador
{
    public class Token
    {
        public int id { get; private set; }
        public string lexeme { get; private set; }
        public int position { get; private set; }


        public Token(int idd, string lexemee, int positionn)
        {
            id = idd;
            lexeme = lexemee;
            position = positionn;
        }

        override
        public string ToString()
        {
            return id + " ( " + lexeme + " ) @ " + position;
        }
    }
}