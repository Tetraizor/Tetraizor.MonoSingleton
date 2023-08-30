using System.Collections;
using System.Collections.Generic;
using Tetraizor.MonoSingleton;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MonoSingletonAutoCreate<T> : MonoSingleton<T> where T : MonoSingleton<T>
{
    public new static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();

                if (_instance == null)
                {
                    var newGameObject = new GameObject(typeof(T).Name);
                    var newInstance = newGameObject.AddComponent<T>();

                    _instance = newInstance;

                    _instance.Init();
                }
            }

            return _instance;
        }
    }
}
