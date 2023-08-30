using System;
using UnityEngine;

namespace Tetraizor.MonoSingleton
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        private bool _isInitialized;
        
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();

                    if (_instance == null)
                    {
                        var newGameObject = new GameObject((string) typeof(T).Name);
                        var newInstance = newGameObject.AddComponent<T>();

                        _instance = newInstance;

                        _instance.Init();
                    }
                }
                
                return _instance;
            }
        }

        private void Awake()
        {
            if(!_isInitialized)
                Init();
        }

        protected virtual void Init()
        {
            _isInitialized = false;
        }
    }
}