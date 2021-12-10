using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float reloadTime;
    [SerializeField] private Transform arrowLoc;
    [SerializeField] private GameObject[] arrows;
    [SerializeField] private PlayerMovement isJump;
    private Animator anim;
    private float cooldownTimer = Mathf.Infinity;
    private void Awake() 
    {
        anim = GetComponent<Animator>();
    }

    private void Update() 
    {
        if(Mathf.Floor(cooldownTimer) == 1)
        {
            // Debug.Log("Stop ATtack");
            anim.SetBool("ATTACK",false);
        }
        cooldownTimer += Time.deltaTime;
    }

    public void Attack()
    {
        if(!isJump.grounded)
        {
            anim.SetBool("JUMP",false);
        }
        if(cooldownTimer > reloadTime)
        {
            anim.SetBool("ATTACK", true);
            arrows[ArrowsShot()].transform.position = arrowLoc.position;
            arrows[ArrowsShot()].GetComponent<Projectile>().setDirection(Mathf.Sign(transform.localScale.x));
            cooldownTimer = 0;
        }
    }
    private int ArrowsShot()
    {
        for(int i = 0; i < arrows.Length; i++)
        {
            if(!arrows[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
