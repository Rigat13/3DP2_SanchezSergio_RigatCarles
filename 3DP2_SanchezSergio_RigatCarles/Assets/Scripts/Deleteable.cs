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
            Debug.Log("Me desaparesco");
            Color newColor = mat.color;
            if (newColor.a > 0)
            {
                newColor.a -= Time.deltaTime;
                mat.color = newColor;
                //preguntar en clase al profe
                //gameObject.GetComponent<MeshRenderer>().material = mat;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }


}
