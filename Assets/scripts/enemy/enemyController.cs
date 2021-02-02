using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class enemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;
    public AudioSource killerQueen;
    public AudioSource bitesTheDust;
    public ParticleSystem Kaboom;
    public float damage = 20f;
    PlayerStats player;
   public  Animator anim;
  
    public ParticleSystem rocket1;
    public ParticleSystem rocket2;
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerStats>();
       
       
    }
    
      
    


    public void KillerPlay()
    {
        killerQueen.Play();
    }
    public void BitesPlay()
    {
       bitesTheDust.Play();
    }
    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {

            anim.SetBool("spot", false);
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance)
            {
                faceTarget();
              
            }
            
         
        }
        else
        {
            spot(true);
        }
    }
    void faceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookrotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookrotation,Time.deltaTime*5f);



    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void Boom()
    {
        PlayerStats playerHealth = GetComponent<PlayerStats>();
            player.currentHealth = player.currentHealth - damage;
        if (player.currentHealth <= 0) {
            SceneManager.LoadScene(3);
}
        BitesPlay();
        Kaboom.Play();
        KillerPlay();
        Destroy(gameObject,0.4f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boom")
        {
           

            Boom();
            
           
        }
    }

    void spot(bool x)
    {
        if (x == true)
        {

            rocket1.Play();
            rocket2.Play();
            anim.SetBool("spot", true);
        }
       
    }
  
    
}
