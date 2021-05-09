using TMPro;
using UnityTranslator.Objects;

namespace SonarSpaceship
{
    public interface IProfileSelectionUIController : IBehaviour
    {
        byte ProfileIndex { get; set; }

        StringTranslationObjectScript DeleteProfileTitleStringTranslation { get; set; }

        StringTranslationObjectScript DeleteProfileMessageStringTranslation { get; set; }

        TextMeshProUGUI NameText { get; set; }

        IProfile Profile { get; }

        event ProfileNameRequestedDelegate OnProfileNameRequested;

        event ProfileDeletionRequestedDelegate OnProfileDeletionRequested;

        event ProfileDeletedDelegate OnProfileDeleted;

        void SelectProfile();
    }
}
