using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CompanionButton : MonoBehaviour
{
    [SerializeField] UnityEvent buttonPressed;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cube")
            buttonPressed.Invoke();
    }
}
