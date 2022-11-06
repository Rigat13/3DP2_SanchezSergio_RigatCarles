using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalGun : MonoBehaviour
{
    [SerializeField] GameObject previewPortal;
    [SerializeField] Portal bluePortal;
    [SerializeField] Portal orangePortal;
    [SerializeField] Camera cam;
    [SerializeField] float maxShootDist = float.MaxValue;
    [SerializeField] LayerMask portalMask;
<<<<<<< Updated upstream:3DP2_SanchezSergio_RigatCarles/Assets/Scripts/Portal/UserInput/PortalGun.cs
    [SerializeField] PortalResizer portalResizer;
=======
    [SerializeField] Sprite emptyCrosshair;
    [SerializeField] Sprite blueCrosshair;
    [SerializeField] Sprite orangeCrosshair;
    [SerializeField] Sprite bothCrosshair;
    [SerializeField] Image crosshair;
>>>>>>> Stashed changes:3DP2_SanchezSergio_RigatCarles/Assets/Scripts/PortalGun.cs

    bool previewActiveBlue = false;
    bool previewActiveOrange = false;
    bool bluePortalActive = false;
    bool orangePortalActive = false;


    void Update()
    {
        checkBluePortal();
        checkOrangePortal();    
        previewPortal.SetActive(previewActiveBlue || previewActiveOrange);
        if (!bluePortalActive && !orangePortalActive) crosshair.sprite = emptyCrosshair;
        if (bluePortalActive && orangePortalActive) crosshair.sprite = bothCrosshair;
        if (!bluePortalActive && orangePortalActive) crosshair.sprite = orangeCrosshair;
        if (bluePortalActive && !orangePortalActive) crosshair.sprite = blueCrosshair;
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
                bluePortalActive = true;
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
                orangePortalActive = true;
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
                portalResizer.enableResize();
                return previewPortal.GetComponent<PortalPreview>().isInValidPosition(cam);
            }
        }
        portalResizer.disableResize();
        return false;
    }

    private void shootPortal(Portal portal)
    {
        portal.gameObject.SetActive(true);
        portal.gameObject.transform.position = previewPortal.transform.position;
        portal.gameObject.transform.rotation = previewPortal.transform.rotation;
        portal.setScale(portalResizer.getScale());
    }
}
