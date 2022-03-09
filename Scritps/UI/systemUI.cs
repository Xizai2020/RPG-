using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class systemUI : MonoBehaviour
{
    public SaveManager saveManager;
    void Start()
    {
        saveManager = FindObjectOfType<SaveManager>();
    }
    public void BtnSave()
    {
        SaveManager.Instance.SavePlayerData();
        SaveManager.Instance.SaveInvenQuest();
        

    }
    
    void Update()
    {
        
    }
}
