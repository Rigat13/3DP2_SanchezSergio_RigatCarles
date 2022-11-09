using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal otherPortal;
    public Transform virtualPortal;
    [SerializeField] Camera cam;
    [SerializeField] Transform player;
    [SerializeField] float scale = 1.0f;

    Vector3 initialScale;
    float initialCameraFOV;

    void Start()
    {
        initialScale = transform.localScale;
        initialCameraFOV = cam.fieldOfView;
    }

    private void Update() 
    {
        Vector3 playerLocalPos = virtualPortal.InverseTransformPoint(player.position);
        Vector3 otherCameraLocalPos = playerLocalPos;
        Vector3 otherCameraWorldPos = otherPortal.transform.TransformPoint(otherCameraLocalPos);

        Vector3 playerLocalFw = virtualPortal.InverseTransformDirection(player.forward);
        Vector3 otherCameraLocalFw = playerLocalFw;
        Vector3 otherCameraWorldDFw = otherPortal.transform.TransformDirection(otherCameraLocalFw);

        otherPortal.cam.transform.position = otherCameraWorldPos;
        otherPortal.cam.transform.forward = otherCameraWorldDFw;

        float distCameraPortal = (otherPortal.transform.position - otherPortal.cam.transform.position).magnitude;
        otherPortal.cam.nearClipPlane = distCameraPortal;
    }

    void resize()
    {
        transform.localScale = initialScale * scale;
        otherPortal.resizeCamera(scale);
    }

    public void resizeCamera(float otherScale)
    {
        cam.fieldOfView = initialCameraFOV * otherScale;
    }
    
    public float getScale() { return scale; }
    public void setScale(float scale) { this.scale = scale; resize(); }

    public float getResizeScale() { return scale / otherPortal.getScale(); }
}
