namespace AOP.Aspect.Interface
{
    public interface IAfterVoidAspect : IAspect
    {
        void OnAfter(object value);
    }
}
