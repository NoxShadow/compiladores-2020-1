public class SemanticError : AnalysisError
{
    public SemanticError(string msg, int position)
    {
        super(msg, position);
    }

    public SemanticError(string msg)
    {
        super(msg);
    }
}
