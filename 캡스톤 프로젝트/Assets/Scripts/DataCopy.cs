using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCopy : MonoBehaviour
{
    void Awake()
    {
        var goList = FindObjectsOfType<DataCopy>();
        if (goList.Length == 1)
        {
            DontDestroyOnLoad(this);
        }
    }
}
