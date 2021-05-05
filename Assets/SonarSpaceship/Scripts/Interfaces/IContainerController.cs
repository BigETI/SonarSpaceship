namespace SonarSpaceship
{
    public interface IContainerController : IBehaviour
    {
        event AttachedDelegate OnAttached;

        event DetachedDelegate OnDetached;

        void InvokeAttachedEvent();

        void InvokeDetachedEvent();
    }
}
