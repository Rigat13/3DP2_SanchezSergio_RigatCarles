using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refraction : MonoBehaviour
{
    [SerializeField] Laser laser;
    bool wasActivated = false;

    public void activateReflection(bool active, Vector3 position, Vector3 direction)
    {
        wasActivated = true;
        laser.setRay(new Ray(position, direction));
    }
    private void LateUpdate()
    {
        laser.activate(wasActivated);
        wasActivated = false;
    }
}
