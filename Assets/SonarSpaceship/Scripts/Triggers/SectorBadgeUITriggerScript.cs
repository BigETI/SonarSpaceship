using SonarSpaceship.Controllers;
using SonarSpaceship.Objects;
using UnityEngine;

namespace SonarSpaceship.Triggers
{
    public class SectorBadgeUITriggerScript : MonoBehaviour, ISectorBadgeUITrigger
    {
        [SerializeField]
        private SectorObjectScript sector = default;

        public SectorObjectScript Sector
        {
            get => sector;
            set => sector = value;
        }

        private void Start()
        {
            bool is_destroying_itself = true;
            if (sector && GetComponentInParent<ProfileSelectionUIControllerScript>() is ProfileSelectionUIControllerScript profile_selection_ui_controller)
            {
                IProfile profile = profile_selection_ui_controller.Profile;
                if (profile != null)
                {
                    is_destroying_itself = false;
                    foreach (LevelObjectScript level in sector.Levels)
                    {
                        if (level)
                        {
                            if (!profile.IsLevelFinished(level))
                            {
                                is_destroying_itself = true;
                                break;
                            }
                        }
                        else
                        {
                            Debug.LogError($"Level entry in sector \"{ sector.name }\" is null.");
                        }
                    }
                }
            }
            if (is_destroying_itself)
            {
                Destroy(gameObject);
            }
        }
    }
}
