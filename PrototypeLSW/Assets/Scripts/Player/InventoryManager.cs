using Shop;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Player
{
    public class InventoryManager : MonoBehaviour
    {
        [Header("Scripts Ref:")]
        [SerializeField] private InventorySO playerInventory;
        [SerializeField] private CharacterBodySO characterBody;
        [SerializeField] private BodyPartsManager bodyPartsManager;

        [Header("Inventory Settings:")]
        [SerializeField] private Transform gridItems;
        [SerializeField] private Item itemPrefab;

        private void OnEnable()
        {
            Setup();
        }

        private void Setup()
        {
            List<ItemSO> inventoryItems = new List<ItemSO>();
            List<ItemSO> itemsToRefresh = new List<ItemSO>();
            List<ItemSO> itemsToRemove = new List<ItemSO>();

            FillLists(playerInventory);

            if (itemsToRemove.Count > 0)
                RemoveItemFromGrid(itemsToRemove);

            if (itemsToRefresh.Count > 0)
                InstantiateAmount(itemsToRefresh);

            void FillLists(InventorySO inventory)
            {
                for (int i = 0; i < gridItems.childCount; i++)
                    inventoryItems.Add(gridItems.GetChild(i).GetComponent<Item>().itemType);

                itemsToRefresh = inventory.items.Where(i => !inventoryItems.Contains(i)).ToList();
                itemsToRemove = inventoryItems.Where(i => !inventory.items.Contains(i)).ToList();
            }       
        }

        private void RemoveItemFromGrid(List<ItemSO> Items)
        {
            for (int i = 0; i < gridItems.childCount; i++)
            {
                bool canRemove = Items.Any(obj => obj == gridItems.GetChild(i).GetComponent<Item>().itemType);

                if (canRemove)
                    Destroy(gridItems.GetChild(i).gameObject);
            }
        }

        private void InstantiateAmount(List<ItemSO> Items)
        {
            foreach (ItemSO item in Items)
            {
                Item obj = Instantiate(itemPrefab, gridItems);
                obj.itemType = item;
                obj.button.onClick.AddListener(() => SelectItem(item));
                obj.button.onClick.AddListener(() => bodyPartsManager.UpdateBodyParts());
            }
        }

        public void SelectItem(ItemSO currentItem)
        {
            var a = characterBody.characterBodyParts.First(obj => obj.bodyPartName == currentItem.bodyPartItem.bodyPartName);
            a.bodyPartSO = currentItem.bodyPartItem.bodyPartSO;
        }
    }
}
