using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public float maxHealth;
    public float currentHealth;
    public float timeToRegen;
    public float regenCounter;
    [SerializeField] TitleScreen gameOverHud;
    [SerializeField] UnityEvent<float, float> healthChange;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        updateHealthUI();
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0.0f)
        {
            currentHealth = 0;
            die();
        }
        updateHealthUI();
        regenCounter = 0;
    }

    void updateHealthUI()
    {
        healthChange.Invoke(maxHealth, currentHealth);
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
        if (collider.gameObject.tag == "deadzone")
        {
            takeDamage(float.MaxValue);
        }
    }

    private void die()
    {
        gameOverHud.gameOver();
    }
}
