using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactables
{
    public class Merchant : MonoBehaviour, Iinteractable
    {
        [SerializeField] private GameObject dialogContent;
        [SerializeField] private GameObject icon;
        private bool showIcon;

        private void Update()
        {
            icon.SetActive(showIcon);
        }

        public void Interact()
        {
            dialogContent.SetActive(true);
        }

        public void ShowIcon(bool value)
        {
            showIcon = value;
        }
    }
}
