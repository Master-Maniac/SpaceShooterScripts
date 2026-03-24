using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelBaker : MonoBehaviour
{
    [Header("Volume Size")]
    public int sizeX = 30; // number of blocks in each direction
    public int sizeY = 20;
    public int sizeZ = 30;
    public float voxelSize = 1f;// size of the voxel

    [Header("Agent")]
    public float agentRadius = 0.5f;
    [SerializeField] private GameObject radiusAgent;
    public LayerMask obstacleMask;

    [Header("Output")]
    public VoxelNavData outputData;

    public void Bake()
    {

        if (outputData == null)
        {
            Debug.LogError("No VoxelNavData assigned");
            return;
        }
        Collider col = radiusAgent.GetComponent<Collider>();
        Vector3 extents = col.bounds.extents;

        agentRadius = Mathf.Max(extents.x, extents.z);

        outputData.sizeX = sizeX;
        outputData.sizeY = sizeY;
        outputData.sizeZ = sizeZ;
        outputData.voxelSize = voxelSize;
        outputData.origin = transform.position;

        int total = sizeX * sizeY * sizeZ;
        outputData.walkable = new bool[total];

        for (int x = 0; x < sizeX; x++)
            for (int y = 0; y < sizeY; y++)
                for (int z = 0; z < sizeZ; z++)
                {
                    Vector3 worldPos = transform.position +
                        new Vector3(x, y, z) * voxelSize;

                    bool free = !Physics.CheckSphere(
                        worldPos,
                        agentRadius,
                        obstacleMask
                    );

                    int index = outputData.ToIndex(x, y, z);
                    outputData.walkable[index] = free;
                }

#if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(outputData);
        UnityEditor.AssetDatabase.SaveAssets();
#endif

        Debug.Log("Voxel Nav Bake Complete");
    }

}
