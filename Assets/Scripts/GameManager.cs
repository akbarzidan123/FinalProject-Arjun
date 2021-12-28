using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject kodok;
    public Health health;
    public GameObject gameOverPanel;
    public GameObject[] totalMonster;
    public int totalMonsterNumber {get; private set;}
    public static int remainingMOnster;
    void Start()
    {
        totalMonsterNumber = totalMonster.Length; 
        remainingMOnster = totalMonster.Length;
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
        if (other.tag == "Enemy")
        {
            kodok.SetActive(false);
        }
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        health.gameObject.SetActive(false);
        Time.timeScale=0;
        Debug.Log("YOU LOSE!!");
    }
    
    public void GameWin()
    {
        Debug.Log(remainingMOnster);
        if(remainingMOnster <= 0)
        {
            Debug.Log("U WIN THE GAME");
        }
    }

    public void PauseGame()
    {
        // Time.Delta
    }
}
