using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject kodok;
    public Health health;
    [Header("Panel Settings")]
    public GameObject nextwin;
    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public GameObject blurPanel;
    public GameObject OptionPanel;
    public GameObject[] totalMonster;
    public int totalMonsterNumber {get; private set;}
    public static int remainingMOnster;
    

    public int LevelSatu;
    public int LevelDua;
    public int WinStory;
    void Start()
    {
        totalMonsterNumber = totalMonster.Length; 
        remainingMOnster = totalMonster.Length;
        
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            remainingMOnster -= 1;
        }

        GameWin();

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
            remainingMOnster -= 1;
        }
    }

    public void GameOver()
    {
        FindObjectOfType<AudioManager>().play("Lose");
        gameOverPanel.SetActive(true);
        health.gameObject.SetActive(false);
        Time.timeScale=0;
        
        Debug.Log("YOU LOSE!!");
    }
    
    public void GameWin()
    {
        Debug.Log(remainingMOnster);
      
        
        if (remainingMOnster <= 0 && SceneManager.GetActiveScene().buildIndex == LevelSatu)
        {

            blurPanel.SetActive(true);
            nextwin.SetActive(true);
            

        }
        else if (remainingMOnster <= 0 && SceneManager.GetActiveScene().buildIndex == LevelDua)
        {
            SceneManager.LoadScene(WinStory);
        }
        
    }


    public void Nextwin() 
    {
        
        SceneManager.LoadScene(LevelDua);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        blurPanel.SetActive(true);
    }
    public void UnpauseGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        blurPanel.SetActive(false);
    }
    public void RestartGame()
    {
        Time.timeScale=1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        // FindObjectOfType<AudioManager>().play("Click");
        Application.Quit(1);
    }

    public void OptionOpen()
    {
        Time.timeScale = 0;
        OptionPanel.SetActive(true);
        blurPanel.SetActive(true);
    }

    public void OptionClose()
    {
        Time.timeScale = 1;
        OptionPanel.SetActive(false);
        blurPanel.SetActive(false);
        pausePanel.SetActive(false);
    }
}
