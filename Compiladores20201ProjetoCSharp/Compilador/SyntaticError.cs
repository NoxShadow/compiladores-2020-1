public class SyntaticError : AnalysisError
{
    public SyntaticError(string msg, int position)
    {
        super(msg, position);
    }

    public SyntaticError(string msg)
    {
        super(msg);
    }
}
