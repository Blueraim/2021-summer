using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFile : MonoBehaviour
{
    public TextAsset questionFile;

    private Dictionary<char, List<string>> questionList;

    void Awake()
    {
        questionList = new Dictionary<char, List<string>>();

        string currentText = questionFile.text.Substring(0, questionFile.text.Length - 1);
        string[] lines = currentText.Split('\n');

        for (int i = 0; i < lines.Length; i += 4)
        {
            List<string> tmp = new List<string>();
            char key = lines[i][0];

            for (int j = i + 1; j < i + 4; j++)
            {
                tmp.Add(lines[j]);
            }

            /*Debug.Log(key);
            for(int j = 0; j<tmp.Count; j++)
            {
                Debug.Log(tmp[j]);
            }*/

            questionList.Add(key, tmp);
        }
    }

    void ShowValue(char key)
    {
        List<string> tmp = new List<string>();

        Debug.Log(key);
        tmp = questionList[key];

        for (int j = 0; j < tmp.Count; j++)
        {
            Debug.Log(tmp[j]);
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
}
