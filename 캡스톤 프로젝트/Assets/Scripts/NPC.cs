using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public Text npcText;

    private Dictionary<char, List<string>> questionList;
    private char questionKey;
    private List<string> question;
    private int questionIndex = 0;
    private LoadFile load;

    void Start()
    {
        load = FindObjectOfType<LoadFile>();

        switch (gameObject.name)
        {
            case "Seongho":
                questionKey = 'R';
                break;
            case "Jimin":
                questionKey = 'C';
                break;
            case "Yewon":
                questionKey = 'E';
                break;
            case "Dahee":
                questionKey = 'S';
                break;
            case "Sieun":
                questionKey = 'A';
                break;
            case "Jeongwoo":
                questionKey = 'I';
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

    public string GetQuestion()
    {
        return question[questionIndex++];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (collision.gameObject.tag == "Player")
            {
                npcText.text = question[questionIndex++];
            }
        }
    }

}
