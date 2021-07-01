using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchOFF(GameObject active)
    {
        active.SetActive(false);
    }

    public void SwitchOn(GameObject active)
    {
        active.SetActive(true);
    }
}
