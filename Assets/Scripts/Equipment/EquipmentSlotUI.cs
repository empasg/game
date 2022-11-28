
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlotUI : MonoBehaviour
{

    public int Index;

    private Sprite DefaultIcon;

    Equipment _equipment;

    void Start()
    {
        DefaultIcon = gameObject.GetComponent<Image>().sprite;
        if (gameObject.name == "head")
        {
            Index = 0;
        }
        else if (gameObject.name == "chest")
        {
            Index = 1;
        }
        else if (gameObject.name == "legs")
        {
            Index = 2;
        }
        else if (gameObject.name == "sword")
        {
            Index = 3;
        }
        else if (gameObject.name == "shield")
        {
            Index = 4;
        }
        else if (gameObject.name == "feet")
        {
            Index = 5;
        }

    }

    public void AddEquipment(Equipment newItem)
    {
        gameObject.GetComponent<Image>().sprite = newItem.icon;
        gameObject.GetComponent<Image>().color = Color.white;
        gameObject.GetComponent<Button>().interactable = true;
    }

    public void RemoveEquipment()
    {
        
        gameObject.GetComponent<Image>().sprite = DefaultIcon;
        gameObject.GetComponent<Button>().interactable = false;

    }

    public void UnequipUI()
    {

        RemoveEquipment();
        EquipmentManager.instance.Unequip(Index);

    }

}
