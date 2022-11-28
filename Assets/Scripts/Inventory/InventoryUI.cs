
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private bool InventoryStatus;
    public Transform itemsParent;

    Inventory inventory;

    public GameObject InventoryObject;

    InventorySlot[] slots;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.OnItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

        InventoryObject.SetActive( false );
    } 

    public void InventoryZip()
    {

        InventoryObject.SetActive( !InventoryObject.activeSelf );

    }

    void UpdateUI()
    {

        for (int i = 0; i < slots.Length; i++)
        {

            if (i < inventory.items.Count)
            {

                slots[i].AddItem(inventory.items[i]);

            }
            else
            {
                slots[i].ClearSlot();
            }

        }

    }

}
