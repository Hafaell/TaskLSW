using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/InventorySO", order = 0)]
public class InventorySO : ScriptableObject
{
    public List<ItemSO> items;
    public int coins;
    public bool unlimitedCoin;

    public void AddItem(ItemSO item)
    {
        items.Add(item);
    }

    public void RemoveItem(ItemSO item)
    {
        items.Remove(item);
    }
}
