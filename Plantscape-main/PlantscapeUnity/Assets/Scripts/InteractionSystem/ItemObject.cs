using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public Item itemReference;

    public void OnHandlePickUpItem()
    {
        Inventory.current.AddItem(itemReference);
        Destroy(gameObject);
    }
}
