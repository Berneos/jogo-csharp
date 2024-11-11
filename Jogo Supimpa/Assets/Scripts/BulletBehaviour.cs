using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public Rigidbody bulletRigid;
    public float bulletSpeed, despawnTime;

    void Start()
    {
        bulletRigid.AddForce(transform.forward * bulletSpeed * Time.deltaTime, ForceMode.Impulse);
        StartCoroutine(deleteBullet());
    }
    IEnumerator deleteBullet()
    {
        yield return new WaitForSeconds(despawnTime);
        Destroy(this.gameObject);
    }
}
