using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] KeyCode startKey = KeyCode.Space;
    [SerializeField] Animator canvasAnimator;
    [SerializeField] UnityEvent startGameEvent;
    [SerializeField] UnityEvent gameOverEvent;

    void Update()
    {
        if (Input.GetKeyDown(startKey))
        {
            startGame();
        }
    }

    public void startGame()
    {
        canvasAnimator.SetTrigger("start");
        startGameEvent.Invoke();
    }

    public void gameOver()
    {
        canvasAnimator.SetTrigger("gameOver");
        gameOverEvent.Invoke();
    }
}
