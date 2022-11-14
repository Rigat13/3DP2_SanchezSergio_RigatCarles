using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlocker : MonoBehaviour
{
    [SerializeField] List<Door> doorToUnlock;

    public void unlockDoor(int index)
    {
        if (index < doorToUnlock.Count)
        {
            doorToUnlock[index].unlock(index);
        }
    }
}
