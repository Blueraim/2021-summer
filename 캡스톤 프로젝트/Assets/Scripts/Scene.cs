using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public void SceneControl()
    {
        if (SceneManager.GetActiveScene().name == "Opening") 
        { 
            SceneManager.LoadScene("Prologue"); 
        }
        else if(SceneManager.GetActiveScene().name == "Prologue")
        {
            SceneManager.LoadScene("StudyCal");
        }
        else if (SceneManager.GetActiveScene().name == "StudyCal")
        {
            SceneManager.LoadScene("CorridorScene");
        }
        else if (SceneManager.GetActiveScene().name == "CorridorScene")
        {
            SceneManager.LoadScene("StudyCal");
            Calender.day++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
