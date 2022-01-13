using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RemaininigMonsterUI : MonoBehaviour
{
    public GameManager totalMons;
    // Start is called before the first frame update
    Text text;
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        string monsterUI = "Clear Monsters = " + GameManager.remainingMOnster + " / " + totalMons.totalMonsterNumber;
        text.text = monsterUI;
    }
}

