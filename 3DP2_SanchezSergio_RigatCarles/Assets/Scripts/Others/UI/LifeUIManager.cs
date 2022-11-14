using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class LifeUIManager : MonoBehaviour
{
    [SerializeField] TMP_Text life_current;
    [SerializeField] TMP_Text life_max;
    [SerializeField] Slider life_slider;

    public void updateHealth(float maxHealth, float currentHealth)
    {
        life_current.text = currentHealth.ToString()+"/";
        life_max.text = maxHealth.ToString();
        life_slider.value = currentHealth / maxHealth;
    }
}
