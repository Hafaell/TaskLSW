using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/InventorySO", order = 0)]
public class InventorySO : ScriptableObject
{
    public List<ItemSO> items;
    public int gold;
}
