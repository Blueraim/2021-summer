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

    private static string Language = "하", Arithmetic = "하", ArtAndPhysical = "하";

    void Update()
    {
        StudyCal();

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

    void StudyCal()
    {
        if (sLanguage > 70)
        {
            Language = "상";
        }
        else if (sLanguage > 30)
        {
            Language = "중";
        }

        if (sArithmetic > 70)
        {
            Arithmetic = "상";
        }
        else if (sArithmetic > 30)
        {
            Arithmetic = "중";
        }

        if (sArtAndPhysical > 70)
        {
            ArtAndPhysical = "상";
        }
        else if (sArtAndPhysical > 30)
        {
            ArtAndPhysical = "중";
        }
    }
}
