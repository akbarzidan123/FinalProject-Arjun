using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float spdProjectile;
    public float ArrowDamage;
    private float direction;
    private enemyHealth eHealth;
    private float projectTime;
    private bool hit;
    private BoxCollider2D box;

    private void Awake() 
    {
        /*eHealth = GetComponent<enemyHealth>();*/
        box = GetComponent<BoxCollider2D>();
    }
    private void Update() 
    {
        if(hit) return;

        float ms = spdProjectile * Time.deltaTime * direction;
        transform.Translate(ms, 0,0);    

        projectTime += Time.deltaTime;
        if(projectTime > 5)
        {
            gameObject.SetActive(false);
            projectTime = 0;
        }

    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Enemy" && other.gameObject.layer == LayerMask.NameToLayer("ShooEnemy"))
        {
            
            enemyHealth ehealth = other.gameObject.GetComponent<enemyHealth>();
            //Debug.Log("NABARK");
            hit = true;
            deactiveArrow();
            ehealth.addDamage(ArrowDamage);
            box.enabled = false;
        }
    }

    public void setDirection(float _direct)
    {
        direction = _direct;
        gameObject.SetActive(true);
        hit = false;
        box.enabled = true;
        float xScaleArrow = transform.localScale.x;
        if(Mathf.Sign(xScaleArrow) != _direct)
        {
            xScaleArrow = -xScaleArrow;
        }
        transform.localScale = new Vector3(xScaleArrow, transform.localScale.y, transform.localScale.z);
    }

    public void deactiveArrow()
    {
        gameObject.SetActive(false);
    }
}
