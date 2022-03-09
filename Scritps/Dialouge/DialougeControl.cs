using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougeControl : MonoBehaviour
{
    public DialougeData_SO currentData;
    bool canTalk = false;
    public GameObject ui;
    private Button button;
    private void Awake()
    {
        ui = transform.GetChild(0).gameObject;
        button = transform.GetChild(0).GetChild(0).GetComponent<Button>();
    }
    private void Start()
    {
        button.onClick.AddListener(ClickCanTask);
    }

    private void ClickCanTask()
    {
        if (canTalk)
        {
            OpenDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && currentData != null)
        {
            canTalk = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && currentData != null)
        {
            canTalk = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && currentData != null)
        {
            canTalk = false;
            DialougeUI.Instance.dialougePanel.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && currentData != null)
        {
            canTalk = false;
            DialougeUI.Instance.dialougePanel.SetActive(false);
        }
    }
    private void Update()
    {
        ui.SetActive(canTalk);

    }
    void OpenDialogue()
    {
        //打开Ui面板
        //传输对话内容
        DialougeUI.Instance.UpdateDialougeData(currentData);
        DialougeUI.Instance.UpdateMainDialouge(currentData.dialoguePieces[0]);
    }
}
