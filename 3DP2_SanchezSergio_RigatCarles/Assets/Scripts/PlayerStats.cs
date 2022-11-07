using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public float maxHealth;
    public float currentHealth;
    public float timeToRegen;
    public float regenCounter;
    [SerializeField] GameObject gameOverHud;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0.0f)
        {
            currentHealth = 0;
            die();
        }
        regenCounter = 0;
    }
    private void Update()
    {
        regenCounter++;
        if (regenCounter > timeToRegen)
        {
            if (currentHealth < maxHealth)
            {
                currentHealth++;
            }
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Entra");
        if (collider.gameObject.tag == "deadzone")
        {
            takeDamage(2);
            Debug.Log("Get deadzoned");
        }
    }

    private void die()
    {
        gameOverHud.SetActive(true);
        
    }
}