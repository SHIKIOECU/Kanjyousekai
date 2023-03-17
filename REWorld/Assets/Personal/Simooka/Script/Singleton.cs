using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T:Singleton<T>
{
    public static T Instance;

    //public Singleton()
    //{
    //    Instance = (T)this;
    //}

    public virtual void Awake()
    {
        Instance = (T)this;
    }
}
