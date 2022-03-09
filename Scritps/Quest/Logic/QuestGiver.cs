using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialougeControl))]
public class QuestGiver : MonoBehaviour
{
    public DialougeControl dialougeControl;
    public  QuestData_SO currentQuest;

    [Header("Dialouge State")]
    public DialougeData_SO startDialouge;
    public DialougeData_SO proressDialogue;
    public DialougeData_SO compelteDialouge;
    public DialougeData_SO finishDialouge;

    #region 获取任务状态
    public bool IsStart
    {
        get
        {
            if (QuestManager.Instance.HaveQuest(currentQuest))
            {
                return QuestManager.Instance.GetTask(currentQuest).IsStarted;
            }
            else
            {
                return false;
            }
        }
    }
    public bool IsCompelte
    {
        get
        {
            if (QuestManager.Instance.HaveQuest(currentQuest))
            {
                return QuestManager.Instance.GetTask(currentQuest).IsCompelte;
            }
            else
            {
                return false;
            }
        }
    }
    public bool IsFinshed
    {
        get
        {
            if (QuestManager.Instance.HaveQuest(currentQuest))
            {
                return QuestManager.Instance.GetTask(currentQuest).IsFinshed;
            }
            else
            {
                return false;
            }
        }
    }
    #endregion
    private void Awake()
    {
        dialougeControl = GetComponent<DialougeControl>();

    }
    private void Start()
    {
        dialougeControl.currentData = startDialouge;
        currentQuest = dialougeControl.currentData.GetQuest();

    }
    private void Update()
    {
        if (IsStart)
        {
            if (IsCompelte)
            {
                dialougeControl.currentData = compelteDialouge;
            }
            else
            {
                dialougeControl.currentData = proressDialogue;
            }
        }
        
        if (IsFinshed)
        {
            dialougeControl.currentData = finishDialouge;
        }
    }
}
