using System;
using UnityEngine;

namespace SonarSpaceship.Controllers
{
    public class AnimatorParameterControllerScript : MonoBehaviour, IAnimatorParameterController
    {
        [SerializeField]
        private string parameterName = string.Empty;

        [SerializeField]
        private Animator parameterAnimator = default;

        private int parameterNameHash = Animator.StringToHash(string.Empty);

        private string lastParameterName = string.Empty;

        public string ParameterName
        {
            get => parameterName ?? string.Empty;
            set => parameterName = value ?? throw new ArgumentNullException();
        }

        public Animator ParameterAnimator
        {
            get => parameterAnimator;
            set
            {
                parameterAnimator = value;
            }
        }

        public int ParameterNameHash
        {
            get
            {
                string parameter_name = ParameterName;
                if (lastParameterName != parameter_name)
                {
                    parameterNameHash = Animator.StringToHash(parameter_name);
                    lastParameterName = parameter_name;
                }
                return parameterNameHash;
            }
        }

        public void SetBoolean(bool value)
        {
            if (parameterAnimator)
            {
                parameterAnimator.SetBool(ParameterNameHash, value);
            }
        }

        public void SetInteger(int value)
        {
            if (parameterAnimator)
            {
                parameterAnimator.SetInteger(ParameterNameHash, value);
            }
        }

        public void SetFloat(float value)
        {
            if (parameterAnimator)
            {
                parameterAnimator.SetFloat(ParameterNameHash, value);
            }
        }

        public void SetTrigger()
        {
            if (parameterAnimator)
            {
                parameterAnimator.SetTrigger(ParameterNameHash);
            }
        }
    }
}
