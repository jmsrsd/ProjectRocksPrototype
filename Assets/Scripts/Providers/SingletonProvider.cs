using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonProvider
{
    private SingletonProvider() { }

    private static SingletonProvider instance;

    public static SingletonProvider Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SingletonProvider();
            }

            return instance;
        }
    }

    private GameObject GameObject
    {
        get
        {
            var name = $"{typeof(SingletonProvider).Name}";

            GameObject result;

            result = GameObject.Find(name) ?? new GameObject(name);

            GameObject.DontDestroyOnLoad(result);

            return result;
        }
    }

    public T Get<T>() where T : MonoBehaviour
    {
        var name = typeof(T).Name;

        var go = GameObject.Find(name) ?? new GameObject(name);
        go.transform.SetParent(GameObject.transform);

        return go.GetComponent<T>() ?? go.AddComponent<T>();
    }
}
