using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyDamage : MonoBehaviour
{
    public float damage;
    public float pushBackForce;
    //public PlayerMovement pM;
    public float jeda;

    // indeks 0 kiri, 1 kanan, 2 attack, 3 jump

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" ) {
            Health thePlayerHealth = other.gameObject.GetComponent<Health>();
            thePlayerHealth.TakeDmg(damage);
            //nextDamage = Time.time + damageRate
            pushBack(other.transform);
            StartCoroutine(disableMove());
        }
    }
    IEnumerator disableMove()
    {
        PlayerMovement.NotAttacekd = false;
        yield return new WaitForSeconds(jeda);
        PlayerMovement.NotAttacekd = true;
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
