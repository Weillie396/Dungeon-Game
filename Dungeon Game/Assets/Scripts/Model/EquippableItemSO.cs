using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{

    [CreateAssetMenu]
    public class EquippableItemSO : ItemSO, IDestoryableItem, IItemAction
    {
        public string ActionName => "Equip";

        public bool PerformAction(GameObject character, List<ItemParameter> itemState = null)
        {
            Weapon weapon = character.GetComponent<Weapon>();
            if (weapon != null)
            {
                weapon.SetWeapon(this, itemState == null ?
                    DefaultParametersList : itemState);
                return true;
            }
            return false;
        }
    }
}
