using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnitySceneLoaderManager;

namespace SonarSpaceship.Controllers
{
    public class ProfileNameInputFieldUIControllerScript : MonoBehaviour, IProfileNameInputFieldUIController
    {
        [SerializeField]
        private TMP_InputField profileNameInputField = default;

        [SerializeField]
        private UnityEvent onProfileNameInputFailed = default;

        [SerializeField]
        private UnityEvent onProfileNameInputSucceeded = default;

        public TMP_InputField ProfileNameInputField
        {
            get => profileNameInputField;
            set => profileNameInputField = value;
        }

        public event ProfileNameInputFailedDelegate OnProfileNameInputFailed;

        public event ProfileNameInputSucceededDelegate OnProfileNameInputSucceeded;

        private void InvokeProfileNameInputFailedEvent()
        {
            if (onProfileNameInputFailed != null)
            {
                onProfileNameInputFailed.Invoke();
            }
            OnProfileNameInputFailed?.Invoke();
        }

        public void CreateNewProfile()
        {
            if (profileNameInputField)
            {
                string profile_name = profileNameInputField.text.Trim();
                if (string.IsNullOrEmpty(profile_name))
                {
                    InvokeProfileNameInputFailedEvent();
                }
                else
                {
                    Profiles.CreateNewProfile(GameManager.SelectedProfileIndex, profile_name);
                    GameManager.ReloadSelectedProfile();
                    if (onProfileNameInputSucceeded != null)
                    {
                        onProfileNameInputSucceeded.Invoke();
                    }
                    OnProfileNameInputSucceeded?.Invoke(profile_name);
                    SceneLoaderManager.LoadScenes("LevelSelectionMenuScene");
                }
            }
            else
            {
                InvokeProfileNameInputFailedEvent();
            }
        }
    }
}
