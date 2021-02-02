using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    PlayerStats player;
    public float heal = 20f;
    // Start is called before the first frame update
    void Awake()
    {
        player = FindObjectOfType<PlayerStats>();   
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 15, 0) * Time.deltaTime*5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player.currentHealth < player.PlayerHealth)
        {
            Destroy(gameObject);
            player.currentHealth = player.currentHealth + heal;
            if (player.currentHealth >= player.PlayerHealth)
                player.currentHealth = player.PlayerHealth;
        }
    }
}
