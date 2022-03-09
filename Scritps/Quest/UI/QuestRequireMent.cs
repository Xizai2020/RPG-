using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestRequireMent : MonoBehaviour
{
    private Text requireName;
    private Text progressNumber;
    private void Awake()
    {
        requireName = GetComponent<Text>();
        progressNumber = transform.GetChild(0).GetComponent<Text>();
    }
    public void SetupRequirement(string name,int amout,int currentAmount)
    {
        requireName.text = name;
        progressNumber.text = currentAmount.ToString() + "/" + amout.ToString();
    }
    public void SetupRequirement(string name,bool isFinshed)
    {
        if (isFinshed)
        {
            requireName.text = name;
            progressNumber.text = "Íê³É";
            requireName.color = Color.gray;
            progressNumber.color = Color.gray;
        }
    }
}
