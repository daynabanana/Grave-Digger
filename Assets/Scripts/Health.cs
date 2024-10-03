using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

public int maxHealth = 3;
public int currentHealth; 
public GameObject player;
public HealthBar healthBar; 


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); 
    }

    // Update is called once per frame
    void Update()
    {
      
        if (currentHealth <= 0)
        {
            Destroy(player);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    IEnumerator ColliderCooldown(Collider2D Bob) 
    {
        yield return new WaitForSeconds(1.0f);
        Bob.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D Bob)
    {
        if (Bob.CompareTag("Enemy"))
        {
            Bob.enabled = false;
            StartCoroutine(ColliderCooldown(Bob));
            TakeDamage(1);
        }
       
    }
}
