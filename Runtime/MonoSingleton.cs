using System;
using UnityEngine;

namespace Tetraizor.MonoSingleton
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        protected bool _isInitialized;

        protected static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();
                }

                return _instance;
            }
        }

        protected void Awake()
        {
            if (!_isInitialized)
                Init();
        }

        protected internal virtual void Init()
        {
            _isInitialized = false;
        }
    }
}