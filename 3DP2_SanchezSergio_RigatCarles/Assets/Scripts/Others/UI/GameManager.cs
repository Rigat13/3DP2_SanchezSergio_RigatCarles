using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] FPSController playerController;
    [SerializeField] PortalGun portalGun;

    void Start()
    {
        playerController.enabled = false;
        portalGun.enabled = false;
    }

    public void startGame()
    {
        playerController.enabled = true;
        portalGun.enabled = true;
    }

    public void endGame()
    {
        playerController.enabled = true;
        portalGun.enabled = true;
    }
}
