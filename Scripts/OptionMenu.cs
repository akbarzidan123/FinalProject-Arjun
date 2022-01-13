using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class OptionMenu : MonoBehaviour
{
    [Header("Index Game")]
    public int MainMenuScene;
    public GameObject next;
    public GameObject prev;

    // Start is called before the first frame update
    void Start()
    {
        // FindObjectOfType<AudioManager>().play("MenuBackground");
    }

    public void ToMainScene()
    {
        // FindObjectOfType<AudioManager>().play("Click");
        SceneManager.LoadScene(MainMenuScene);
    }
    public void QuitGame()
    {
        // FindObjectOfType<AudioManager>().play("Click");
        Application.Quit(1);
    }
   
    public void CreditNext()
    {
        next.SetActive(true);
        prev.SetActive(false);
    }
    public void CreditPrev()
    {
        prev.SetActive(true);
        next.SetActive(false);
    }
}
