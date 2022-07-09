using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMachine : MonoBehaviour, Iinteractable
{
    [SerializeField] private GameObject icon;
    private bool showIcon;

    private void Update()
    {
        icon.SetActive(showIcon);
    }

    public void Interact()
    {
        print("drop Money");
    }

    public void ShowIcon(bool value)
    {
        showIcon = value;
    }
}
