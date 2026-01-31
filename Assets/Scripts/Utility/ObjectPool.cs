using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    Dictionary<string, Queue<GameObject>> pool = new();

    void Awake()
    {
        Instance = this;
    }

    public GameObject Spawn(GameObject prefab, Vector3 pos, Quaternion rot)
    {
        if (!pool.ContainsKey(prefab.name))
            pool[prefab.name] = new Queue<GameObject>();

        GameObject obj;

        if (pool[prefab.name].Count > 0)
        {
            obj = pool[prefab.name].Dequeue();
            obj.SetActive(true);
        }
        else
        {
            obj = Instantiate(prefab);
        }

        obj.transform.SetPositionAndRotation(pos, rot);
        return obj;
    }

    public void Despawn(GameObject prefab, GameObject obj)
    {
        obj.SetActive(false);
        pool[prefab.name].Enqueue(obj);
    }
}
