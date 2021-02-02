using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class GunPewPew : MonoBehaviour
{
    public float damage = 10f;
    public float range = 60f;
    public float FireRate = 15f;
    private float NextPewPew = 0f;
    public AudioSource pewSound;
    public AudioSource ReloadSound;
    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime =  1f;
    private bool isrealoading = false;
    public Camera fpsCam;
    public ParticleSystem muzzleflash;
    Animator Shooter;
    public Animator reloading;
    public Slider Ammo;
     
    public void PewPlay()
    {
        pewSound.Play();
    }
    public void ReloadPlay()
    {
        ReloadSound.Play();
    }
    void Start()
    {
        Shooter = GetComponent<Animator>();
        currentAmmo = maxAmmo;
    }
    void Update()
    {
        if (isrealoading)
            return;
        if(currentAmmo<=0)
        {
           StartCoroutine (Reloading());
            return;
        }
        if (Input.GetButtonDown("Fire1")&& Time.time >= NextPewPew)
        {
            NextPewPew = Time.time + 3f / FireRate;
            Shooter.SetTrigger("Shoot");
            Pew();
            
        }
        Ammo.value = currentAmmo;
    }

    void Pew()
    {
        PewPlay();
        muzzleflash.Play();
        currentAmmo--;
        RaycastHit hit;
      if(  Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward,out hit, range))
        {
            TARGOT target = hit.transform.GetComponent<TARGOT>();
            if(target!= null)
            { 
                target.TakeDamage(damage);
            }
            trap trap = hit.transform.GetComponent<trap>();
            if (trap != null)
            {
                trap.rickPlay();
            }
            NewLevel levol = hit.transform.GetComponent<NewLevel>();
            if (levol != null)
            {
                levol.scene();
            }
            doorOpeningscript butt = hit.transform.GetComponent<doorOpeningscript>();
            if(butt!= null)
            {
                butt.hit(true);
            }
            winSc  lemmy = hit.transform.GetComponent<winSc>();
            if (lemmy != null)
            {
                lemmy.win();
            }
        }
    }
    IEnumerator Reloading() {

        isrealoading = true;
        ReloadPlay();
        reloading.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime);
        reloading.SetBool("Reloading", false);

        currentAmmo = maxAmmo;
        isrealoading = false;
    }
}
