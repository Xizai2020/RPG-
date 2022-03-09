using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialougePiece
{
    public string ID;
    public Sprite image;
    [TextArea]
    public string text;
    public QuestData_SO quest;
    [HideInInspector]
    public bool canExpand;
    public List<DialougeOption> dialougeOptions = new List<DialougeOption>();
    
    
    
}
