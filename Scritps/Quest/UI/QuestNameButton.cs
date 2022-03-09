using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuestNameButton : MonoBehaviour
{
    public Text questNameText;
    public QuestData_SO currentDate;
    //public Text questContent;
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(UodateQuestContent);
    }

    private void UodateQuestContent()
    {
    //    questContent.text = currentDate.description;
        QuestUI.Instance.SetupRequireList(currentDate);
        foreach (Transform item in QuestUI.Instance.rewardTransform)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in currentDate.rewards)
        {
            QuestUI.Instance.SetupRewardItem(item.ItemData, item.ItemData.itemAmount);
        }
    }

    public void SetupNameButton(QuestData_SO questData)
    {
        currentDate = questData;
        if (questData.isComplete)
        {
            questNameText.text = questData.questName + "(Íê³É)";
        }
        else
        {
            questNameText.text = questData.questName;
        }
    }

}
