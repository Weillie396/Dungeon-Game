using UnityEngine;
using Inventory.Model;

public class Collectable : Collidable
{

    protected bool collected;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
            OnCollect();
    }

    protected virtual void OnCollect()
    {
        collected = true;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject);
    }






}
