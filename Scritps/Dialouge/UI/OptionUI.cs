using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    public Text optionText;
    private Button button;
    private DialougePiece currentDialougePiece;

    private string nextPieceID;
    private bool takeQuest;
    private bool isShop;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnOptionClicked);
    }
    public void UpdateOption(DialougePiece dialougePiece, DialougeOption option)
    {
        currentDialougePiece = dialougePiece;
        optionText.text = option.Info;
        nextPieceID = option.targetID;
        takeQuest = option.talkQuest;
        InventoryManager.Instance.shop = option.shop;
        isShop = option.shopOpen;
    }
    private void OnOptionClicked()
    {
        if (currentDialougePiece.quest != null)
        {
            var newTask = new QuestManager.QuestTask
            {
                questData = Instantiate(currentDialougePiece.quest)
            };
            if (takeQuest)
            {
                //��������б���
                //�ж��Ƿ��Ѿ�������
                if (QuestManager.Instance.HaveQuest(newTask.questData))
                {
                    //�ж��Ƿ���ɸ��轱��
                    newTask.questData.GiveRewards();
                    QuestManager.Instance.GetTask(newTask.questData).IsFinshed = true;
                }
                else
                {
                    //û�����񡣽�������
                    QuestManager.Instance.tasks.Add(newTask);
                    QuestManager.Instance.GetTask(newTask.questData).IsStarted=true;
                    foreach (var requireItem in newTask.questData.RequireTargetName())
                    {
                        InventoryManager.Instance.CheckQuestItemInBag(requireItem);
                    }
                }
            }
        }
        if (isShop)
        {
            InventoryManager.Instance.ShopPanel.SetActive(true);
            InventoryManager.Instance.shopInventoryUI.RefreshUI();

            if (InventoryManager.Instance.shop != null)
            {
                InventoryManager.Instance.ShopUI.RefreshUI();
            }
        }
        if (nextPieceID == "")
        {
            DialougeUI.Instance.dialougePanel.SetActive(false);
            return;
        }
        else
        {
            DialougeUI.Instance.UpdateMainDialouge(DialougeUI.Instance.currentData.dialogueIndex[nextPieceID]);
        }
    }



}
