using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{

    public EquipmentSlot equipSlot;
    public SkinnedMeshRenderer mesh;

    public int armorModifier;
    public int damageModifier;

    public override void Use()
    {

        EquipmentManager.instance.Equip(this);
        Inventory.instance.Remove(this);
        EquipmentManager.instance.UpdateUIEquipment(this);

    }

}

public enum EquipmentSlot {Head, Chest, Legs, Weapon, Shield, Feet}