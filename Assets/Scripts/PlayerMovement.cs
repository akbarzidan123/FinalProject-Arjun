using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float spd;
    [SerializeField] private float jumpPower;
    public static bool NotAttacekd = true;
    private Rigidbody2D rb;
    private Animator anim;
    private bool leftPress;
    private bool rightPress;
    [HideInInspector]
    public bool grounded; 
    // private float spdStop=0;
    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update() 
    {
        if(leftPress && NotAttacekd)
        {
            MoveLeft();
        }
        else if(rightPress && NotAttacekd)
        {
            MoveRight();
        }
    }
    
    public void LeftPressed()
    {
        // Debug.Log("Kiri diteken");
        leftPress = true;
    }
    public void LeftNotPressed()
    {
        anim.SetBool("WALK", false);
        // Debug.Log("Kiri gak diteken");
        leftPress = false;
    }
    public void RightPressed()
    {
        // Debug.Log("Kanan diteken");
        rightPress = true;
    }
    public void RightNotPressed()
    {
        // Debug.Log("Kanan gak diteken");
        anim.SetBool("WALK", false);
        rightPress = false;
    }
    public void MoveLeft()
    {   
        anim.SetBool("WALK", true);
        Vector2 velocity = rb.velocity;// bikin variable velocity buat nyimpen nilai perpindahan data
        Vector3 leftPosition = transform.localScale; // Memasukkan nilai posisi arah karakter
        velocity.x = -spd; //Memasukkan nilai spd ke variable velocity (-) kekiri / kebawah
        rb.velocity = velocity; //mengupdate nilai object sesuai 
        //flip karakter kekiri
        if(leftPosition.x > 0)
        {
            leftPosition = new Vector3(leftPosition.x * -1, leftPosition.y, leftPosition.z);
            transform.localScale = leftPosition;
        }          
    }

    public void MoveRight()
    {   anim.SetBool("WALK", true);
        Vector2 velocity = rb.velocity;// bikin variable velocity buat nyimpen nilai perpindahan data
        Vector3 rightPosition = transform.localScale; // Memasukkan nilai posisi arah karakter
        velocity.x = spd; //Memasukkan nilai spd ke variable velocity (-) kekiri / kebawah
        rb.velocity = velocity; //mengupdate nilai object sesuai velocity
        //Flip karakter ke kanan
        if(rightPosition.x < 0)
        {
            rightPosition = new Vector3(rightPosition.x * -1, rightPosition.y, rightPosition.z);
            transform.localScale = rightPosition;
        }
    }

    public void Jump()
    {
        if(grounded)
        {
            anim.SetBool("JUMP", true);
            Vector2 velocity = rb.velocity;
            velocity.y = jumpPower;
            rb.velocity = velocity;
        }
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Ground")
        {
            anim.SetBool("JUMP", false);
            Debug.Log("Nginjek tanah");
            grounded = true;
        }
    }


}
