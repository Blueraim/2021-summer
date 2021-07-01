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
    private LoadFile load;
    private bool Interaction = false;

    private static int questionIndex = 0;
    private static int count = 0;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (collision.gameObject.tag == "Player")
            {
                if (Interaction == true)
                {
                    npcText.text = gameObject.name + ": 꺼져";
                }
                else
                {
                    npcText.text = gameObject.name + ": " + question[questionIndex];
                    Interaction = true;
                    count++;

                    if (count == 6)
                    {
                        questionIndex++;
                    }
                }
            }
        }
    }

}
