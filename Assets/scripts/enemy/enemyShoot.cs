using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour
{
   
    [SerializeField]
    GameObject projectile;
    public float lookradius = 10f;
    Transform target;
    public ParticleSystem blueFlash;

    [SerializeField]
    Transform shootpoint;
    float turnSpeed = 10f;
    float firerate = 0.2f;

    public AudioSource laser;
    void laserPlay()
    {
        laser.Play();
    }
     void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;   
    }

     void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookradius)
        {
            firerate -= Time.deltaTime;
            Vector3 direction = transform.position - target.position;
            Quaternion lookrotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookrotation, Time.deltaTime * turnSpeed);

            
        }
        if (firerate<= 0)
        {
            firerate = 0.5f;
            Shoot();
        }
        
    }

    void Shoot()
    {
        laserPlay();
        blueFlash.Play();
        Instantiate(projectile, shootpoint.position, shootpoint.rotation);
    }


   
}
