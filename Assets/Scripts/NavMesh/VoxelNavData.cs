using UnityEngine;

[CreateAssetMenu(menuName = "Navigation/Voxel Nav Data")]
public class VoxelNavData : ScriptableObject
{
    public int sizeX, sizeY, sizeZ;
    public float voxelSize;
    public Vector3 origin;

    // Flattened array for serialization
    public bool[] walkable;

    public int ToIndex(int x, int y, int z)
    {
        return x + sizeX * (y + sizeY * z);
    }

    public bool IsWalkable(int x, int y, int z)
    {
        return walkable[ToIndex(x, y, z)];
    }
}
