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

    private List<char> key;
    private List<string> typeName;

    void Start()
    {
        key = new List<char>();
        typeName = new List<string>();
    }

    public void SortResult(Dictionary<char, int> dic)
    {
        var sort = dic.OrderByDescending(i => i.Value);

        foreach(var i in sort)
        {
            key.Add(i.Key);
            typeName.Add(SetTypeName(i.Key));
        }
    }

    public void ShowResult()
    {
        firstResult.text = player.GetName() + "님의 첫번 째 유형은 " +
            typeName[0] + "(" + key[0] + ") 입니다.\n이 유형에는 OO직업이 있습니다.";
        secondResult.text = player.GetName() + "님의 두번 째 유형은 " + 
            typeName[1] + "(" + key[1] + ") 입니다.\n이 유형에는 ㅁㅁ직업이 있습니다.";
    }

    string SetTypeName(char keyValue)
    {
        switch(keyValue)
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
}
