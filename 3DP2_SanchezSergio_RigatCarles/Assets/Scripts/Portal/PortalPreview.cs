using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPreview : MonoBehaviour
{
    [SerializeField] Transform previewPointsParent;
    [SerializeField] LayerMask portalMask;
    [SerializeField] float maxPortalDist = float.MaxValue;

    Vector3 initialScale;
    float scale = 1.0f;

    void Start()
    {
        initialScale = transform.localScale;
    }

    public bool isInValidPosition(Camera cam)
    {
        foreach(Transform previewPoint in previewPointsParent)
        {
            Ray r = new Ray(cam.transform.position, previewPoint.position - cam.transform.position);
            if (Physics.Raycast(r, out RaycastHit hitInfo, maxPortalDist, portalMask))
            {
                if (!surfaceIsEnabled(hitInfo) || !surfaceIsNear(hitInfo, previewPoint) || !surfaceIsFlat(hitInfo, previewPoint))
                    return false;
            }
            else return false;
        }
        return true;
    }

    bool surfaceIsEnabled(RaycastHit hitInfo)
    {
        return hitInfo.collider.gameObject.CompareTag("PortalEnabled");
    }

    bool surfaceIsNear(RaycastHit hitInfo, Transform previewPoint)
    {
        return (previewPoint.position - hitInfo.point).magnitude <= 0.1f;
    }

    bool surfaceIsFlat(RaycastHit hitInfo, Transform previewPoint)
    {
        return Vector3.Angle(previewPoint.forward, hitInfo.normal) <= 0.1f;
    }
    

    private void resize()
    {
        transform.localScale = initialScale * scale;
    }
    
    public float getScale() { return scale; }
    public void setScale(float scale) { this.scale = scale; resize(); }
}
