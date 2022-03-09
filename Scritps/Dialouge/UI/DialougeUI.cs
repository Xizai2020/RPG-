using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class DialougeUI : Singleton<DialougeUI>
{ 
    [Header("Basic")]
    public Image icon;
    public Text mainText;
    public Button nextButton;
    public GameObject dialougePanel;
    [Header("Data")]
    public DialougeData_SO currentData;
    int currentIndex = 0;

    [Header("Option")]
    public RectTransform optionPanel;
    public OptionUI optionUIPrefab;

    protected override void Awake()
    {
        base.Awake();
        nextButton.onClick.AddListener(ContineDialouge);
        DontDestroyOnLoad(gameObject);
    }
    
    private void ContineDialouge()
    {
        if (currentIndex < currentData.dialoguePieces.Count)
        {
            UpdateMainDialouge(currentData.dialoguePieces[currentIndex]);
        }
        else
        {
            dialougePanel.SetActive(false);
        }
        
    }

    public void UpdateDialougeData(DialougeData_SO dialougeData) 
    {
        currentData = dialougeData;
        currentIndex = 0;
    }
    public void UpdateMainDialouge(DialougePiece dialougePiece)
    {
        dialougePanel.SetActive(true);
        currentIndex++;
        if (dialougePiece.image != null)
        {
            icon.enabled = true;
            icon.sprite = dialougePiece.image;
        }
        else
        {
            icon.enabled = false;
        }
        mainText.text = "";
        
        mainText.DOText(dialougePiece.text, 1);
        //mainText.text = dialougePiece.text;
        if (dialougePiece.dialougeOptions.Count == 0 && currentData.dialoguePieces.Count>0)
        {
            nextButton.interactable = true;
            nextButton.gameObject.SetActive(true);
            nextButton.transform.GetChild(0).gameObject.SetActive(true);
            
        }
        else
        {
            //nextButton.gameObject.SetActive(false);
            nextButton.interactable = false;
            nextButton.transform.GetChild(0).gameObject.SetActive(false);
        }
        //´´½¨options
        CreatOptions(dialougePiece);
    }
    void CreatOptions(DialougePiece dialougePiece)
    {
        if (optionPanel.childCount > 0)
        {
            for (int i = 0; i < optionPanel.childCount; i++)
            {
                Destroy(optionPanel.GetChild(i).gameObject);
            }

        }
        for (int i = 0; i < dialougePiece.dialougeOptions.Count; i++)
        {
            var option = Instantiate(optionUIPrefab, optionPanel);
            option.UpdateOption(dialougePiece, dialougePiece.dialougeOptions[i]);
        }
    }

}
