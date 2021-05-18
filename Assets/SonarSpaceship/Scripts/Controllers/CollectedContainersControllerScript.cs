using System;
using UnityEngine;
using UnityEngine.Events;
using UnityTranslator.Objects;

namespace SonarSpaceship.Controllers
{
    public class CollectedContainersControllerScript : MonoBehaviour, ICollectedContainersController
    {
        private static readonly string defaultCollectedContainersTextFormat = "{0}/{1}";

        [SerializeField]
        private string collectedContainersTextFormat = defaultCollectedContainersTextFormat;

        [SerializeField]
        private StringTranslationObjectScript collectedContainersTextFormatStringTranslation = default;

        [SerializeField]
        private UnityEvent<string> onCollectedContainersTextChanged = default;

        public string CollectedContainersTextFormat
        {
            get => collectedContainersTextFormat ?? defaultCollectedContainersTextFormat;
            set => collectedContainersTextFormat = value ?? throw new ArgumentNullException(nameof(value));
        }

        public StringTranslationObjectScript CollectedContainersTextFormatStringTranslation
        {
            get => collectedContainersTextFormatStringTranslation;
            set => collectedContainersTextFormatStringTranslation = value;
        }

        public uint CurrentContainerCount { get; private set; }

        public uint MaximalContainerCount { get; private set; }

        public uint CollectedContainerCount => MaximalContainerCount - CurrentContainerCount;

        public event CollectedContainersTextChangedDelegate OnCollectedContainersTextChanged;

        private void Update()
        {
            bool is_updating_text = false;
            uint controller_count = ContainerControllerScript.EnabledControllerCount;
            if (CurrentContainerCount != controller_count)
            {
                CurrentContainerCount = controller_count;
                is_updating_text = true;
            }
            if (MaximalContainerCount < controller_count)
            {
                MaximalContainerCount = controller_count;
                is_updating_text = true;
            }
            if (is_updating_text)
            {
                string containers_collected_text = string.Format(collectedContainersTextFormatStringTranslation ? collectedContainersTextFormatStringTranslation.ToString() : CollectedContainersTextFormat, CollectedContainerCount, MaximalContainerCount);
                if (onCollectedContainersTextChanged != null)
                {
                    onCollectedContainersTextChanged.Invoke(containers_collected_text);
                }
                OnCollectedContainersTextChanged?.Invoke(containers_collected_text);
            }
        }

#if UNITY_EDITOR
        private void OnValidate() => collectedContainersTextFormat = collectedContainersTextFormatStringTranslation ? collectedContainersTextFormatStringTranslation.ToString() : CollectedContainersTextFormat;
#endif
    }
}
