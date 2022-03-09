using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Dialouge",menuName ="Dialouge/Dialouge Data")]
public class DialougeData_SO : ScriptableObject
{
    public List<DialougePiece> dialoguePieces = new List<DialougePiece>();
    public Dictionary<string, DialougePiece> dialogueIndex = new Dictionary<string, DialougePiece>();

#if UNITY_EDITOR
    private void OnValidate()
    {
        dialogueIndex.Clear();
        foreach (var piece in dialoguePieces)
        {
            if (!dialogueIndex.ContainsKey(piece.ID))
            {
                dialogueIndex.Add(piece.ID, piece);
            }
        }
    }
#else
    void Awake()//��֤�ڴ��ִ�е���Ϸ���һʱ���öԻ��������ֵ�ƥ�� 
    {
        dialogueIndex.Clear();
        foreach (var piece in dialoguePieces)
        {
            if (!dialogueIndex.ContainsKey(piece.ID))
                dialogueIndex.Add(piece.ID, piece);
        }
    }
#endif
    public QuestData_SO GetQuest()
    {
        QuestData_SO currentQuest = null;
        foreach (var piece in dialoguePieces)
        {
            if (piece.quest != null)
            {
                currentQuest = piece.quest;
            }

        }
        return currentQuest;
    }
}
