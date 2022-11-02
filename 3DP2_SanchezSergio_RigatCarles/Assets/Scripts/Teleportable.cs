using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportable : MonoBehaviour
{
    [SerializeField] float offsetAmount;

    void OnTriggerEnter(Collider other) 
    {
        if (other.TryGetComponent(out Portal portal))
        {
            Debug.Log("TELEPORT!");
            Vector3 l_Position = portal.virtualPortal.InverseTransformPoint(transform.position);
            Vector3 l_Direction = portal.virtualPortal.InverseTransformDirection(transform.forward);

            transform.forward = portal.otherPortal.transform.TransformDirection(l_Direction);
            l_Position.z += offsetAmount;
            transform.position = portal.otherPortal.transform.TransformPoint(l_Position);

            tryToFixPlayerYaw();
            tryToFixRigidbodyVelocity(portal);
        }
    }

    void tryToFixPlayerYaw()
    {
        if (gameObject.TryGetComponent(out FPSController fpsController))
            fpsController.recalculateOrientation();
    }

    void tryToFixRigidbodyVelocity(Portal portal)
    {
        if (gameObject.TryGetComponent(out Rigidbody rb))
        {
            Vector3 l_velocity = portal.virtualPortal.InverseTransformDirection(rb.velocity);
            rb.velocity = portal.otherPortal.transform.TransformDirection(l_velocity);
        }
    }
}
