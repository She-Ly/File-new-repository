using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    // Maximum number of inventory slots
    public int maxSlots = 3;

    // Reference to the UI inventory slots
    public List<Button> inventorySlots = new List<Button>();

    // List to store the items in the inventory
    private List<Item> items = new List<Item>();

    // Reference to the item you want to use
    private Item selectedItem;

    // Function to add an item to the inventory
    public AudioClip itemASelec; // Sonido al seleccionar un elemento
    public AudioClip itemSeleccionado;
    public void AddItem(Item item)
    {
        if (items.Count < maxSlots)
        {
            items.Add(item);
            UpdateInventoryUI();
        }
        else
        {
            Debug.Log("Inventory is full!");
        }
    }

    // Function to use the selected item
    public void UseSelectedItem()
    {
        if (selectedItem != null)
        {
            // Use the selected item (implement item-specific logic here)
            if (itemSeleccionado != null)
            {
                AudioManager.instance.PlaySoundEffect(itemSeleccionado);
            }
            // Remove the used item from the inventory
            items.Remove(selectedItem);
            selectedItem = null;

            // Update the UI
            UpdateInventoryUI();
        }
    }

    // Function to select an item for use
    public void SelectItem(Item item)
    {
        selectedItem = item;
        if (itemASelec != null)
        {
            AudioManager.instance.PlaySoundEffect(itemASelec);
        }
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
}
