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
}
