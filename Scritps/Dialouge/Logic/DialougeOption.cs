using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialougeOption
{
    public string Info;
    public string targetID;
    public bool talkQuest;
    public bool shopOpen;
    [Header("Shop")]
    public InventoryData_SO shop;
}
