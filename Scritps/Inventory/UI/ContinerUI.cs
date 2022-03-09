using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinerUI : MonoBehaviour
{

    public SlotHoder[] slotHoders;
    public void RefreshUI() 
    {
        for (int i = 0; i < slotHoders.Length; i++)
        {
            slotHoders[i].itemUI.Index = i;
            slotHoders[i].UpdaateItem();
        }
    }

}
