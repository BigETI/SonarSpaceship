using UnityEngine;

namespace SonarSpaceship.Triggers
{
    /// <summary>
    /// A class that describes a trigger that enables V-Sync
    /// </summary>
    public class EnableVSyncSettingsTriggerScript : MonoBehaviour, IEnableVSyncSettingsTrigger
    {
        /// <summary>
        /// Gets invoked when script has been started
        /// </summary>
        private void Start()
        {
            QualitySettings.vSyncCount = 1;
            Destroy(gameObject);
        }
    }
}
