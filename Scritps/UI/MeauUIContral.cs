using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeauUIContral : MonoBehaviour
{
    public List<UiButton> uiButtons;
    private void Awake()
    {
        foreach (var item in GetComponentsInChildren<UiButton>())
        {
            uiButtons.Add(item);
        }
    }
    private void Start()
    {
        uiButtons[0].OpenUI();
    }
    public void UIClose()
    {
        foreach (var item in uiButtons)
        {
            item.CloseUI();
        }
    }
}
