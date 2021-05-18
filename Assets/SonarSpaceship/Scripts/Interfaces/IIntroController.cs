namespace SonarSpaceship
{
    public interface IIntroController : IBehaviour
    {
        event StartedDelegate OnStarted;

        void ShowMainMenu();
    }
}
