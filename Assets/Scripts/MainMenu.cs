﻿using System.Collections;
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
    public int LevelDua;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().play("MenuBackground");
    }


    public void ToGameScene()
    {
        FindObjectOfType<AudioManager>().play("Click");
        SceneManager.LoadScene(StoryLineAwal);
    }
    public void ToMainScene()
    {
        FindObjectOfType<AudioManager>().play("Click");
        SceneManager.LoadScene(MainMenuScene);
    }
    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().play("Click");
        Application.Quit(1);
    }
    public void ToSetting()
    {
        FindObjectOfType<AudioManager>().play("Click");
        SceneManager.LoadScene(SettingMenu);
    }
}
