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
            if (gridItemsToBuy.childCount <= 0)
            {
                InstantiateAmount(MerchantInventory.items);
                return;
            }

            InstantiateAmount(ItemsToRefresh());
        }

        private void InstantiateAmount(List<ItemSO> listItemsToSpawn)
        {
            foreach (ItemSO item in listItemsToSpawn)
            {
                Item obj = Instantiate(itemPrefab, gridItemsToBuy);
                obj.itemType = item;
            }
        }

        private List<ItemSO> ItemsToRefresh()
        {
            List<ItemSO> itemsToRefresh = new List<ItemSO>();

            foreach (var item in MerchantInventory.items)
            {
                if (NeedRefrash(item))
                {
                    itemsToRefresh.Add(item);
                }
            }

            return itemsToRefresh;
        }

        private bool NeedRefrash(ItemSO item)
        {
            bool needRefrash = true;

            for (int i = 0; i < gridItemsToBuy.childCount; i++)
            {
                Item shopItem = gridItemsToBuy.GetChild(i).GetComponent<Item>();

                if (item == shopItem.itemType)
                {
                    needRefrash = false;
                    return needRefrash;
                }
            }

            return needRefrash;
        }
    }
}
