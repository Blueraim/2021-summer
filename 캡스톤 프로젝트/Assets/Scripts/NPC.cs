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
                npcName = "�Ѽ�ȣ";
                break;
            case "Jimin":
                questionKey = 'C';
                npcName = "������";
                break;
            case "Yewon":
                questionKey = 'E';
                npcName = "�ѿ���";
                break;
            case "Dahee":
                questionKey = 'S';
                npcName = "�ִ���";
                break;
            case "Sieun":
                questionKey = 'A';
                npcName = "�ڽ���";
                break;
            case "Jeongwoo":
                questionKey = 'I';
                npcName = "������";
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
            Debug.LogError("������ �����ϴ�.");
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
                return "�Ѽ�ȣ";
            case 'C':
                return "������";
            case 'E':
                return "�ѿ���";
            case 'S':
                return "�ִ���";
            case 'A':
                return "�ڽ���";
            case 'I':
                return "������";
        }
        return null;
    }
}
