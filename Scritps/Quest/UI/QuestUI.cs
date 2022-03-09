using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : Singleton<QuestUI>
{
    [Header("Elements")]
    public GameObject questPanel;
    public ItemTooTip tooTip;
    private bool isOpen;
    [Header("Quest Name")]
    public RectTransform questListTransform;
    public QuestNameButton questNameButton;
    [Header("Text Content")]
    public Text questContentText;
    [Header("RequireMent")]
    public RectTransform requireTransform;
    public QuestRequireMent requireMent;
    [Header("RewardPanel")]
    public RectTransform rewardTransform;
    public ItemUI rewardUI;
    protected override void Awake()
    {
        base.Awake();
        
    }
    private void Start()
    {
        GetComponent<UiButton>().button.onClick.AddListener(SetUI);
    }

    private void SetUI()
    {
        questContentText.text = "";
        //显示面板内容
        SetUpQuestList();
        
    }

    private void Update()
    {/*
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isOpen = !isOpen;
            questPanel.SetActive(isOpen);
            questContentText.text = "";
            //显示面板内容
            SetUpQuestList();
            

        }
        if (isOpen)
        {
            tooTip.gameObject.SetActive(false);
        }
        */
    }

    public void SetUpQuestList()
    {
        foreach (Transform item in questListTransform)
        {
            Destroy(item.gameObject);
        }
        foreach (Transform item in rewardTransform)
        {
            Destroy(item.gameObject);
        }
        foreach (Transform item in requireTransform)
        {
            Destroy(item.gameObject);
        }
        //生成任务
        foreach (var task in QuestManager.Instance.tasks)
        {
            var newTask = Instantiate(questNameButton, questListTransform);
            newTask.SetupNameButton(task.questData);
           // newTask.questContent = questContentText;
           // questContentText = newTask.questContent;
        }
    }
    public void SetupRequireList(QuestData_SO questData)
    {
        questContentText.text = questData.description;
        foreach (Transform item in requireTransform)
        {
            Destroy(item.gameObject);
        }
        foreach (var require in questData.questRequires)
        {
            var q = Instantiate(requireMent, requireTransform);
            if (questData.isFinshed)
            {
                q.SetupRequirement(require.name, questData.isFinshed);
            }
            else
            {
                q.SetupRequirement(require.name, require.requireAmount, require.currentAmount);
            }
            
        }
    }
    public void SetupRewardItem(ItemData_SO itemData, int amount)
    {
        var item = Instantiate(rewardUI, rewardTransform);
        item.SetUpItemUI(itemData, amount);
    }
}
