using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Shopping
{
    public class Shopping : MonoBehaviour
    {
        public InventorySO PlayerInventory;
        public InventorySO MerchantInventory;
        public Item itemPrefab;

        public Transform gridItemsToBuy;

        public void Buy()
        {

        }

        public void Sell()
        {

        }

        public void SetupShop()
        {
            List<ItemSO> shopItems = new List<ItemSO>();

            for (int i = 0; i < gridItemsToBuy.childCount; i++)
            {
                shopItems.Add(gridItemsToBuy.GetChild(i).GetComponent<Item>().itemType);
            }

            List<ItemSO> itensToRefresh = MerchantInventory.items.Where(i => !shopItems.Contains(i)).ToList();
            List<ItemSO> itemsToRemove = shopItems.Where(i => !MerchantInventory.items.Contains(i)).ToList();

            if (itemsToRemove.Count > 0)
                RemoveItemFromShop(itemsToRemove);

            if (itensToRefresh.Count > 0)
                InstantiateAmount(itensToRefresh);
        }

        private void RemoveItemFromShop(List<ItemSO> listItemsToRemove)
        {
            for (int i = 0; i < gridItemsToBuy.childCount; i++)
            {
                bool canRemove = listItemsToRemove.Any(obj => obj == gridItemsToBuy.GetChild(i).GetComponent<Item>().itemType);

                if (canRemove)
                    Destroy(gridItemsToBuy.GetChild(i).gameObject);
            }
        }

        private void InstantiateAmount(List<ItemSO> listItemsToSpawn)
        {
            foreach (ItemSO item in listItemsToSpawn)
            {
                Item obj = Instantiate(itemPrefab, gridItemsToBuy);
                obj.itemType = item;
            }
        }
    }
}
