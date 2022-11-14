using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Consumable : MonoBehaviour
{
    [SerializeField] ConsumableAsset consumableAsset;
    [SerializeField] Animator animator;
    [SerializeField] float consumeTime = 0.5f;
    [SerializeField] UnityEvent consumeEvent;


    public void consume(GameObject consumer)
    {
        if (consumableAsset.consume(consumer))
        {
            consumeEvent.Invoke();
            animator.SetTrigger("consume");
            StartCoroutine(destroyAfterAnimation());
        }
    }

    IEnumerator destroyAfterAnimation()
    {
        yield return new WaitForSeconds(consumeTime);
        Destroy(gameObject);
    }
}
