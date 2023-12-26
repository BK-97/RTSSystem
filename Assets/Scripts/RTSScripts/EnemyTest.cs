using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour,IDamagable
{
    public void Dispose()
    {
    }

    public float GetHealth()
    {
        return 1;
    }

    public void SetHealth(float initHealth)
    {
    }

    public void TakeDamage(float takenDamage)
    {
        Debug.Log("DamageTaken= "+takenDamage);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
