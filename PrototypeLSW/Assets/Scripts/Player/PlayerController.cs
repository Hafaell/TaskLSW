using MyInput;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private MyInputs myInputs;
        [SerializeField] private InventorySO playerInventory;
        [SerializeField] private float speed;
        [SerializeField] private float radiusInteractable;
        [SerializeField] private LayerMask interactableLayer;
        private Vector2 movement;

        private Iinteractable interactable;

        private Rigidbody2D rig;

        private void Start()
        {
            rig = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Inputs();
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

            if(layer == LayerMask.NameToLayer("Coin"))
            {
                playerInventory.SetGold(1);
                Destroy(collision.gameObject);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, radiusInteractable);
        }
    }
}
