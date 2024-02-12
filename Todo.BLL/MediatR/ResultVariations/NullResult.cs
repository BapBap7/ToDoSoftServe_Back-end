using FluentResults;

namespace Todo.BLL.MediatR.ResultVariations;

public class NullResult<T> : Result<T>
{
    public NullResult() : base()
    {
        
    }
}