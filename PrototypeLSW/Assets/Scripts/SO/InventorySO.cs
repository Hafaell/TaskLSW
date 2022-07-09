using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/InventorySO", order = 0)]
public class InventorySO : ScriptableObject
{
    private List<ItemSO> items;
    private int gold;

    public int GetGold()
    {
        return gold;
    }

    public void SetGold(int value)
    {
        gold += value;
    }

    public List<ItemSO> GetItems()
    {
        return items;
    }

    public void AddItem(ItemSO item)
    {
        items.Add(item);
    }

    public void RemoveItem(ItemSO item)
    {
        items.Remove(item);
    }
}
