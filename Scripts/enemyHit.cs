using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHit : MonoBehaviour
{
    public float weaponDamage;
    projectileController myPC;
    public float pushBackForce;

    //public GameObject explosionEffect;

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
        if (collision.gameObject.layer == LayerMask.NameToLayer("ShooPlayer"))
        {
            
            myPC.removeForce();
            //Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if (collision.tag == "Player")
            {
                Health hurtEnemy = collision.gameObject.GetComponent<Health>();
                hurtEnemy.TakeDmg(weaponDamage);
                //Debug.Log("enemyhit" + weaponDamage);
                pushBack(collision.transform);
            }
        }
    }
    void pushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2((pushedObject.position.x - transform.position.x), 0).normalized;
        pushDirection *= pushBackForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
        
    }
}
