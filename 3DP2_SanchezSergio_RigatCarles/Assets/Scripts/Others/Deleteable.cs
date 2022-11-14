using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deleteable : MonoBehaviour
{
    Material mat;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "red gel" || collider.gameObject.tag == "deadzone")
        {
            gameObject.SetActive(false);
        }
    }


}
