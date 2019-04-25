namespace AOP.Aspect.Interface
{
    interface IBeforeAspect : IAspect
    {
        object OnBefore();
    }
}
