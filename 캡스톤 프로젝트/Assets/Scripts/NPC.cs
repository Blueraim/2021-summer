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

    public char[] keyOrder = { 'R', 'C', 'E', 'S', 'A', 'I' };
    public static int order = -1;

    private char questionKey;
    private List<string> question;
    private List<string> answer;
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

        // Debug.Log(questionKey);
        question = load.GetQuestionList(questionKey);
        answer = load.GetAnswerList(questionKey);

        if (question == null)
        {
            Debug.LogError("������ �����ϴ�.");
        }
    }

    void Update()
    {
        if (!SceneManager.GetActiveScene().name.Contains("Scene"))
        {
            Interaction = false;
        }
    }

    public string GetName() { return npcName; }
    public char GetKey() { return questionKey; }
    public bool GetInteraction() { return Interaction; }
    public int GetQuestionIndex() { return questionIndex[order]; }

    public bool InteractionCheck()
    {
        Debug.Log(order);
        if (keyOrder[order] != questionKey)
        {
            Interaction = true;
            return false;
        }
        return true;
    }

    public void ShowQuestion(Text dialogue)
    {
        if (Interaction == true)
        {
            // dialogue.text = "�Ϸ翡 �� ���� ��ȭ�� �� �־�!";
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
}
