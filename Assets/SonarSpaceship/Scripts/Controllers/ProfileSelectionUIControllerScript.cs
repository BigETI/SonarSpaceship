using SonarSpaceship.Data;
using TMPro;
using UnityDialog;
using UnityEngine;
using UnityEngine.Events;
using UnitySaveGame;
using UnitySceneLoaderManager;
using UnityTranslator.Objects;

namespace SonarSpaceship.Controllers
{
    public class ProfileSelectionUIControllerScript : MonoBehaviour, IProfileSelectionUIController
    {
        [SerializeField]
        private byte profileIndex;

        [SerializeField]
        private StringTranslationObjectScript deleteProfileTitleStringTranslation = default;

        [SerializeField]
        private StringTranslationObjectScript deleteProfileMessageStringTranslation = default;

        [SerializeField]
        private TextMeshProUGUI nameText = default;

        [SerializeField]
        private UnityEvent onProfileNameRequested = default;

        [SerializeField]
        private UnityEvent onProfileSelected = default;

        [SerializeField]
        private UnityEvent onProfileDeletionRequested = default;

        [SerializeField]
        private UnityEvent onProfileDeleted = default;

        private IProfile profile;

        public byte ProfileIndex
        {
            get => profileIndex;
            set => profileIndex = value;
        }

        public StringTranslationObjectScript DeleteProfileTitleStringTranslation
        {
            get => deleteProfileTitleStringTranslation;
            set => deleteProfileTitleStringTranslation = value;
        }

        public StringTranslationObjectScript DeleteProfileMessageStringTranslation
        {
            get => deleteProfileMessageStringTranslation;
            set => deleteProfileMessageStringTranslation = value;
        }

        public TextMeshProUGUI NameText
        {
            get => nameText;
            set => nameText = value;
        }

        public IProfile Profile => profile ??= Profiles.LoadProfile(profileIndex);

        public event ProfileNameRequestedDelegate OnProfileNameRequested;

        public event ProfileSelectedDelegate OnProfileSelected;

        public event ProfileDeletionRequestedDelegate OnProfileDeletionRequested;

        public event ProfileDeletedDelegate OnProfileDeleted;

        public void SelectProfile()
        {
            GameManager.SelectedProfileIndex = profileIndex;
            if (Profiles.IsProfileAvailable(profileIndex))
            {
                if (onProfileSelected != null)
                {
                    onProfileSelected.Invoke();
                }
                OnProfileSelected?.Invoke(profileIndex);
                SceneLoaderManager.LoadScenes("LevelSelectionMenuScene");
            }
            else
            {
                if (onProfileNameRequested != null)
                {
                    onProfileNameRequested.Invoke();
                }
                OnProfileNameRequested?.Invoke(profileIndex);
            }
        }

        public void RequestProfileDeletion()
        {
            if (Profiles.IsProfileAvailable(profileIndex))
            {
                Dialogs.Show
                (
                    deleteProfileTitleStringTranslation ? deleteProfileTitleStringTranslation.ToString() : string.Empty,
                    deleteProfileMessageStringTranslation ? deleteProfileMessageStringTranslation.ToString() : string.Empty,
                    EDialogType.Warning,
                    EDialogButtons.YesNo,
                    (response, _) =>
                    {
                        if (response == EDialogResponse.Yes)
                        {
                            Profiles.RemoveProfile(profileIndex);
                            GameManager.ReloadSelectedProfile();
                            SaveGames.Get<SaveGameData>().Save();
                            SceneLoaderManager.LoadScenes("MainMenuScene");
                            if (onProfileDeleted != null)
                            {
                                onProfileDeleted.Invoke();
                            }
                            OnProfileDeleted?.Invoke(profileIndex);
                        }
                    }
                );
                if (onProfileDeletionRequested != null)
                {
                    onProfileDeletionRequested.Invoke();
                }
                OnProfileDeletionRequested?.Invoke(profileIndex);
            }
        }

        private void Start()
        {
            if (nameText)
            {
                if (Profile != null)
                {
                    nameText.text = profile.Name;
                }
            }
            else
            {
                Debug.LogError("Please assign a name text component to this game object.", this);
            }
        }
    }
}
