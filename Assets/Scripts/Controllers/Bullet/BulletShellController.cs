using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShellController : MonoBehaviour
{
    public Vector3 forward;
    public Vector3 left;

    public void Action() {
        SingletonProvider.Instance.Get<ObjectPoolController>().MarkAsUsed(gameObject);

        var rb = GetComponent<Rigidbody>();
        rb.AddForce((left + Vector3.down).normalized * 15, ForceMode.VelocityChange);
        rb.AddTorque(new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized * 10000.0f, ForceMode.VelocityChange);
    }

    void OnCollisionEnter(Collision collision) {
        var objectPool = SingletonProvider.Instance.Get<ObjectPoolController>();

        if (objectPool.IsMarkedAsUsed(gameObject)) {
            objectPool.MarkAsUnused(gameObject);
        }
    }
}
