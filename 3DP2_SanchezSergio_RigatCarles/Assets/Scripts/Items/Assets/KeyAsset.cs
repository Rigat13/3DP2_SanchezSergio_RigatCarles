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
        if (consumer.TryGetComponent(out PlayerStats playerStats))
        {
            return doorToUnclock.unlock(keyCodeToUnclock);;
        }
        return false;
    }
}