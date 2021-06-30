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

    private string[] DofWeek_ = new string[] { "일", "월", "화", "수", "목", "금", "토" };

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
        gradeText.text = "학년: " + grade;
        semesterText.text = "학기: " + semester;
        dayText.text = "날짜: " + day;
        DofWeekText.text = DofWeek_[day % 7] + "요일";
        StudyText.text = "공부할 것: " + Study;
    }

    IEnumerator AutoDayPlus()
    {
        yield return new WaitForSecondsRealtime(1f);

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

        StudyText.text = "공부할 것: " + Study;
    }

    void Friday()
    {
        if (day%7 == 5)
        {
            Text.text = "오늘은 금요일이다.\n친구들을 찾아가 대화를 나눠보자!";

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

    public void BtnActiveFalse()
    {
        btn.gameObject.SetActive(false);
    }

    public void StudyChoose()
    {
        /*if(Study != null)
        {
            SceneManager.LoadScene("CorridorScene");
            
        }*/
        SceneManager.LoadScene("CorridorScene");

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
            SceneManager.LoadScene("Opening");
        }
    }
}
