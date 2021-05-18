namespace SonarSpaceship
{
    public interface IContainerController : IControllersController
    {
        float Weight { get; set; }

        event AttachedDelegate OnAttached;

        event DetachedDelegate OnDetached;

        void InvokeAttachedEvent();

        void InvokeDetachedEvent();
    }
}
