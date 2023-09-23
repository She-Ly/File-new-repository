using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public static Inventory current;
    
    // Maximum number of inventory slots
    public int maxSlots = 3;

    // Reference to the UI inventory slots
    public List<Button> inventorySlots = new List<Button>();

    // List to store the items in the inventory
    private List<Item> items = new List<Item>();

    // Reference to the item you want to use
    private Item selectedItem;

    public Dialogue dialogue;
    public AudioClip itemASelec; // Sonido al seleccionar un elemento
    public AudioClip itemSeleccionado;

    // Function to add an item to the inventory
    public void AddItem(Item item)
    {
        if (items.Count < maxSlots)
        {
            items.Add(item);
            UpdateInventoryUI();
        }
        else
        {
            TriggerDialogue();
        }
    }

    public void UseSelectedItem()
    {
        if (selectedItem != null)
        {
            // Use the selected item (implement item-specific logic here)
            if (itemASelec != null)
            {
                AudioManager.instance.PlaySoundEffect(itemASelec);
            }
            // Remove the used item from the inventory
            if (HasItem(selectedItem))
            {
                items.Remove(selectedItem);
                selectedItem = null;

                // Update the UI
                UpdateInventoryUI();
                if (itemSeleccionado != null)
                {
                    AudioManager.instance.PlaySoundEffect(itemSeleccionado);
                }
            }

        }
    }

    // Function to use a specific item
    public void UseItem(Item item)
    {
        if (HasItem(item))
        {
            // Use the specific item (implement item-specific logic here)
            items.Remove(item);

            // Update the UI
            UpdateInventoryUI();
        }
    }

    public bool HasItem(Item item)
    {
        return items.Contains(item);
    }

    // Function to select an item for use
    public void SelectItem(Item item)
    {
        selectedItem = item;
    }

    // Update the UI to reflect the current inventory state
    private void UpdateInventoryUI()
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            if (i < items.Count)
            {
                // Display the item in the slot
                inventorySlots[i].image.sprite = items[i].icon;
                inventorySlots[i].interactable = true; // Make the slot clickable
            }
            else
            {
                // Clear the slot if no item is present
                inventorySlots[i].image.sprite = null;
                inventorySlots[i].interactable = false; // Make the slot unclickable
            }
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
