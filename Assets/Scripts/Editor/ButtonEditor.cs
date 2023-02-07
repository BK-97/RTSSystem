using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Spawner))]
public class ButtonEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Spawner myScript = (Spawner)target;
        if (GUILayout.Button("Spawn"))
        {
            myScript.Spawn();
        }
    }
}