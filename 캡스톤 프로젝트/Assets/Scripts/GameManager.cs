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

    private NPC npc;
    private EndingText ending;

    private static Dictionary<char, int> result;

    // Start is called before the first frame update
    void Start()
    {
        if(result == null)
        {
            result = new Dictionary<char, int>();

            result.Add('R', 0);
            result.Add('C', 0);
            result.Add('E', 0);
            result.Add('S', 0);
            result.Add('A', 0);
            result.Add('I', 0);
        }

        if(SceneManager.GetActiveScene().name == "Ending")
        {
            ending = gameObject.GetComponent<EndingText>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CalValue()
    {
        ending.SortResult(result);
        ending.ShowResult();
    }

    public void GetNPC(GameObject collisionNPC)
    {
        npc = collisionNPC.GetComponent<NPC>();
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
        if(result.ContainsKey(npc.GetKey()))
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
