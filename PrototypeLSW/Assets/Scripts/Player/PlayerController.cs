using MyInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private MyInputs myInputs;
        [SerializeField] private float speed;
        [SerializeField] private float radiusInteract;
        private Vector2 movement;

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

            }
        }

        private void Movement()
        {
            rig.MovePosition(rig.position + movement * speed * Time.fixedDeltaTime);
        }

        private void CheckInteracts()
        {
            Collider2D colliders = Physics2D.OverlapCircle(transform.position, radiusInteract);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, radiusInteract);
        }
    }
}
