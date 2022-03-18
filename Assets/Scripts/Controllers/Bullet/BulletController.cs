using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Vector3 forward;
    public AudioClip fireAudioClip;

    public void Action()
    {
        SingletonProvider.Instance.Get<ObjectPoolController>().MarkAsUsed(gameObject);

        var rb = GetComponent<Rigidbody>();
        rb.AddForce(forward.normalized * 40, ForceMode.VelocityChange);
        rb.AddTorque(new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized * 10000.0f, ForceMode.VelocityChange);

        FindObjectOfType<PlayerCameraPositionController>().shakeTimer = Time.time + (Time.deltaTime * 10.0f);

        var sfx = GetComponent<AudioSource>();
        sfx.Stop();
        sfx.pitch = Random.Range(0.8f, 1.0f);
        sfx.PlayOneShot(fireAudioClip);
    }

    void Update()
    {
        if (SingletonProvider.Instance.Get<ObjectPoolController>().IsMarkedAsUnused(gameObject))
        {
            var rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        var objectPool = SingletonProvider.Instance.Get<ObjectPoolController>();

        if (objectPool.IsMarkedAsUsed(gameObject))
        {
            objectPool.MarkAsUnused(gameObject);

        }
    }
}
