using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserButton : MonoBehaviour
{
    [SerializeField] UnityEvent buttonPressed;
    public void pressed()
    {
        buttonPressed.Invoke();
    }
}
