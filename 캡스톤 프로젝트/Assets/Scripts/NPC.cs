using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    private Dictionary<char, List<string>> questionList;
    private char questionKey;
    private List<string> question;
    private LoadFile load;
    private bool Interaction = false;

    private string npcName;

    private static int questionIndex = 0;
    private static int count = 0;

    void Start()
    {
        load = FindObjectOfType<LoadFile>();

        switch (gameObject.name)
        {
            case "Seongho":
                questionKey = 'R';
                npcName = "한성호";
                break;
            case "Jimin":
                questionKey = 'C';
                npcName = "서지민";
                break;
            case "Yewon":
                questionKey = 'E';
                npcName = "한예원";
                break;
            case "Dahee":
                questionKey = 'S';
                npcName = "최다희";
                break;
            case "Sieun":
                questionKey = 'A';
                npcName = "박시은";
                break;
            case "Jeongwoo":
                questionKey = 'I';
                npcName = "박정우";
                break;
        }

        question = new List<string>();
        Debug.Log(questionKey);
        question = load.GetQuestionList(questionKey);

        if (question == null)
        {
            Debug.LogError("질문이 없습니다.");
        }
    }

    public string GetName() { return npcName; }
    public char GetKey() { return questionKey; }

    public void ShowText(Text dialogue)
    {
        if (Interaction == true)
        {
            dialogue.text = "하루에 한 번만 대화할 수 있어!";
        }
        else
        {
            dialogue.text = question[questionIndex];
            Interaction = true;
            count++;

            if (count == 6)
            {
                questionIndex++;
            }
        }
    }
}
