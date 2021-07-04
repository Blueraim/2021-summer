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
        Debug.Log(questionKey);
        question = load.GetQuestionList(questionKey);

        if (question == null)
        {
            Debug.LogError("������ �����ϴ�.");
        }
    }

    public string GetName() { return npcName; }
    public char GetKey() { return questionKey; }

    public void ShowText(Text dialogue)
    {
        if (Interaction == true)
        {
            dialogue.text = "�Ϸ翡 �� ���� ��ȭ�� �� �־�!";
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
