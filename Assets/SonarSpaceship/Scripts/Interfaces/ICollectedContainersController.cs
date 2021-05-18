using UnityTranslator.Objects;

namespace SonarSpaceship
{
    public interface ICollectedContainersController
    {
        string CollectedContainersTextFormat { get; set; }

        StringTranslationObjectScript CollectedContainersTextFormatStringTranslation { get; set; }

        uint CurrentContainerCount { get; }

        uint MaximalContainerCount { get; }

        uint CollectedContainerCount { get; }

        event CollectedContainersTextChangedDelegate OnCollectedContainersTextChanged;
    }
}
