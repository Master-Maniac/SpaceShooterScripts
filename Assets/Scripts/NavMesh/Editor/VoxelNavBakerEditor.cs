using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(VoxelBaker))]
public class VoxelNavBakerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        VoxelBaker baker = (VoxelBaker)target;

        if (GUILayout.Button("Bake Voxel Nav Volume"))
        {
            baker.Bake();
        }
    }
}
