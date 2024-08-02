﻿using UnityEngine;

namespace LearnXR.Core
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    var objs = FindObjectsOfType(typeof(T), includeInactive: true) as T[];
                    if (objs is { Length: > 0 })
                        instance = objs[0];
                    if (objs is { Length: > 1 })
                    {
                        Debug.LogError($"There is more than one {typeof(T).Name} in the scene.");
                    }
                    if (instance == null)
                    {
                        GameObject obj = new GameObject
                        {
                            name = $"_{typeof(T).Name}"
                        };
                        instance = obj.AddComponent<T>();
                    }
                }
                return instance;
            }
        }
    }
}