using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shopping
{
    public class Item : MonoBehaviour
    {
        public ItemSO itemType;

        public Image image;
        public TextMeshProUGUI _name;
        public TextMeshProUGUI description;
        public TextMeshProUGUI price;

        private void Start()
        {
            SetupItem();
        }

        private void SetupItem()
        {
            image.sprite = itemType.sprite;
            _name.text = itemType._name;
            description.text = itemType.description;
            price.text = $"${itemType.price}";
        }

        public void DebugClick()
        {
            print(itemType._name);
        }
    }
}
