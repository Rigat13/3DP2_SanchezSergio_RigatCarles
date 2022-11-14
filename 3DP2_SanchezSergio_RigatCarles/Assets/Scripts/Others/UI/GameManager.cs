using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] FPSController playerController;
    [SerializeField] PortalGun portalGun;

    void Start()
    {
        playerController.enabled = true;
        playerController.disableMove();
        portalGun.enabled = false;
    }

    public void startGame()
    {
        playerController.enabled = true;
        playerController.enableMove();
        portalGun.enabled = true;
    }

    public void endGame()
    {
        playerController.enabled = true;
        playerController.disableMove();
        portalGun.enabled = false;
    }
}
