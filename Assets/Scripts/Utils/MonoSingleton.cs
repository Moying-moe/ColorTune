using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : class, new()
{
    private static T _instance;
    private static bool _isSet = false;

    protected void SetInstance(T curInstance)
    {
        _instance = curInstance;
        _isSet = true;
    }

    public static T Instance
    {
        get
        {
            if (!_isSet)
            {
                throw new Exception("Use MonoSingleton before that MonoBehavior invoke method `SetInstance(T curInstance)` in `Awake()`, or miss `this.SetInstance(this);` in MonoBehavior's method `Awake()`.");
            }
            return MonoSingleton<T>._instance;
        }
    }
}
