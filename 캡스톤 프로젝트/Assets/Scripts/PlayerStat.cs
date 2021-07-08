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

    private static string Language = "��", Arithmetic = "��", ArtAndPhysical = "��";

    void Update()
    {
        StudyCal();

        LanguageText.text = "�ι���ȸ: " + sLanguage;
        ArithmeticText.text = "�̰�: " + sArithmetic;
        ArtAndPhysicalText.text = "��ü��: " + sArtAndPhysical;
    }

    public static void Study()
    {
        if (Calender.Study == "�ι���ȸ")
        {
            sLanguage++;
        }
        else if (Calender.Study == "�̰�")
        {
            sArithmetic++;
        }
        else if(Calender.Study == "��ü��")
            sArtAndPhysical++;
    }

    void StudyCal()
    {
        if (sLanguage > 70)
        {
            Language = "��";
        }
        else if (sLanguage > 30)
        {
            Language = "��";
        }

        if (sArithmetic > 70)
        {
            Arithmetic = "��";
        }
        else if (sArithmetic > 30)
        {
            Arithmetic = "��";
        }

        if (sArtAndPhysical > 70)
        {
            ArtAndPhysical = "��";
        }
        else if (sArtAndPhysical > 30)
        {
            ArtAndPhysical = "��";
        }
    }
}
