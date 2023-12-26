using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackController : MonoBehaviour
{
    private float attackRate;
    private float attackDamage;
    private float attackRange;
    [HideInInspector]
    public bool canAttack;
    private bool onCooldown;
    private bool isAttacking;
    private float timeSinceLastAttack;
    public GameObject enemyTarget;
    public void Initalize(CharacterData data)
    {
        attackRate = data.baseAttackRate;
        attackDamage = data.baseAttackDamage;
        attackRange = data.baseAttackRange;
    }
    public void Attack()
    {
        if (!canAttack)
            return;

        if (onCooldown)
        {
            AttackTimer();
        }
        else
        {
            AttackStart();
            isAttacking = true;
            onCooldown = true;
        }
    }
    private void AttackStart()
    {
        Debug.Log("NewAttackStart");
    }
    private void AttackTimer()
    {
        timeSinceLastAttack += Time.deltaTime; 
        if (timeSinceLastAttack >= 1f / attackRate)
        {
            onCooldown=false;
            timeSinceLastAttack = 0f;
        }
    }
    public void GiveDamage()
    {
        enemyTarget.GetComponent<IDamagable>().TakeDamage(attackDamage);
        Debug.Log("GiveDamage");

    }
    public void AttackEnd()
    {
        isAttacking = false;
        Debug.Log("AttackEnd");

    }
    public bool IsEnemyTargetInRange()
    {
        if (enemyTarget == null)
            return false;
        float distance = Vector3.Distance(enemyTarget.transform.position, transform.position);
        if (attackRange >= distance)
        {
            return true;
        }
        else
            return false;
    }
}
