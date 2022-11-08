using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float maxRayDist = 200f;
    bool isEnabled = true;

    void Update()
    {
        lineRenderer.enabled = isEnabled;
        if (!isEnabled)
            return;


        Ray r = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, maxRayDist, layerMask))
        {
            lineRenderer.SetPosition(1, new Vector3(0f, 0f, hitInfo.distance));
            if (hitInfo.collider.gameObject.TryGetComponent(out LaserButton laserButton))
                laserButton.pressed();
        }
        else
        {
            lineRenderer.SetPosition(1, new Vector3(0f, 0f, maxRayDist));
        }
    }

    public void activate(bool enable)
    {
        isEnabled = enable;
    }
}
