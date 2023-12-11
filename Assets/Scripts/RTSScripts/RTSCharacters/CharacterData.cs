using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterData : ScriptableObject
{
    [Header("Main Params")]
    public CharacterTypes CharacterType;

    [Header("Life Params")]
    public int Health;
    public float baseArmor;

    [Header("Move Params")]
    public float MoveSpeed;

    [Header("Attack Params")]
    public float baseAttackDamage;
    public float baseAttackRange;
    public float baseAttackRate;

    [Header("Gather Params")]
    public float baseGatherSpeed;
}
