namespace SonarSpaceship
{
    public interface IContainerController : IBehaviour
    {
        float Weight { get; set; }

        event AttachedDelegate OnAttached;

        event DetachedDelegate OnDetached;

        void InvokeAttachedEvent();

        void InvokeDetachedEvent();
    }
}
