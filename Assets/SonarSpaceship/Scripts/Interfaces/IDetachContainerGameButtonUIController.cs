namespace SonarSpaceship
{
    public interface IDetachContainerGameButtonUIController : IGameButtonUIController
    {
        bool IsAContainerAttachedToAnySpaceship { get; }
    }
}
