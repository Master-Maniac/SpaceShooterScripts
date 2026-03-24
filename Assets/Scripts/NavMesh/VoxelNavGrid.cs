using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelNavGrid : MonoBehaviour
{
    [Header("Gizmo Debug")]
    public bool drawBlocked = true;
    public bool drawWalkable = true;

    [Range(0f, 1f)]
    public float walkableAlpha = 0.15f;

    [Header("Slice View")]
    public bool useYSlice = false;
    public int sliceY = 0;
    public VoxelNavData data;

    public bool IsWalkable(Vector3 worldPos)
    {
        Vector3 local = worldPos - data.origin;

        int x = Mathf.FloorToInt(local.x / data.voxelSize);
        int y = Mathf.FloorToInt(local.y / data.voxelSize);
        int z = Mathf.FloorToInt(local.z / data.voxelSize);

        if (x < 0 || y < 0 || z < 0 ||
            x >= data.sizeX ||
            y >= data.sizeY ||
            z >= data.sizeZ)
            return false;

        return data.IsWalkable(x, y, z);
    }
    void OnDrawGizmosSelected()
    {
        if (data == null || data.walkable == null) return;

        float size = data.voxelSize;
        Vector3 half = Vector3.one * size * 0.5f;

        for (int x = 0; x < data.sizeX; x++)
            for (int y = 0; y < data.sizeY; y++)
                for (int z = 0; z < data.sizeZ; z++)
                {
                    if (useYSlice && y != sliceY)
                        continue;

                    bool walkable = data.IsWalkable(x, y, z);
                    if (walkable && !drawWalkable) continue;
                    if (!walkable && !drawBlocked) continue;

                    Vector3 pos = data.origin +
                        new Vector3(x, y, z) * size;

                    if (walkable)
                    {
                        Gizmos.color = new Color(0f, 1f, 0f, walkableAlpha);
                        Gizmos.DrawCube(pos, Vector3.one * size * 0.9f);
                    }
                    else
                    {
                        Gizmos.color = Color.red;
                        Gizmos.DrawWireCube(pos, Vector3.one * size);
                    }
                }
    }
}
