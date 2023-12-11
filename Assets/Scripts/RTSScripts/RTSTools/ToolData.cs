using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ToolData : ScriptableObject
{
    public ToolTypes ToolType;
    public ResourceTypes CollectableResourceType;

    public float GatherSpeed;

}
