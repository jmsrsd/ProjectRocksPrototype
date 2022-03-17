using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;

    public GameObject bulletShellPrefab;
    public Transform bulletShellSpawnPoint;

    public Transform head;
    private Vector3 headUnfireLocalPosition;
    public Vector3 headFireLocalPosition;

    public float firingTimer;

    float FiringRate
    {
        get => 60.0f / 600.0f;
    }

    bool Firable
    {
        get => Time.time >= firingTimer;
    }

    bool Firing
    {
        get => Input.GetMouseButton(0);
    }

    void Awake()
    {
        if (head != null)
        {
            headUnfireLocalPosition = head.transform.localPosition;
        }
    }

    void SpawnBulletShell()
    {
        if (bulletShellPrefab != null)
        {
            GameObject go;
            var unused = SingletonProvider.Instance.Get<ObjectPoolController>().UnusedObjects<BulletShellController>();

            if (unused.Count == 0)
            {
                go = Instantiate(bulletShellPrefab, bulletShellSpawnPoint.position, Quaternion.identity);
            }
            else
            {
                go = unused.First().gameObject;
            }


            var controller = go.GetComponent<BulletShellController>();
            controller.transform.position = bulletShellSpawnPoint.position;
            controller.left = Vector3.Cross(head.forward, Vector3.up);
            controller.forward = head.forward;
            controller.Action();
        }
    }

    void SpawnBullet()
    {
        if (bulletPrefab != null)
        {
            GameObject go;
            var unused = SingletonProvider.Instance.Get<ObjectPoolController>().UnusedObjects<BulletController>();

            if (unused.Count == 0)
            {
                go = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                go = unused.First().gameObject;
            }


            var controller = go.GetComponent<BulletController>();
            controller.transform.position = transform.position;
            controller.forward = head.forward;
            controller.Action();
        }
    }

    void Update()
    {
        if (Firable)
        {


            if (Firing)
            {
                firingTimer = Time.time + FiringRate;

                SpawnBullet();
                SpawnBulletShell();

                if (head != null)
                {
                    head.transform.localPosition = headFireLocalPosition;
                }
            }
        }

        if (head != null)
        {
            if (Firable == false)
            {

                head.transform.localPosition = Vector3.MoveTowards(head.transform.localPosition, headUnfireLocalPosition, (Time.deltaTime / 2.0f) / FiringRate);
            }
        }
    }
}
