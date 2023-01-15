using System.Runtime.Serialization;

[Serializable]
internal class SandGoingToVoidException : Exception
{
    public SandGoingToVoidException()
    {
    }

    public SandGoingToVoidException(string? message) : base(message)
    {
    }

    public SandGoingToVoidException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected SandGoingToVoidException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
