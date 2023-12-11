using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ArmorData : ScriptableObject
{
    public ArmorTypes ArmorType;
    public float Armor;
    public float WeightPenalty;
}
