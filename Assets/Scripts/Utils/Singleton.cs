using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> where T : class, new()
{
    private static readonly T _instance = Activator.CreateInstance<T>();

    public static T Instance
    {
        get
        {
            return Singleton<T>._instance;
        }
    }
}
