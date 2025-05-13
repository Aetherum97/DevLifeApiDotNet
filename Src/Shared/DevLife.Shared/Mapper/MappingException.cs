
namespace DevLife.Shared.Mapper
{
    public class MappingException : Exception
    {
        public MappingException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
