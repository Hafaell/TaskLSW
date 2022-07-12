using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class HandlerUI : MonoBehaviour
    {
        [SerializeField] private InventorySO playerInventory;
        [SerializeField] private TextMeshProUGUI goldText;

        [SerializeField] private GameObject inventoryPlayerUI;
        [SerializeField] private GameObject tabUI;

        private void Update()
        {
            goldText.text = $"{playerInventory.coins}x";
            tabUI.SetActive(!inventoryPlayerUI.activeInHierarchy);
        }
    }
}
