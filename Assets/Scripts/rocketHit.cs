using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketHit : MonoBehaviour
{
    public float weaponDamage;
    projectileController myPC;

    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Awake()
    {
        myPC = GetComponentInParent<projectileController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //tabrakan 
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Shootable")) {
            myPC.removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if(collision.tag == "Enemy")
            {
                enemyHealth hurtEnemy = collision.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDamage(weaponDamage);
            }
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myPC.removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if (collision.tag == "Enemy")
            {
                enemyHealth hurtEnemy = collision.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDamage(weaponDamage);
            }
        }
    }
}
