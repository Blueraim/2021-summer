using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{
    public Text LanguageText;
    public Text ArithmeticText;
    public Text ArtAndPhysicalText;

    private static int R, I, A, S, E, C;
    public static int sLanguage = 0, sArithmetic = 0, sArtAndPhysical = 0;

    void Start()
    {

    }

    void Update()
    {
        LanguageText.text = "인문사회: " + sLanguage;
        ArithmeticText.text = "이공: " + sArithmetic;
        ArtAndPhysicalText.text = "예체능: " + sArtAndPhysical;
    }

    public static void Study()
    {
        if (Calender.Study == "인문사회")
        {
            sLanguage++;
        }
        else if (Calender.Study == "이공")
        {
            sArithmetic++;
        }
        else if(Calender.Study == "예체능")
            sArtAndPhysical++;
    }
}
