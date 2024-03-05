using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T _instance = null;
    public static T Instance
    {
        get
        {
            if (_instance == null)
                {
                   if (FindObjectOfType<T>() != null)
                        _instance = FindObjectOfType<T>();
                   else
                    new GameObject().AddComponent<T>().name = "Singleton_"+  typeof(T).ToString();
                }

                return _instance;
        }
    }

    public virtual void Awake()    
    {
        if(_instance != null && _instance.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this.GetComponent<T>();
        }
    }
}