using Inventory.Model;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    [SerializeField]
    private InventorySO inventoryData;

    private void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.tag != "Fighter")
        {
            Item item = coll.GetComponent<Item>();
            if (item != null)
            {
                int remainder = inventoryData.AddItem(item.InventoryItem, item.Quantity);
                if (remainder == 0)
                    item.DestroyItem();
                else
                    item.Quantity = remainder;
            }
        }
    }
}
