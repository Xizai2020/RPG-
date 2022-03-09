using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    private Button buttonBack;
    private Button buttonOver;
    private GameObject gameOverUI;
    private void Awake()
    {
        buttonBack = transform.GetChild(0).transform.GetChild(0).GetComponent<Button>();
        buttonOver = transform.GetChild(0).transform.GetChild(1).GetComponent<Button>();
        gameOverUI = transform.GetChild(0).gameObject;
    }

    private void OverButton()
    {
        Application.Quit();
    }

    private void BackButton()
    {
        SaveManager.Instance.SavePlayerData();
        SaveManager.Instance.SaveInvenQuest();
        SceneCtroll.Instance.TranstionToMain();
    }

    void Start()
    {
        buttonBack.onClick.AddListener(BackButton);
        buttonBack.onClick.AddListener(OverButton);
    }

    void Update()
    {
        if (GameManager.Instance.playerCharterstate != null)
        {
            if (GameManager.Instance.playerCharterstate.CurrentHealth <= 0)
            {
                gameOverUI.SetActive(true);
                Time.timeScale = 0;
            }
        }
        else
        {
            gameOverUI.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
