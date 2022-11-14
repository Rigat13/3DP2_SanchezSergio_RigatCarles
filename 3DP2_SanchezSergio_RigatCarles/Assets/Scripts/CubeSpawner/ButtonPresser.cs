using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonPresser : MonoBehaviour
{
    List<ButtonTrigger> buttonTriggers = new List<ButtonTrigger>();
    [SerializeField] UnityEvent<string> buttonInteraction;
    string pressedMessage = "PRESSED";

    void Update()
    {
        buttonTriggers.ForEach(buttonTrigger => {
            if (Input.GetKeyDown(buttonTrigger.getKeyCode()))
            {
                buttonTrigger.press();
                buttonInteraction.Invoke(pressedMessage);
            }
        });
    }

    void OnTriggerEnter(Collider collider) 
    {
        if (collider.gameObject.TryGetComponent(out ButtonTrigger buttonTrigger))
        {
            buttonTriggers.Add(buttonTrigger);
            buttonInteraction.Invoke(buttonTrigger.getMessage());
        }
    }

    void OnTriggerExit(Collider collider) 
    {
        if (collider.gameObject.TryGetComponent(out ButtonTrigger buttonTrigger))
        {
            buttonTriggers.Remove(buttonTrigger);
            buttonInteraction.Invoke(buttonTrigger.getMessage());
        }
    }
}
