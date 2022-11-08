using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckVertical : MonoBehaviour
{
    [SerializeField] float angleThreshold = 20f;
    [SerializeField] UnityEvent<bool> isUpChanged;
    bool wasUp = false;

    void Update()
    {
        bool isUp = Mathf.Abs(getCurrentAngle()) < angleThreshold;
        if (isUp != wasUp)
            isUpChanged.Invoke(isUp);
            
        wasUp = isUp;
    }

    float getCurrentAngle() { return Vector3.Angle(Vector3.up, transform.up); }
}
