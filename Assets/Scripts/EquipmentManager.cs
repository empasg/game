using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton

    public static EquipmentManager instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public SkinnedMeshRenderer targetMesh;

    Equipment[] currentEquipment;
    SkinnedMeshRenderer[] currentMeshes;

    public delegate void onEquipmentChanged (Equipment newItem, Equipment oldItem);
    public onEquipmentChanged OnEquipmentChanged;

    Inventory inventory;

    private int numSlots;

    void Start ()
    {
        inventory = Inventory.instance;

        numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
        currentMeshes = new SkinnedMeshRenderer[numSlots];

    }

    public void Equip (Equipment newItem)
    {

        int slotIndex = (int)newItem.equipSlot;

        Equipment oldItem = null;

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }

        if (OnEquipmentChanged != null)
            OnEquipmentChanged.Invoke(newItem, oldItem);

        currentEquipment[slotIndex] = newItem;  

        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh); 
        newMesh.transform.parent = targetMesh.transform;

        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;

        currentMeshes[slotIndex] = newMesh;

        if (currentEquipment[slotIndex].equipSlot == 0)
        {
            foreach (Transform child in targetMesh.transform.parent)
            {
                if (child.gameObject.name == "Ears")
                {
                    child.gameObject.SetActive(!child.gameObject.activeSelf);
                }
            }
        }
    }

    public void Unequip (int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {

            if (currentEquipment[slotIndex] != null)
            {
                if (currentEquipment[slotIndex].equipSlot == 0)
                {
                    foreach (Transform child in targetMesh.transform.parent)
                    {
                        if (child.gameObject.name == "Ears")
                        {
                            child.gameObject.SetActive(!child.gameObject.activeSelf);
                        }
                    }
                }

                Destroy(currentMeshes[slotIndex].gameObject);

            }

            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;

            if (OnEquipmentChanged != null)
                OnEquipmentChanged.Invoke(null, oldItem);
        }

    }

    public void UpdateUIEquipment(Equipment newItem)
    {

        int slotIndex = (int)newItem.equipSlot;

        EquipmentUI.instance1.ChangeEquipmentUI(slotIndex, newItem);

    }    

}
