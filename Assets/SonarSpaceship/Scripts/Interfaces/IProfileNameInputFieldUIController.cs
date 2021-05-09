using TMPro;

namespace SonarSpaceship
{
    public interface IProfileNameInputFieldUIController : IBehaviour
    {
        TMP_InputField ProfileNameInputField { get; set; }

        event ProfileNameInputFailedDelegate OnProfileNameInputFailed;

        event ProfileNameInputSucceededDelegate OnProfileNameInputSucceeded;

        void CreateNewProfile();
    }
}
