using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactables
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private CircleCollider2D circleColl;
        [SerializeField] private float force;
        private Rigidbody2D rig;

        private void Awake()
        {
            rig = GetComponent<Rigidbody2D>();
            Quaternion randomRotate = Quaternion.Euler(0, 0, Random.Range(0, 360));

            transform.rotation = randomRotate;
        }

        private IEnumerator Start()
        {
            rig.AddForce(transform.right * force, ForceMode2D.Impulse);

            yield return new WaitForSeconds(1f);
            circleColl.enabled = true;
        }
    }
}
