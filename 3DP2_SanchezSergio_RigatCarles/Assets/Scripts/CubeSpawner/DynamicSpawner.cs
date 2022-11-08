using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicSpawner : MonoBehaviour
{
    [SerializeField] GameObject objectToSpawn;

    public void spawn()
    {
        Instantiate(objectToSpawn, transform.position, transform.rotation);
    }
}
