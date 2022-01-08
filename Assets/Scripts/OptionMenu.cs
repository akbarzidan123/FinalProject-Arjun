using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class OptionMenu : MonoBehaviour
{
    [Header("Index Game")]
    public int MainMenuScene;
    
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
   
    public void Credit()
    {

    }
}
