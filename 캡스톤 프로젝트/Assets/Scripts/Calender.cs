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
    public static string DofWeek = "월";

    private string[] DofWeek_ = new string[] { "일", "월", "화", "수", "목", "금", "토" };

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
        gradeText.text = "학년: " + grade;
        semesterText.text = "학기: " + semester;
        dayText.text = "날짜: " + day;
        DofWeekText.text = DofWeek + "요일";
        StudyText.text = "공부할 것: " + Study;
    }

    IEnumerator AutoDayPlus()
    {
        dayText.text = "날짜: " + day;
        DofWeekText.text = DofWeek + "요일";

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

        StudyText.text = "공부할 것: " + Study;
    }

    void Friday()
    {
        if(day%7 == 5)
        {
            Text.text = "오늘은 금요일이다.\n친구들을 찾아가 대화를 나눠보자!";
            //day++; 맵 돌아다니고 종료할 때 더하기
            //NextButton 활성화시키기

        }
    }

    void Sunday()
    {

        if (day % 7 == 0)
        {

        }
    }
}
