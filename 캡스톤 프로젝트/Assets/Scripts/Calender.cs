using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class Calender : MonoBehaviour
{

    public Text gradeText;
    public Text semesterText;
    public Text dayText;
    public Text DofWeekText;
    public Text StudyText;
    public Text Text;
    private bool canPlus = true;

    public static int grade =1, semester=1, day=1;
    public static string DofWeek = "��";

    private string[] DofWeek_ = new string[] { "��", "��", "ȭ", "��", "��", "��", "��" };

    public static string Study="non";


    // Start is called before the first frame update
    void Start()
    {
        TextCallFunction();
    }

    // Update is called once per frame
    void Update()
    {
        Friday();
        if (canPlus)
        {
            canPlus = false;
            StartCoroutine("AutoDayPlus");
        }
        
    }

    void TextCallFunction()
    {
        gradeText.text = "�г�: " + grade;
        semesterText.text = "�б�: " + semester;
        dayText.text = "��¥: " + day;
        DofWeekText.text = DofWeek + "����";
        StudyText.text = "������ ��: " + Study;
    }

    IEnumerator AutoDayPlus()
    {
        dayText.text = "��¥: " + day;
        DofWeekText.text = DofWeek + "����";

        if ((day % 7 != 5) && (day % 7 != 0))
        {
            day++;
        }

        DofWeek = DofWeek_[day % 7];

        yield return new WaitForSecondsRealtime(1f);
        canPlus = true;
    }

    public void WhatToStudy()
    {
        string ButtonName = EventSystem.current.currentSelectedGameObject.name;

        if (ButtonName == "Language")
        {
            Study = "Language";
        }
        else if (ButtonName == "Arithmetic")
        {
            Study = "Arithmetic";
        }
        else if (ButtonName == "ArtAndPhysical")
        {
            Study = "ArtAndPhysical";
        }

        StudyText.text = "������ ��: " + Study;
    }

    void Friday()
    {
        if(day%7 == 5)
        {
            Text.text = "������ �ݿ����̴�.\nģ������ ã�ư� ��ȭ�� ��������!";
            //day++; �� ���ƴٴϰ� ������ �� ���ϱ�
            //NextButton Ȱ��ȭ��Ű��

        }
    }

    void Sunday()
    {

        if (day % 7 == 0)
        {

        }
    }
}
