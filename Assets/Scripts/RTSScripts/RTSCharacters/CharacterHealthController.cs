using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealthController : MonoBehaviour,IDamagable
{
    [SerializeField]
    private Healthbar healthBar;
    private float currentHealth;

    public void SetHealth(float initHealth)
    {
        currentHealth = initHealth;
        healthBar.SetHealthBar(initHealth);
    }

    public void TakeDamage(float takenDamage)
    {
        if (currentHealth - takenDamage <= 0)
        {
            currentHealth = 0;
            Dispose();
        }
        else
        {
            currentHealth -= takenDamage;
            healthBar.UpdateHealthbar(currentHealth);
        }
    }
    public void Dispose()
    {
        healthBar.CloseHealthbar();
        Destroy(gameObject);
    }

    public float GetHealth()
    {
        return currentHealth;
    }
}
