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

    public Button btn;
    public GameObject StudyBtn;


    private bool canPlus = true;

    public static int grade = 1, semester = 1, day = 1;

    private string[] DofWeek_ = new string[] { "��", "��", "ȭ", "��", "��", "��", "��" };

    public static string Study = null;


    // Start is called before the first frame update
    void Start()
    {
        TextCallFunction();
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (canPlus)
        {
            canPlus = false;
            StartCoroutine("AutoDayPlus");
        }
        Season();
        TextCallFunction();

        Friday();
        Sunday();
    }

    void TextCallFunction()
    {
        gradeText.text = grade + "�г�";
        semesterText.text = semester + "�б�";
        dayText.text = day + "��";
        DofWeekText.text = DofWeek_[day % 7] + "����";
        StudyText.text = "������ ��: " + Study;
    }

    IEnumerator AutoDayPlus()
    {
        yield return new WaitForSecondsRealtime(0.5f);

        if ((day % 7 != 5) && (day % 7 != 0))
        {
            day++;
            PlayerStat.Study();
        }
        
        canPlus = true;
    }

    public void WhatToStudy()
    {
        string ButtonName = EventSystem.current.currentSelectedGameObject.name;

        if (ButtonName == "Language")
        {
            Study = "�ι���ȸ";
        }
        else if (ButtonName == "Arithmetic")
        {
            Study = "�̰�";
        }
        else if (ButtonName == "ArtAndPhysical")
        {
            Study = "��ü��";
        }

        StudyText.text = "������ ��: " + Study;
    }

    void Friday()
    {
        if (day%7 == 5)
        {
            Text.text = "������ �ݿ����̴�.\n\nģ������ ã�ư�\n��ȭ�� ��������!";

            BtnActivetrue();
        }
    }

    void Sunday()
    {
        if (day % 7 == 0)
        {
            StudyBtn.gameObject.SetActive(true);
        }
        else
            StudyBtn.gameObject.SetActive(false);
    }

    void BtnActivetrue()
    {
        btn.gameObject.SetActive(true);
    }

    public void StudyChoose()
    {
        day++;
    }

    public void Season()
    {
        if(day > 28)
        {
            day = 1;
            semester++;
        }
        if(semester > 2)
        {
            semester = 1;
            grade++;
        }
        if(grade > 3)
        {
            SceneManager.LoadScene("Ending");
        }
    }

    public void npcUp()
    {
        NPC.order++;

        if (NPC.order == 6)
        {
            NPC.order = 0;
        }
    }
}
