using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiButton : MonoBehaviour
{
    public Button button;
    private MeauUIContral uIContral;
    public List<GameObject> gameObjects;
    private void Awake()
    {
        button = GetComponent<Button>();
        uIContral = GetComponentInParent<MeauUIContral>();
        
        
    }
    void Start()
    {
        button.onClick.AddListener(OpenUI);
    }

    public void OpenUI()
    {
        
        uIContral.UIClose();
        foreach (var item in gameObjects)
        {
            item.gameObject.SetActive(true);
        }
    }
    public void CloseUI()
    {
        foreach (var item in gameObjects)
        {
            item.gameObject.SetActive(false);
        }
    }
}
