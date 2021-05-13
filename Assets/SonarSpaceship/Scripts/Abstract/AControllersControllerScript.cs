using System.Collections.Generic;
using UnityEngine;

namespace SonarSpaceship.Controllers
{
    public abstract class AControllersControllerScript<T> : MonoBehaviour, IControllersController where T : AControllersControllerScript<T>
    {
        private static readonly List<T> controllers = new List<T>();

        private static readonly List<T> enabledControllers = new List<T>();

        public static IEnumerable<T> Controllers => controllers;

        public static IEnumerable<T> EnabledControllers => enabledControllers;

        protected virtual void Awake() => controllers.Add((T)this);

        protected virtual void OnDestroy() => controllers.Remove((T)this);

        protected virtual void OnEnable() => enabledControllers.Add((T)this);

        protected virtual void OnDisable() => enabledControllers.Remove((T)this);
    }
}
