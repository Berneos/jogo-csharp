using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGun : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawn;
    public Animator gunAnim;
    public string shootAnimationName;
    public AudioSource shootSound;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
                gunAnim.Play(shootAnimationName);
                Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
                shootSound.Play();
            
        }
    }
}
