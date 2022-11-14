using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMessagesManager : MonoBehaviour
{
    [SerializeField] List<Animator> buttonMessages;
    List<bool> buttonAvailable;
    float timeToRestartMessage = 4f;
    
    void Start()
    {
        buttonAvailable = new List<bool>();
        for (int i = 0; i < buttonMessages.Count; i++)
        {
            buttonAvailable.Add(true);
        }
    }

    public void setMessage(string message)
    {
        for (int i = 0; i < buttonMessages.Count; i++)
        {
            if (buttonAvailable[i])
            {
                buttonMessages[i].SetTrigger("show");
                buttonMessages[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = message;
                buttonAvailable[i] = false;
                StartCoroutine(waitForButton(i));
                break;
            }
        }
    }

    IEnumerator waitForButton(int i)
    {
        yield return new WaitForSeconds(timeToRestartMessage);
        buttonAvailable[i] = true;
    }
}
