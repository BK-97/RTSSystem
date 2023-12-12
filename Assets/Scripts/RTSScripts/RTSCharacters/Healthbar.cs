using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField]
    private Slider healthBar;
    public void SetHealthBar(float maxHealth)
    {
        healthBar.maxValue = maxHealth;
        healthBar.value= maxHealth;
        healthBar.gameObject.SetActive(true);
    }
    public void UpdateHealthbar(float health)
    {
        healthBar.value = health;
    }
    public void CloseHealthbar()
    {
        healthBar.value = 0;
        healthBar.gameObject.SetActive(false);
    }
}
