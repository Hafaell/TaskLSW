using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class Shopping : MonoBehaviour
    {
        [Header("Scripts Ref:")]
        [SerializeField] private InventorySO playerInventory;
        [SerializeField] private InventorySO merchantInventory;
        [SerializeField] private Item itemPrefab;

        [Header("Shop Settings:")]
        [SerializeField] private Transform gridItems;
        [SerializeField] private Button purchaseButton;
        [SerializeField] private Button sellButton;

        [SerializeField] private Color colorWhenSelected;
        [SerializeField] private Color colorBeforeSelected;

        private Item itemSelect;

        public void Buy()
        {
            WhoPurchase(playerInventory, merchantInventory);
        }

        public void Sell()
        {
            WhoPurchase(merchantInventory, playerInventory);
        }

        private void WhoPurchase(InventorySO whoPurchase, InventorySO whoSell)
        {
            if (itemSelect == null)
            {
                print("Selecione algo primeiro");
                return;
            }

            if (!whoPurchase.unlimitedCoin)
            {
                if (whoPurchase.coins < itemSelect.itemType.price)
                {
                    print("dinheiro insuficiente");
                    return;
                }
            }

            whoPurchase.AddItem(itemSelect.itemType);
            whoSell.RemoveItem(itemSelect.itemType);

            whoPurchase.coins -= whoPurchase == playerInventory ? itemSelect.itemType.price : itemSelect.itemType.resalePrice;
            whoSell.coins += whoPurchase == playerInventory ? itemSelect.itemType.price : itemSelect.itemType.resalePrice;

            itemSelect.button.interactable = false;
            DeselectItem();
        }

        public void SetupShopBuy()
        {
            purchaseButton.gameObject.SetActive(true);
            sellButton.gameObject.SetActive(false);
            Setup(true);
        }

        public void SetupShopSell()
        {
            sellButton.gameObject.SetActive(true);
            purchaseButton.gameObject.SetActive(false);
            Setup(false);
        }

        private void Setup(bool isBuy)
        {
            List<ItemSO> shopItems = new List<ItemSO>();
            List<ItemSO> itemsToRefresh = new List<ItemSO>();
            List<ItemSO> itemsToRemove = new List<ItemSO>();

            if (isBuy)
                FillLists(merchantInventory);
            else
                FillLists(playerInventory);

            if (itemsToRemove.Count > 0)
                RemoveItemFromShop(itemsToRemove);

            if (itemsToRefresh.Count > 0)
                InstantiateAmount(itemsToRefresh);

            ChangePrice();

            void FillLists(InventorySO inventory)
            {
                for (int i = 0; i < gridItems.childCount; i++)
                    shopItems.Add(gridItems.GetChild(i).GetComponent<Item>().itemType);

                itemsToRefresh = inventory.items.Where(i => !shopItems.Contains(i)).ToList();
                itemsToRemove = shopItems.Where(i => !inventory.items.Contains(i)).ToList();
            }

            void ChangePrice()
            {
                for (int i = 0; i < gridItems.childCount; i++)
                {
                    ItemSO itemIndex = gridItems.GetChild(i).GetComponent<Item>().itemType;

                    gridItems.GetChild(i).GetComponent<Item>().button.interactable = true;

                    if (isBuy)
                        gridItems.GetChild(i).GetComponent<Item>().ChangePrice(itemIndex.price);
                    else
                        gridItems.GetChild(i).GetComponent<Item>().ChangePrice(itemIndex.resalePrice);
                }
            }
        }

        private void RemoveItemFromShop(List<ItemSO> Items)
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
                obj.button.onClick.AddListener(() => SelectItem(obj));
            }
        }

        private void SelectItem(Item item)
        {
            if (itemSelect != null)
                SetSelectItemColor(colorBeforeSelected);

            itemSelect = item;
            SetSelectItemColor(colorWhenSelected);
        }

        public void DeselectItem()
        {
            if (itemSelect != null)
                SetSelectItemColor(colorBeforeSelected);

            itemSelect = null;
        }

        private void SetSelectItemColor(Color color)
        {
            itemSelect.GetComponent<Image>().color = color;
        }
    }
}