using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSingle<T> where T :  new()
{
    // Start is called before the first frame update
    private static T instance;
   

    public static T GetInstance()
    {
        if (instance == null)
        {
            Debug.Log(typeof(T).ToString());
            instance = new T();
        }
        return instance;
    }
}
