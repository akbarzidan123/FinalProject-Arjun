using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [Header("Index Game")]
    public int MainMenuScene;
    public int SettingMenu;
    public int StoryLineAwal;
    public int LevelSatu;
    public int LevelDua{get;private set;}

    public static int toLevel;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().play("MenuBackground");
    }
    public void ToGameScene()
    {
       
        FindObjectOfType<AudioManager>().play("Click");
        if(toLevel < 1 )
        {
            SceneManager.LoadScene(StoryLineAwal);
        }
        else
        {
            SceneManager.LoadScene(LevelSatu);
        }
        toLevel++;
    }
    public void ToMainScene()
    {
        FindObjectOfType<AudioManager>().play("Click");
        SceneManager.LoadScene(MainMenuScene);
    }
    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().play("Click");
        Application.Quit();
    }
    public void ToSetting()
    {
        FindObjectOfType<AudioManager>().play("Click");
        SceneManager.LoadScene(SettingMenu);
    }
}
