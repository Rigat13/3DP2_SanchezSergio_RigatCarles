using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonTrigger : MonoBehaviour
{
    [SerializeField] List<string> messagesEnabled = new List<string>();
    [SerializeField] List<string> messagesDisabled = new List<string>();
    [SerializeField] KeyCode keyCode = KeyCode.E;
    [SerializeField] int maxTimesPressed;
    int timesPressed = 0;
    [SerializeField] UnityEvent buttonPressed;

    public bool isEnabled() { return timesPressed < maxTimesPressed; }

    public string getMessage() { return isEnabled() ? getMessageEnabled() : getMessageDisabled(); }

    string getMessageEnabled() { return messagesEnabled[Random.Range(0, messagesEnabled.Count)]; }
    string getMessageDisabled() { return messagesDisabled[Random.Range(0, messagesDisabled.Count)]; }

    public KeyCode getKeyCode() { return keyCode; }

    public void press() 
    { 
        if (isEnabled()) buttonPressed.Invoke();
        timesPressed++; 
    }

}
