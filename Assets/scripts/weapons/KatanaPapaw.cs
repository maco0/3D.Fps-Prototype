using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaPapaw : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public float damage = 35f;
    public float range = 2f;
    public float rate = 20f;
    public float nextSlash = 0f;
    public Camera Fps;
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextSlash)
        {
            nextSlash = Time.time + 1f / rate;
            anim.SetBool("Slash", true);
            slash();
        }
        else if (Input.GetButtonUp("Fire1"))
            anim.SetBool("Slash", false);
    }

    void slash()
    {

        RaycastHit hit;
        if (Physics.Raycast(Fps.transform.position, Fps.transform.forward, out hit, range))
        {
            TARGOT target = hit.transform.GetComponent<TARGOT>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }

    }

}