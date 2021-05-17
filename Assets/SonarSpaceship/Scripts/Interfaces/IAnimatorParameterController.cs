using UnityEngine;

namespace SonarSpaceship
{
    public interface IAnimatorParameterController : IBehaviour
    {
        string ParameterName { get; set; }

        Animator ParameterAnimator { get; set; }

        int ParameterNameHash { get; }

        void SetBoolean(bool value);

        void SetInteger(int value);

        void SetFloat(float value);

        void SetTrigger();
    }
}
