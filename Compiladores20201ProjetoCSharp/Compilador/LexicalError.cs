public class LexicalError : AnalysisError
{
    public LexicalError(string msg, int position)
    {
        super(msg, position);
    }

    public LexicalError(string msg)
    {
        super(msg);
    }
}
