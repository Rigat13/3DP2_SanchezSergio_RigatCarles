using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour
{
    [SerializeField] GameObject previewPortal;
    [SerializeField] GameObject bluePortal;
    [SerializeField] GameObject orangePortal;
    [SerializeField] Camera cam;
    [SerializeField] float maxShootDist = float.MaxValue;
    [SerializeField] LayerMask portalMask;

    bool previewActiveBlue = false;
    bool previewActiveOrange = false;

    void Update()
    {
        checkBluePortal();
        checkOrangePortal();    
        previewPortal.SetActive(previewActiveBlue || previewActiveOrange);
    }

    void checkBluePortal()
    {
        if (Input.GetMouseButton(0))
            previewActiveBlue = movePreview();
        if (Input.GetMouseButtonUp(0))
        {
            if (previewActiveBlue)
            {
                shootPortal(bluePortal);
            }
            previewActiveBlue = false;
        }
    }

    void checkOrangePortal()
    {
        if (Input.GetMouseButton(1))
            previewActiveOrange = movePreview();
        if (Input.GetMouseButtonUp(1))
        {
            if (previewActiveOrange)
            {
                shootPortal(orangePortal);
            }
            previewActiveOrange = false;
        }
    }

    private bool movePreview()
    {
        Ray r = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(r, out RaycastHit hitInfo, maxShootDist, portalMask))
        {
            bool isPortalEnabled = hitInfo.collider.gameObject.CompareTag("PortalEnabled");
            if (isPortalEnabled)
            {
                previewPortal.transform.position = hitInfo.point;
                previewPortal.transform.rotation = Quaternion.LookRotation(hitInfo.normal);
                return previewPortal.GetComponent<PortalPreviewScript>().isInValidPosition(cam);
            }
            return false;
        }
        return false;
    }

    private void shootPortal(GameObject portal)
    {
        portal.SetActive(true);
        portal.transform.position = previewPortal.transform.position;
        portal.transform.rotation = previewPortal.transform.rotation;
    }
}
