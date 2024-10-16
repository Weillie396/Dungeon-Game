using Inventory.Model;
using UnityEngine;

public class Item : MonoBehaviour
{
    [field: SerializeField]
    public ItemSO InventoryItem { get; private set; }

    [field: SerializeField]
    public int Quantity { get; set; } = 1;

    protected bool collected;


    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = InventoryItem.ItemImage;
    }

    private void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
            DestroyItem();
    }
    public void DestroyItem()
    {
        collected = true;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject);
    }


}
