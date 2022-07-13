using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactables
{
    public class CoinMachine : MonoBehaviour, Iinteractable
    {
        [SerializeField] private Vector2 randomCoinAmount;
        [SerializeField] private Coin coin;
        [SerializeField] private GameObject icon;
        [SerializeField] private Animator anim;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        public void Interact()
        {
            float randomAmount = Random.Range(randomCoinAmount.x, randomCoinAmount.y);

            for (int i = 0; i < randomAmount; i++)
            {
                Instantiate(coin, transform.position, Quaternion.identity);
            }

            anim.SetTrigger("drop");
        }

        public void ShowIcon(bool value)
        {
            icon.SetActive(value);
        }
    }
}
