using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Health health;
    public GameObject gameOverPanel;
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
        gameOverPanel.SetActive(true);
        health.gameObject.SetActive(false);
        Debug.Log("YOU LOSE!!");
    }
}
