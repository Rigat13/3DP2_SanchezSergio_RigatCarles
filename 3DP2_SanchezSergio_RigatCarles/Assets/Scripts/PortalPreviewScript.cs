using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPreviewScript : MonoBehaviour
{
    [SerializeField] Transform previewPointsParent;
    [SerializeField] LayerMask portalMask;
    [SerializeField] float maxPortalDist = float.MaxValue;

    public bool isInValidPosition(Camera cam)
    {
        foreach(Transform previewPoint in previewPointsParent)
        {
            Ray r = new Ray(cam.transform.position, previewPoint.position - cam.transform.position);
            if (Physics.Raycast(r, out RaycastHit hitInfo, maxPortalDist, portalMask))
            {
                if (!hitInfo.collider.gameObject.CompareTag("PortalEnabled"))
                    return false;
                if ((previewPoint.position - hitInfo.point).magnitude > 0.1f)
                    return false;
                if (Vector3.Angle(previewPoint.forward, hitInfo.normal) > 0.1f)
                    return false;
            }
            else return false;
        }
        return true;
    }
}
