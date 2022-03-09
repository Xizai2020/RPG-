using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditorInternal;
using System;
using System.IO;

[CustomEditor(typeof(DialougeData_SO))]
public class DialougeCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Open in Editor"))
        {
            DialougeEditor.IntWindow((DialougeData_SO)target);
        }

        base.OnInspectorGUI();

    }
}
public class DialougeEditor : EditorWindow
{
    DialougeData_SO currentData;

    ReorderableList pieceList = null;

    Vector2 scrollPos=Vector2.zero;
    Dictionary<string, ReorderableList> optionListDict = new Dictionary<string, ReorderableList>();
    [MenuItem("PGGTools/Dialouge Editor")]
    public static void Init()
    {
        DialougeEditor dialougeEditor = GetWindow<DialougeEditor>("Dialouge Editor");
        dialougeEditor.autoRepaintOnSceneChange = true;
    }
    public static void IntWindow(DialougeData_SO data)
    {
        DialougeEditor dialougeEditor = GetWindow<DialougeEditor>("Dialouge Editor");
        dialougeEditor.currentData = data;
    }
    [OnOpenAsset]
    public static bool OpenAsset(int instancID,int Line)
    {
        DialougeData_SO data = EditorUtility.InstanceIDToObject(instancID) as DialougeData_SO;
        if (data != null)
        {
            DialougeEditor.IntWindow(data);
            return true;
        }
        return false;
    }
    private void OnSelectionChange()
    {
        //选择改变时调用一次
        var newData = Selection.activeObject as DialougeData_SO;
        if (newData != null)
        {
            currentData = newData;
            SetRecorderableList();
        }
        else
        {
            currentData = null;
            pieceList = null;
        }
        Repaint();
    }
    private void OnGUI()
    {
        if (currentData != null)
        {
            EditorGUILayout.LabelField(currentData.name, EditorStyles.boldLabel);
            GUILayout.Space(10);

            scrollPos = GUILayout.BeginScrollView(scrollPos, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            if (pieceList == null)
            {
                SetRecorderableList();
            }
            pieceList.DoLayoutList();
            GUILayout.EndScrollView();
        }
        else
        {
            if (GUILayout.Button("创建新对话"))
            {
                string datapath= "Assets/GameDate/DialougeData/";
                if (!Directory.Exists(datapath))
                {
                    Directory.CreateDirectory(datapath);
                }
                DialougeData_SO newData = ScriptableObject.CreateInstance<DialougeData_SO>();
                AssetDatabase.CreateAsset(newData, datapath + "/" + "New Dialouge.asset");
                currentData = newData;
            }
            GUILayout.Label("没有选择对话数据", EditorStyles.boldLabel);
        }
    }
    private void SetRecorderableList()
    {
        pieceList = new ReorderableList(currentData.dialoguePieces, typeof(DialougeData_SO), true, true, true, true);
        pieceList.drawHeaderCallback += OnDrawPieceHoder;
        pieceList.drawElementCallback += OnDrawPieceElement;
        pieceList.elementHeightCallback += OnHeightChanged;

    }

    private float OnHeightChanged(int index)
    {
        return GetPieceHeight(currentData.dialoguePieces[index]);
    }
    float GetPieceHeight(DialougePiece piece)
    {
        var height = EditorGUIUtility.singleLineHeight;
        var isExPand = piece.canExpand;
        if (isExPand)
        {
            height = EditorGUIUtility.singleLineHeight * 9;
            var options = piece.dialougeOptions;
            if (options.Count > 1)
            {
                height += EditorGUIUtility.singleLineHeight * options.Count;
            }
        }

        return height;
    }

    private void OnDrawPieceElement(Rect rect, int index, bool isActive, bool isFocused)
    {
        EditorUtility.SetDirty(currentData);
        if (index < currentData.dialoguePieces.Count)
        {
            var currentPiece = currentData.dialoguePieces[index];

            var tempRect = rect;

            tempRect.height = EditorGUIUtility.singleLineHeight;
            

            currentPiece.canExpand = EditorGUI.Foldout(tempRect, currentPiece.canExpand, currentPiece.ID);
            if (currentPiece.canExpand)
            {
                
                tempRect.width = 30;
                tempRect.y += tempRect.height;
                EditorGUI.LabelField(tempRect, "ID");

                tempRect.x =tempRect.x+ tempRect.width;
                tempRect.width = 100;
                currentPiece.ID = EditorGUI.TextField(tempRect, currentPiece.ID);

                tempRect.x += tempRect.width + 10;
                EditorGUI.LabelField(tempRect, "Quest");

                tempRect.x +=45;
                currentPiece.quest = (QuestData_SO)EditorGUI.ObjectField(tempRect, currentPiece.quest, typeof(QuestData_SO), false);

                tempRect.y += EditorGUIUtility.singleLineHeight + 5;
                tempRect.x = rect.x;
                tempRect.height = 60;
                tempRect.width = tempRect.height;
                currentPiece.image = (Sprite)EditorGUI.ObjectField(tempRect, currentPiece.image, typeof(Sprite), false);

                //文本框
                tempRect.x += tempRect.width + 5;
                tempRect.width = rect.width - tempRect.x;
                currentPiece.text = (string)EditorGUI.TextField(tempRect, currentPiece.text);

                //画选项
                tempRect.y += tempRect.height + 5;
                tempRect.x = rect.x;
                tempRect.width = rect.width;

                string optionListKey = currentPiece.ID + currentPiece.text;
                if (optionListKey != string.Empty)
                {
                    if (!optionListDict.ContainsKey(optionListKey))
                    {
                        var optionList = new ReorderableList(currentPiece.dialougeOptions, typeof(DialougeOption), true, true, true, true);
                        optionList.drawHeaderCallback = OnDrawOptionHoder;
                        optionList.drawElementCallback = (optionRect, optionIndex, optionActive, optionFocued) =>
                        {
                            OnDrawOptioneElement(currentPiece, optionRect, optionIndex, optionActive, optionFocued);
                        };
                        optionListDict[optionListKey] = optionList;
                    }
                    optionListDict[optionListKey].DoList(tempRect);
                }
            }

            //GUILayout.Space(10);
        }
    }

    private void OnDrawOptionHoder(Rect rect)
    {
        GUI.Label(rect, "Option Text");
        rect.x += rect.width * 0.5f + 10;
        GUI.Label(rect, "Target ID");
        rect.x += rect.width * 0.3f;
        GUI.Label(rect, "Apply");
    }

    private void OnDrawOptioneElement(DialougePiece currentPiece, Rect optionRect, int optionIndex, bool optionActive, bool optionFocued)
    {
        var currentOption = currentPiece.dialougeOptions[optionIndex];
        var tempRect = optionRect;

        tempRect.width = optionRect.width * 0.5f;
        currentOption.Info = EditorGUI.TextField(tempRect, currentOption.Info);

        tempRect.x += tempRect.width+5;
        tempRect.width = optionRect.width * 0.3f;
        currentOption.targetID = EditorGUI.TextField(tempRect, currentOption.targetID);

        tempRect.x += tempRect.width + 5;
        tempRect.width = optionRect.width * 0.2f;
        currentOption.talkQuest = EditorGUI.Toggle(tempRect, currentOption.talkQuest);

    }

    private void OnDisable()
    {
        optionListDict.Clear();
    }
    private void OnDrawPieceHoder(Rect rect)
    {
        GUI.Label(rect, "Dialouge Pieces");
    }
}
