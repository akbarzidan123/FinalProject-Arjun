using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Health health;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            Time.timeScale = 0;
            GameOver();
        }    
    }

    public void GameOver()
    {
        health.gameObject.SetActive(false);
        Debug.Log("YOU LOSE!!");
    }
}
