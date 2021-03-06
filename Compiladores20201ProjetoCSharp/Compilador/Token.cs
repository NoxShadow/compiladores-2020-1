namespace Compiladores20201ProjetoCSharp.Compilador
{
    public class Token
    {
        public int Id { get; private set; }
        public string Lexeme { get; private set; }
        public int Line { get; private set; }
        public int Position { get; private set; }

        public Token(int id, string lexeme, int line, int position)
        {
            Id = id;
            Lexeme = lexeme;
            Line = line;
            Position = position;
        }

        override public string ToString()
        {
            return Id + " ( " + Lexeme + " ) @ " + Line;
        }
    }
}