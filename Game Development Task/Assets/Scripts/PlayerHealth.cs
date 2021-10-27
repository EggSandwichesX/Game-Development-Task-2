using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float maxHealth = 100f;

    private float currentHealth;
    public float CurrentHealth
    {
        get
        {
            return currentHealth;
        }
    }


    private float impulseForce;



    private bool isDead = false;
    public bool IsDead
    {
        get
        {
            return isDead;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        isDead = false;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Obstacles")
        {
            currentHealth -= 10;
            Debug.Log(currentHealth);
        }

        if (collision.gameObject.tag == "Ground" && impulseForce >= 20)
        {
            currentHealth -= 10;
        }

        if (collision.gameObject.tag == "Activated")
        {
            if (currentHealth < maxHealth)
            {
                currentHealth += 10;
                Debug.Log(currentHealth);
            }
            
        }

    }

    void Dead()
    {
        isDead = true; // toggle isDead flag to acknowledge GM
    }
}
