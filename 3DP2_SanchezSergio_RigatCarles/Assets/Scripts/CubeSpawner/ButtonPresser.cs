using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPresser : MonoBehaviour
{
    List<ButtonTrigger> buttonTriggers = new List<ButtonTrigger>();

    void Update()
    {
        buttonTriggers.ForEach(buttonTrigger => {
            // TODO: Show in UI!
            if (Input.GetKeyDown(buttonTrigger.getKeyCode()))
                buttonTrigger.press();
        });
    }

    void OnTriggerEnter(Collider collider) 
    {
        if (collider.gameObject.TryGetComponent(out ButtonTrigger buttonTrigger))
        {
            buttonTriggers.Add(buttonTrigger);
        }
    }

    void OnTriggerExit(Collider collider) 
    {
        if (collider.gameObject.TryGetComponent(out ButtonTrigger buttonTrigger))
        {
            buttonTriggers.Remove(buttonTrigger);
        }
    }
}
