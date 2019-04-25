namespace AOP.Aspect.Interface
{
    public interface IAfterAspect : IAspect
    {
        object OnAfter(object value);
    }
}
