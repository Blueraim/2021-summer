using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class EndingText : MonoBehaviour
{
    public Text firstResult;
    public Text secondResult;
    public Player player;
    public TextAsset jobFile;

    private List<char> key;
    private List<string> typeName;

    private static Dictionary<char, List<string>> job;
    private string highStat;
    private Dictionary<char, int> calValue;

    void Awake()
    {
        job = new Dictionary<char, List<string>>();
        List<string> tmp = new List<string>();
        char key = 'R';

        string jobText = jobFile.text.Substring(0, jobFile.text.Length);
        string[] jobLines = jobText.Split('\n');

        for (int i = 0; i < jobLines.Length; i++)
        {
            if (jobLines[i].Length == 2)
            {
                if (tmp.Count != 0)
                {
                    Debug.Log(tmp.Count);
                    job.Add(key, tmp);
                    tmp = new List<string>();
                }

                key = jobLines[i][0];
            }
            else
            {
                tmp.Add(jobLines[i]);

                if (i == jobLines.Length - 1)
                    job.Add(key, tmp);
            }
        }
    }

    void Start()
    {
        key = new List<char>();
        typeName = new List<string>();
    }

    public void SetDictionary(Dictionary<char, int> dic)
    {
        calValue = new Dictionary<char, int>(dic);
    }

    public void SortResult()
    {
        var sort = calValue.OrderByDescending(i => i.Value);

        foreach (var i in sort)
        {
            key.Add(i.Key);
            typeName.Add(SetTypeName(i.Key));
        }

        for (int i = 0; i < key.Count; i++)
        {
            Debug.Log(key[i]);
        }

        Dictionary<string, int> tmp = new Dictionary<string, int>();
        tmp.Add("sLanguage", PlayerStat.sLanguage);
        tmp.Add("sArithmetic", PlayerStat.sArithmetic);
        tmp.Add("sArtAndPhysical", PlayerStat.sArtAndPhysical);

        highStat = tmp.OrderByDescending(i => i.Value).FirstOrDefault().Key;
        Debug.Log(highStat);

        ShowResult();
    }

    public void ShowResult()
    {
        List<string> first = new List<string>(GetJob(key[0]));
        List<string> second = new List<string>(GetJob(key[1]));

        firstResult.text = player.GetName() + "님의 첫번 째 유형은 " +
            typeName[0] + "(" + key[0] + ") 입니다.\n";
        secondResult.text = player.GetName() + "님의 두번 째 유형은 " +
            typeName[1] + "(" + key[1] + ") 입니다.\n";

        /*
        for (int i = 0; i < first.Count; i++)
        {
            Debug.Log(first[i]);
        }
        */

        ShowJop(first, firstResult);
        ShowJop(second, secondResult);
    }

    void ShowJop(List<string> showList, Text showText)
    {
        int count = 0;
        for (int i = 0; i < showList.Count; i++)
        {
            Debug.Log("보여주기");
            if (count == 4)
            {
                showText.text += "\n";
                count = 0;
            }
            else if (i == showList.Count - 1)
            {
                showText.text += (showList[i]);
                count++;
            }
            else
            {
                showText.text += (showList[i] + ", ");
                count++;
            }
        }
    }

    List<string> GetJob(char key)
    {
        Debug.Log("GetJob 호출됨");
        List<string> jobList = new List<string>(job[key]);
        Debug.Log("키에 맞는 리스트 나옴");
        List<string> showText = new List<string>();
        bool check = false;

        for (int i = 0; i < jobList.Count; i++)
        {
            if (jobList[i].Contains("s"))
            {
                if (showText.Count != 0)
                {
                    break;
                }
                else if (jobList[i].Contains(highStat))
                {
                    check = true;
                    continue;
                }
                else
                {
                    check = false;
                    continue;
                }
            }

            if (check)
            {
                showText.Add(jobList[i]);
            }
        }

        return showText;
    }

    string SetTypeName(char keyValue)
    {
        switch (keyValue)
        {
            case 'R':
                return "현실형";
            case 'C':
                return "관습형";
            case 'E':
                return "기업형";
            case 'S':
                return "사회형";
            case 'A':
                return "예술형";
            case 'I':
                return "탐구형";
        }

        return null;
    }

    public void SwitchOFF(GameObject active)
    {
        active.SetActive(false);
    }

    public void SwitchOn(GameObject active)
    {
        active.SetActive(true);
    }
}
