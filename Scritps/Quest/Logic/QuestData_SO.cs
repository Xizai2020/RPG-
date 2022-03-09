using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName ="New Quest",menuName ="Quest/Quest Data")]

public class QuestData_SO : ScriptableObject
{
    public string questName;
    [TextArea]
    public string description;
    public bool isStarted;
    public bool isComplete;
    public bool isFinshed;
    [System.Serializable]
    public class QuestRequire
    {
        public string name;
        public int requireAmount;
        public int currentAmount;
    }
    public List<QuestRequire> questRequires = new List<QuestRequire>();
    public List<InventoryItem> rewards = new List<InventoryItem>();
    public void CheckQuestProgress()
    {
        var finishRequire = questRequires.Where(r => r.requireAmount <= r.currentAmount);
        isComplete = finishRequire.Count() == questRequires.Count;
        if (isComplete)
        {
            Debug.Log("任务完成");
        }
    }
    public void GiveRewards()
    {
        foreach (var reward in rewards)
        {
            if (reward.amount < 0)
            {
                int requireCount = Mathf.Abs(reward.amount);
                if (InventoryManager.Instance.QuestItemInBag(reward.ItemData) != null)
                {
                    if (InventoryManager.Instance.QuestItemInBag(reward.ItemData).amount <= requireCount)
                    {
                        requireCount -= InventoryManager.Instance.QuestItemInBag(reward.ItemData).amount;
                        InventoryManager.Instance.QuestItemInBag(reward.ItemData).amount = 0;
                        if (InventoryManager.Instance.QuestItemInAction(reward.ItemData) != null)
                        {
                            InventoryManager.Instance.QuestItemInAction(reward.ItemData).amount -= requireCount;
                        }
                    }
                    else
                    {
                        InventoryManager.Instance.QuestItemInBag(reward.ItemData).amount -= requireCount;
                    }
                }
                else
                {
                    InventoryManager.Instance.QuestItemInAction(reward.ItemData).amount -= requireCount;
                }
            }
            else
            {
                InventoryManager.Instance.inventoryData.AddItem(reward.ItemData, reward.amount);
            }
            InventoryManager.Instance.inventoryUI.RefreshUI();
            InventoryManager.Instance.actionUI.RefreshUI();
        }
    }
    public List<string> RequireTargetName()
    {
        List<string> targetNameList = new List<string>();
        foreach (var require in questRequires)
        {
            targetNameList.Add(require.name);
        }
        return targetNameList;
    }

}
