using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public static class GameObjectExtenxion
    {
        public static T GetOrAdd<T>(this GameObject gameObject) where T : Component
        {
            T component = gameObject.GetComponent<T>();
            return component != null ? component : gameObject.AddComponent<T>();
        }
    }
}
