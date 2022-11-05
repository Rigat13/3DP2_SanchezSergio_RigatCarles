using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalResizer : MonoBehaviour
{
    [SerializeField] PortalPreview portalPreview;
    [SerializeField] float minScale = 0.5f;
    [SerializeField] float maxScale = 2.0f;
    bool resizeEnabled = false;

    void Update()
    {
        if (resizeEnabled)
        {
            if (increaseScaleInput()) increaseScale();
            else if (decreaseScaleInput()) decreaseScale();
        }
    }

    bool increaseScaleInput()
    {
        return Input.GetAxis("Mouse ScrollWheel") > 0f;
    }

    bool decreaseScaleInput()
    {
        return Input.GetAxis("Mouse ScrollWheel") < 0f;
    }

    void increaseScale()
    {
        float scale = portalPreview.getScale();
        scale += 0.01f;
        if (scale > maxScale) scale = maxScale;
        portalPreview.setScale(scale);
    }

    void decreaseScale()
    {
        float scale = portalPreview.getScale();
        scale -= 0.01f;
        if (scale < minScale) scale = minScale;
        portalPreview.setScale(scale);
    }

    public void enableResize() { resizeEnabled = true; }
    public void disableResize() { resizeEnabled = false; }

}
