using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUI : EquipmentManager
{

    #region Singleton

    public static EquipmentUI instance1;

    void Awake()
    {
        instance1 = this;
    }
    #endregion

    public Transform EquipmentParent;

    EquipmentSlotUI[] slots;

    void Start()
    {

        slots = EquipmentParent.GetComponentsInChildren<EquipmentSlotUI>();
        slots = slots.OrderBy(x => x.Index).ToArray();
    }

    public void ChangeEquipmentUI(int slotIndex, Equipment newItem)
    {
        foreach (EquipmentSlotUI slot in slots)
        {
            if (slot.Index == slotIndex)
            {
                slot.AddEquipment(newItem);
            } 
        }

    }

}
