using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public WeaponTypes WeaponType;
    public float damage;
    public float attackRate;
    public float attackRange;
}
