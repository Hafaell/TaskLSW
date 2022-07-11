using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/ItemSO", order = 1)]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public Sprite sprite;
    public string description;
    public int price;
    public int resalePrice;
}
