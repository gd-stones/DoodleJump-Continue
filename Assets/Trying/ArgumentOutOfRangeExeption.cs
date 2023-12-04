using System;
using System.Runtime.Serialization;

[Serializable]
internal class ArgumentOutOfRangeExeption : Exception
{
    private string v;
    private GameState newState;
    private object value;

    public ArgumentOutOfRangeExeption()
    {
    }

    public ArgumentOutOfRangeExeption(string message, GameStateX newState) : base(message)
    {
    }

    public ArgumentOutOfRangeExeption(string message, Exception innerException) : base(message, innerException)
    {
    }

    public ArgumentOutOfRangeExeption(string v, GameState newState, object value)
    {
        this.v = v;
        this.newState = newState;
        this.value = value;
    }

    protected ArgumentOutOfRangeExeption(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}