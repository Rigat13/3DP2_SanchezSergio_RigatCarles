using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformSamples : MonoBehaviour
{
    [SerializeField] Transform portal;

    private void Update() 
    {
        //Debug.Log("Player world position: " + transform.position);
        //Debug.Log("Player local to world: " + transform.TransformPoint(new Vector3(0.0f, 0.0f, 0.0f)));
        //Debug.Log("Player world to local: " + transform.InverseTransformPoint(transform.position));
        // transform.TransformPoint(transform.position); NO TÉ SENTIT

        Vector3 player_portal_coordinates = portal.InverseTransformPoint(transform.position);
        //Vector3 portal_world_coordinates = portal.TransformPoint(new Vector3(0.0f, 0.0f, 0.0f)); // == portal.position
        //Vector3 player_world_coordinates = portal.TransformPoint(player_portal_coordinates); // == transform.position
        Debug.Log("Player ref coordinates: " + player_portal_coordinates);
        Debug.Log("Player world coordinates: " + transform.position);
    }
}
