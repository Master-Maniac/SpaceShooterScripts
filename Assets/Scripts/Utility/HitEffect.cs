using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    [SerializeField]internal float lifeTime = 1f;
    GameObject prefabRef;

    public void Init(GameObject prefab)
    {
        prefabRef = prefab;
        Invoke(nameof(ReturnToPool), lifeTime);
    }

    void ReturnToPool()
    {
        ObjectPool.Instance.Despawn(prefabRef, gameObject);
    }
}
