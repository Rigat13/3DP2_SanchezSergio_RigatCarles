using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Create Key Consumer")]
public class KeyAsset : ConsumableAsset
{
    [SerializeField] Door doorToUnclock;
    public int keyCodeToUnclock = 0;

    override public bool consume(GameObject consumer)
    {
        if (consumer.gameObject.CompareTag("Player"))
        {
            return doorToUnclock.unlock(keyCodeToUnclock);;
        }
        return false;
    }
}