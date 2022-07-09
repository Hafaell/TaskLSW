using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMachine : MonoBehaviour, Iinteractable
{
    [SerializeField] private Vector2 randomCoinAmount;
    [SerializeField] private Coin coin;
    [SerializeField] private GameObject icon;
    private bool showIcon;

    private void Update()
    {
        icon.SetActive(showIcon);
    }

    public void Interact()
    {
        float randomAmount = Random.Range(randomCoinAmount.x, randomCoinAmount.y);

        for (int i = 0; i < randomAmount; i++)
        {
            Instantiate(coin, transform.position, Quaternion.identity);
        }
    }

    public void ShowIcon(bool value)
    {
        showIcon = value;
    }
}
