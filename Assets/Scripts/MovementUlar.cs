using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementUlar : MonoBehaviour
{
    Animator enemyAnimator;

    //facing
    public GameObject enemyGraphic;
    bool canFlip = true;
    bool facingRight = false;
    
    float flipTime = 5f;
    float nextFlipChance = 0f;

    //attacking
    public float changeTime;
    float startChargeTime;
    bool charging;
    Rigidbody2D enemyRB;

    //for shooting
    public Transform gunTip;
    public GameObject bullet;
    public float fireRate = 0.5f;
    float nextFire = 0f;


    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponentInChildren<Animator>();
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFlipChance)
        {
            if (Random.Range(0, 10) >= 5) flipFacing();
            nextFlipChance = Time.time + flipTime;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (facingRight && other.transform.position.x < transform.position.x)
            {
                flipFacing();
            }
            else if (!facingRight && other.transform.position.x > transform.position.x)
            {
                flipFacing();
            }
            canFlip = false;
            charging = true;
            startChargeTime = Time.time + changeTime;
        
            
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (startChargeTime < Time.time)
            {
                //koentjinya
                if (!facingRight)
                {
                    enemyAnimator.SetBool("ATTACK", false);
                    // enemyAnimator.SetBool("WALK", charging);
                    // enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed);
                }
                else
                {
                    enemyAnimator.SetBool("ATTACK", false);
                    // enemyAnimator.SetBool("WALK", charging);
                    // enemyRB.AddForce(new Vector2(1, 0) * enemySpeed); 
                }
                fireRocket();
                //enemyAnimator.SetBool("ATTACK", charging);
                //enemyAnimator.SetBool("WALK", charging);
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            canFlip = true;
            charging = false;
            enemyRB.velocity = new Vector2(0f, 0f);
            enemyAnimator.SetBool("ATTACK", charging);
            // enemyAnimator.SetBool("WALK", charging);
         

        }

    }

    void fireRocket()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            }
        }
        
    }

   

    void flipFacing()
    {
        if (!canFlip) return;
        float facingX = enemyGraphic.transform.localScale.x;
        facingX *= -1f;
        enemyGraphic.transform.localScale = new Vector3(facingX, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z);
        facingRight = !facingRight;
    }
  }


    