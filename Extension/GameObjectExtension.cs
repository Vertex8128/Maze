﻿using UnityEngine;

public static class GameObjectExtension
{
    public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
    {
        var result = gameObject.GetComponent<T>();
        if (!result)
        {
            result = gameObject.AddComponent<T>();
        }
        return result;
    }
}