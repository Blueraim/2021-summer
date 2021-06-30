using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{
    public Text LanguageText;
    public Text ArithmeticText;
    public Text ArtAndPhysicalText;

    private static string playerName;
    private static Sprite playerSprite;
    private static int R, I, A, S, E, C;
    public static int sLanguage = 0, sArithmetic = 0, sArtAndPhysical = 0;

    void Start()
    {
        
    }

    void Update()
    {
        LanguageText.text = "언어: " + sLanguage;
        ArithmeticText.text = "산수: " + sArithmetic;
        ArtAndPhysicalText.text = "예체능: " + sArtAndPhysical;
    }

    public static void Study()
    {
        if (Calender.Study == "Language")
        {
            sLanguage++;
        }
        else if (Calender.Study == "Arithmetic")
        {
            sArithmetic++;
        }
        else if(Calender.Study == "ArtAndPhysical")
            sArtAndPhysical++;
    }

    public void SetName(Text name)
    {
        playerName = name.text;
    }

    public void SetSprite(Sprite sprite)
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
