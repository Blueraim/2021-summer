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
        firstResult.text = player.GetName() + "���� ù�� ° ������ " +
            typeName[0] + "(" + key[0] + ") �Դϴ�.\n�� �������� OO������ �ֽ��ϴ�.";
        secondResult.text = player.GetName() + "���� �ι� ° ������ " + 
            typeName[1] + "(" + key[1] + ") �Դϴ�.\n�� �������� ���������� �ֽ��ϴ�.";
    }

    string SetTypeName(char keyValue)
    {
        switch(keyValue)
        {
            case 'R':
                return "������";
            case 'C':
                return "������";
            case 'E':
                return "�����";
            case 'S':
                return "��ȸ��";
            case 'A':
                return "������";
            case 'I':
                return "Ž����";
        }

        return null;
    }
}
