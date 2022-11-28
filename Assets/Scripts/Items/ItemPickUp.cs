using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item item;

    public override void Interact()
    {

        base.Interact();

        PickUp();
        
    }

    void PickUp()
    {

        print("PickUpCalled to " + item.name);

        bool WasPickUp = Inventory.instance.Add(item);
        
        if (WasPickUp)
        {
            Destroy(gameObject);
        }

    }

}
