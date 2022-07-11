using MyInput;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Scripts Ref")]
        [SerializeField] private MyInputs myInputs;
        [SerializeField] private InventorySO playerInventory;

        [Header("Player Settings")]
        [SerializeField] private float speed;
        [SerializeField] private float radiusInteractable;
        [SerializeField] private LayerMask interactableLayer;

        [Header("UI")]
        [SerializeField] private GameObject inventoryUI;
        private Vector2 movement;

        private Iinteractable interactable;

        private Rigidbody2D rig;
        private Animator anim;

        public static Action<bool> showInventory_ACT;

        private void OnEnable()
        {
            showInventory_ACT += ShowInventory;
        }

        private void OnDisable()
        {
            showInventory_ACT -= showInventory_ACT;
        }

        private void Start()
        {
            rig = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            Inputs();
            SetAnimations();
        }

        private void FixedUpdate()
        {
            Movement();
            CheckInteracts();
        }

        private void Inputs()
        {
            movement = myInputs.input.Player.Movement.ReadValue<Vector2>();

            if (myInputs.input.Player.Interact.triggered)
            {
                if (interactable == null)
                    return;

                interactable.Interact();
            }

            if (myInputs.input.Player.Inventory.triggered)
            {
                showInventory_ACT?.Invoke(!inventoryUI.activeInHierarchy);
            }
        }

        private void Movement()
        {
            rig.MovePosition(rig.position + movement * speed * Time.fixedDeltaTime);
        }

        private void CheckInteracts()
        {
            Collider2D colliders = Physics2D.OverlapCircle(transform.position, radiusInteractable, interactableLayer);

            if (colliders == null)
            {
                if (interactable == null)
                    return;

                interactable.ShowIcon(false);
                interactable = null;

                return;
            }

            interactable = colliders.GetComponent<Iinteractable>();
            interactable.ShowIcon(true);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            LayerMask layer = collision.gameObject.layer;

            if (layer == LayerMask.NameToLayer("Coin"))
            {
                playerInventory.coins++;
                Destroy(collision.gameObject);
            }
        }

        private void SetAnimations()
        {
            if (movement != Vector2.zero)
            {
                anim.SetFloat("moveX", movement.x);
                anim.SetFloat("moveY", movement.y);
                anim.SetBool("moving", true);
            }
            else
            {
                anim.SetBool("moving", false);
            }
        }

        private void ShowInventory(bool open)
        {
            if (!open)
            {
                inventoryUI.SetActive(false);
                return;
            }

            if (!inventoryUI.activeInHierarchy)
            {
                inventoryUI.SetActive(true);
                anim.SetTrigger("openInventory");
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, radiusInteractable);
        }
    }
}
