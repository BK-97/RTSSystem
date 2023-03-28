using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RTSManager))]
public class ButtonEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        RTSManager myScript = (RTSManager)target;
        if (GUILayout.Button("SetFormation"))
        {
            myScript.ChangeFormation();
        }
    }
}