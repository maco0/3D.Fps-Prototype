using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectiles : MonoBehaviour
{
    [SerializeField]
    float damage = 10f;
    Rigidbody rb;
    [SerializeField]
    float speed = 5000f;
    public GameObject rame;
     void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Transform target = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 bulletAccuracy = new Vector3(Random.Range(0, 1.2f), Random.Range(0, 1.2f), Random.Range(0, 1.2f));
        Vector3 direction = (target.position - transform.position)+bulletAccuracy;
        rb.AddForce(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == ("Player"))
        {
            PlayerStats playerhealth = collision.transform.GetComponent<PlayerStats>();
            playerhealth.minusHealth(damage);
            Destroy(rame);

        }
        else { Destroy(rame); }
    }
}
