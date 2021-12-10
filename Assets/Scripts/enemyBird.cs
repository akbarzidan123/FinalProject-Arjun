using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBird : MonoBehaviour
{
    public float enemySpeed;


    Animator enemyAnimator;

    //facing
    public GameObject enemyGraphic;
   

    //attacking
    public float changeTime;
    float startChargeTime;
    bool charging;
    Rigidbody2D enemyRB;

    //for shooting
   


    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponentInChildren<Animator>();
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            startChargeTime = Time.time + changeTime;


        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (startChargeTime < Time.time)
            {
                
                    //enemyAnimator.SetBool("ATTACK", false);
                    enemyAnimator.SetBool("WALK", charging);
                    enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed);
               

            }
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            charging = false;
            enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed);
            enemyAnimator.SetBool("WALK", charging);
            Destroy(gameObject, 0);

        }

    }

  



    
}
