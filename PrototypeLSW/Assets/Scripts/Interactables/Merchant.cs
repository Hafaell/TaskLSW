using MyInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;
using Shop;
using Player;

namespace Interactables
{
    public class Merchant : MonoBehaviour, Iinteractable
    {
        [Header("Scripts Ref:")]
        [SerializeField] private MyInputs inputs;
        [SerializeField] private Dialog dialog;
        [SerializeField] private Shopping shopping;

        [Header("UI:")]
        [SerializeField] private GameObject canvasContent;
        [SerializeField] private GameObject shopContent;
        [SerializeField] private GameObject icon;

        private Animator anim;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            if (inputs.input.HUD.Exit.triggered)
            {
                ExitShop();
            }
        }

        public void EnterShop()
        {
            canvasContent.SetActive(true);
            anim.SetTrigger("start");

            PlayerController.showInventory_ACT?.Invoke(false);

            dialog.StartDialog();
            inputs.EnableHUDControl();
        }

        public void ExitShop()
        {
            anim.SetTrigger("exit");
            canvasContent.SetActive(false);
            shopContent.SetActive(false);

            shopping.DeselectItem();

            inputs.EnablePlayerControl();
        }

        public void Interact()
        {
            EnterShop();
        }

        public void ShowIcon(bool value)
        {
            icon.SetActive(value);
        }
    }
}
