using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Create Key Consumer")]
public class KeyAsset : ConsumableAsset
{
    public int indexToUnclock = 0;

    override public bool consume(GameObject consumer)
    {
        if (consumer.TryGetComponent<DoorUnlocker>(out DoorUnlocker doorUnlocker))
        {
            doorUnlocker.unlockDoor(indexToUnclock);
            return true;
        }
        return false;
    }
}