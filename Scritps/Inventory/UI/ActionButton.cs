using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButton : MonoBehaviour
{
    public KeyCode actionKey;
    private SlotHoder currentSlotHolder;
    private void Awake()
    {
        currentSlotHolder = GetComponent<SlotHoder>();

    }
    private void Update()
    {
        if (Input.GetKeyDown(actionKey) && currentSlotHolder.itemUI.GetItem())
        {
            currentSlotHolder.UseItem();
        }
    }
}
