using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float maxRayDist = 200f;
    bool isEnabled = false;
    Ray r;
    bool useCustomRay = false;


    public void setRay(Ray r)
    {
        this.r = r;
        useCustomRay = true;
    }

    void Update()
    {
        lineRenderer.enabled = isEnabled;
        if (!isEnabled)
            return;

        if(!useCustomRay)
        {
            this.r = new Ray(transform.position, transform.forward);
        }

        Ray r = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, maxRayDist, layerMask))
        {
            lineRenderer.SetPosition(0, r.origin);
            lineRenderer.SetPosition(1, hitInfo.point);
            if (hitInfo.collider.gameObject.TryGetComponent(out LaserButton laserButton))
                laserButton.pressed();
            if (hitInfo.collider.gameObject.TryGetComponent(out Refraction refraction))
                refraction.activateReflection(true,hitInfo.point, Vector3.Reflect(this.r.direction,hitInfo.normal));
            if (hitInfo.collider.gameObject.TryGetComponent(out PlayerStats playerStats))
                playerStats.takeDamage(1);
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
