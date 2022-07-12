using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class Item : MonoBehaviour
    {
        public ItemSO itemType;

        public GameObject descriptionsContent;

        public Image image;
        public TextMeshProUGUI itemName;
        public TextMeshProUGUI description;
        public TextMeshProUGUI price;
        public Button button;

        private void Start()
        {
            SetupItem();
        }

        private void Update()
        {
            descriptionsContent.SetActive(MouseOverUI.GetMouseOverUIElement() == gameObject);
        }

        private void SetupItem()
        {
            image.sprite = itemType.sprite;
            itemName.text = itemType.itemName;
            description.text = itemType.description;
        }

        public void ChangePrice(float _price)
        {
            price.text = $"${_price}";
        }
    }
}
