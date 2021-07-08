using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Button goodButton;
    public Button notbadButton;
    public Button badButton;
    public Text missionText;

    private static NPC npc;
    private EndingText ending;

    private static Dictionary<char, int> result;
    private bool check = true;
    private static string[] npcsName;

    void Start()
    {
        if (result == null)
        {
            result = new Dictionary<char, int>();

            result.Add('R', 0);
            result.Add('C', 0);
            result.Add('E', 0);
            result.Add('S', 0);
            result.Add('A', 0);
            result.Add('I', 0);
        }

        if(SceneManager.GetActiveScene().name.Contains("Scene"))
        {
            missionText.text = NPC.GetKeyName() + "에게 말을 걸어보자!" ;
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Ending" && check)
        {
            ending = GameObject.Find("Main Camera").gameObject.GetComponent<EndingText>();
            ending.SetDictionary(result);
            check = false;
            Debug.Log("엔딩씬 완료");
        }
    }

    public void SetNPC(NPC collisionNPC)
    {
        npc = collisionNPC;
    }

    public void ButtonClick(Button button)
    {
        switch (button.name)
        {
            case "GoodButton":
                IncreaseValue(1);
                break;
            case "NotBadButton":
                IncreaseValue(0);
                break;
            case "BadButton":
                IncreaseValue(-1);
                break;
        }
    }

    void IncreaseValue(int value)
    {
        Debug.Log(npc.name);

        if (result.Count == 0)
        {
            Debug.Log("리스트가 없습니다.");
        }
        else if (result.ContainsKey(npc.GetKey()))
        {
            result[npc.GetKey()] += value;
        }

        ShowValue();
    }

    void ShowValue()
    {
        Debug.Log("R:" + result['R']);
        Debug.Log("C:" + result['C']);
        Debug.Log("E:" + result['E']);
        Debug.Log("S:" + result['S']);
        Debug.Log("A:" + result['A']);
        Debug.Log("I:" + result['I']);
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
