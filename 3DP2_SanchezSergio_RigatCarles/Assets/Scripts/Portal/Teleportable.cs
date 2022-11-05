using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportable : MonoBehaviour
{
    [SerializeField] float offsetAmount;
    [SerializeField] bool resizable;
    [SerializeField] Vector3 minLocalScale = new Vector3(0.1f, 0.1f, 0.1f);
    [SerializeField] Vector3 maxLocalScale = new Vector3(10.0f, 10.0f, 10.0f);

    Vector3 initialScale;

    void Start()
    {
        initialScale = transform.localScale;
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.TryGetComponent(out Portal portal))
        {
            Vector3 l_Position = portal.virtualPortal.InverseTransformPoint(transform.position);
            Vector3 l_Direction = portal.virtualPortal.InverseTransformDirection(transform.forward);

            transform.forward = portal.otherPortal.transform.TransformDirection(l_Direction);
            l_Position.z += offsetAmount;
            transform.position = portal.otherPortal.transform.TransformPoint(l_Position);

            if (resizable) resize(portal.getScale());
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

    void resize(float scale)
    {
        transform.localScale *= scale;
        clampScale();
    }
    
    void clampScale()
    {
        if (transform.localScale.magnitude < minLocalScale.magnitude)
            transform.localScale = minLocalScale;
        else if (transform.localScale.magnitude > maxLocalScale.magnitude)
            transform.localScale = maxLocalScale;
    }
}
