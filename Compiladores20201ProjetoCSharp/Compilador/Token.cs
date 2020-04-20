public class Token
{
    private int id;
    private string lexeme;
    private int position;

    public Token(int id, string lexeme, int position)
    {
        this.id = id;
        this.lexeme = lexeme;
        this.position = position;
    }

    public final int getId()
    {
        return id;
    }

    public final string getLexeme()
    {
        return lexeme;
    }

    public final int getPosition()
    {
        return position;
    }

    public string toString()
    {
        return id + " ( " + lexeme + " ) @ " + position;
    };
}
