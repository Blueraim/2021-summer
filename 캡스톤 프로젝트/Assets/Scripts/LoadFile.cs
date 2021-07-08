using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFile : MonoBehaviour
{
    public TextAsset questionFile;
    public TextAsset answerFile;

    private Dictionary<char, List<string>> questionList;
    private Dictionary<char, List<string>> answerList;

    void Awake()
    {
        questionList = new Dictionary<char, List<string>>();
        answerList = new Dictionary<char, List<string>>();

        string questionText = questionFile.text.Substring(0, questionFile.text.Length);
        string answerText = answerFile.text.Substring(0, answerFile.text.Length);
        string[] questionlines = questionText.Split('\n');
        string[] answerlines = answerText.Split('\n');

        Load(questionlines, questionList);
        Load(answerlines, answerList);


        /*for (int i = 0; i < questionList['I'].Count; i++)
         {
             Debug.Log(questionList['I'][i]);
         }

         for (int i = 0; i < answerList['I'].Count; i++)
         {
             Debug.Log(answerList['I'][i]);
         }*/

    }

    void Load(string[] lines, Dictionary<char, List<string>> list)
    {
        char key = 'R';
        List<string> tmp = new List<string>();

        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Length == 2)
            {
                if (tmp.Count != 0)
                {
                    if (i == lines.Length - 1)
                        tmp.Add(lines[i]);

                    list.Add(key, tmp);
                    tmp = new List<string>();
                }

                key = lines[i][0];
            }
            else
            {
                tmp.Add(lines[i]);
            }
        }
    }

    public List<string> GetQuestionList(char key)
    {
        if (questionList == null)
        {
            Debug.LogError("질문 리스트가 없습니다.");
            return null;
        }
        if (questionList.ContainsKey(key))
        {
            return questionList[key];
        }
        return null;
    }

    public List<string> GetAnswerList(char key)
    {
        if (answerList == null)
        {
            Debug.LogError("질문 리스트가 없습니다.");
            return null;
        }
        if (answerList.ContainsKey(key))
        {
            return answerList[key];
        }
        return null;
    }
}
