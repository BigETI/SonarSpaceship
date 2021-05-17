using UnityEngine;

namespace SonarSpaceship.Triggers
{
    public class MobileTriggerScript : MonoBehaviour, IMobileTrigger
    {
#if !UNITY_EDITOR
    private void Awake() => Destroy(Application.isMobilePlatform ? (Object)this : gameObject);
#endif
    }
}
