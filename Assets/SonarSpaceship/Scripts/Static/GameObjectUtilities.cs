using System;
using UnityEngine;

namespace SonarSpaceship
{
    public static class GameObjectUtilities
    {
        public static bool IsGameObjectChildOfGameObject(MonoBehaviour child, MonoBehaviour parent)
        {
            if (!child)
            {
                throw new ArgumentNullException(nameof(child));
            }
            if (!parent)
            {
                throw new ArgumentNullException(nameof(parent));
            }
            bool ret = false;
            Transform current_transform = child.transform;
            while (current_transform)
            {
                if (current_transform.gameObject.GetInstanceID() == parent.gameObject.GetInstanceID())
                {
                    ret = true;
                    break;
                }
                current_transform = current_transform.parent;
            }
            return ret;
        }
    }
}
