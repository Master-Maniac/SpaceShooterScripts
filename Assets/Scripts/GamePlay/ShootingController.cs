using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [Header("Gun Settings")]
    public float damage = 25f;
    public float range = 100f;
    public float fireRate = 5f;   // shots per second

    [Header("References")]
    public Camera fpsCamera;

    float nextTimeToFire = 0f;

    void Update()
    {
        Debug.DrawRay(fpsCamera.transform.position, fpsCamera.transform.forward*100, Color.green);
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = new Ray(fpsCamera.transform.position, fpsCamera.transform.forward);
        RaycastHit hit;
      
        Vector3 endPoint = ray.origin + ray.direction * range;

        if (Physics.Raycast(ray, out hit, range))
        {
            endPoint = hit.point;
            SurfaceInfo surface = hit.collider.GetComponent<SurfaceInfo>();

            if (surface != null && surface.effectHolder != null)
            {
                GameObject fx = ObjectPool.Instance.Spawn(surface.effectHolder.hitEffectPrefab,hit.point,Quaternion.LookRotation(hit.normal)
                );

                fx.GetComponent<HitEffect>()?.Init(surface.effectHolder.hitEffectPrefab);
            }
            // Damage logic
            // Health target = hit.transform.GetComponent<Health>();
            //if (target != null)
            //{
            //    target.TakeDamage(damage);
            //}

            Debug.Log("Hit: " + hit.transform.gameObject.name);
        }

    }

  
}
