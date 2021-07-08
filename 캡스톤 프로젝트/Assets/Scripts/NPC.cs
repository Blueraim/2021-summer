using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    public Text goodText;
    public Text notbadText;
    public Text badText;
    public Button goodButton;
    public Button notbadButton;
    public Button badButton;

    public static char[] keyOrder = { 'R', 'C', 'E', 'S', 'A', 'I' };
    public static int order = -1;

    private char questionKey;
    private List<string> question;
    private List<string> answer;
    private static List<string> say;
    private LoadFile load;
    private bool Interaction = false;
    private string npcName;

    private static int[] questionIndex = { 0, 0, 0, 0, 0, 0 };
    private static int[] answerIndex = { 0, 0, 0, 0, 0, 0 };

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
        answer = new List<string>();
        say = new List<string>();

        // Debug.Log(questionKey);
        question = load.GetQuestionList(questionKey);
        answer = load.GetAnswerList(questionKey);
        say = load.GetSayList();

        if (question == null)
        {
            Debug.LogError("질문이 없습니다.");
        }
    }

    public string GetName() { return npcName; }
    public char GetKey() { return questionKey; }
    public bool GetInteraction() { return Interaction; }
    public int GetQuestionIndex() { return questionIndex[order]; }

    public void InteractionChange()
    {
        if (keyOrder[order] != questionKey)
        {
            Interaction = true;
        }
    }

    public void ShowQuestion(Text dialogue)
    {
        if (Interaction == true)
        {
            int rand = Random.Range(0, say.Count);
            dialogue.text = say[rand];
        }
        else
        {
            dialogue.text = question[questionIndex[order]];

            if (question[++questionIndex[order]].Contains("/"))
            {
                ShowAnswer();

                Interaction = true;
                questionIndex[order]++;
            }
        }
    }

    void ShowAnswer()
    {
        if (answer[answerIndex[order]].Contains("/"))
        {
            if (answerIndex[order] < answer.Count)
            {
                ++answerIndex[order];
            }
            else
            {
                return;
            }
        }

        goodText.text = answer[answerIndex[order]++];
        notbadText.text = answer[answerIndex[order]++];
        badText.text = answer[answerIndex[order]++];

        goodButton.gameObject.SetActive(true);
        notbadButton.gameObject.SetActive(true);
        badButton.gameObject.SetActive(true);
    }

    public static string GetKeyName()
    {
        switch (keyOrder[order])
        {
            case 'R':
                return "한성호";
            case 'C':
                return "서지민";
            case 'E':
                return "한예은";
            case 'S':
                return "최다희";
            case 'A':
                return "박시은";
            case 'I':
                return "박정우";
        }
        return null;
    }
}
