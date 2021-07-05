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
            SeasonCheck();
        }
        else if ((SceneManager.GetActiveScene().name == "SpringScene") || (SceneManager.GetActiveScene().name == "SummerScene") ||
                 (SceneManager.GetActiveScene().name == "FallScene") || (SceneManager.GetActiveScene().name == "WinterScene"))
        {
            SceneManager.LoadScene("StudyCal");
            Calender.day++;
        }
        else if(SceneManager.GetActiveScene().name == "Ending")
        {
            SceneManager.LoadScene("Opening");
        }
    }

    void SeasonCheck()
    {
        if ((Calender.day < 14) && (Calender.semester == 1))
        {
            SceneManager.LoadScene("SpringScene");
        }
        else if (Calender.semester == 1)
        {
            SceneManager.LoadScene("SummerScene");
        }
        if ((Calender.day < 14) && (Calender.semester == 2))
        {
            SceneManager.LoadScene("FallScene");
        }
        else if (Calender.semester == 2)
        {
            SceneManager.LoadScene("WinterScene");
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
