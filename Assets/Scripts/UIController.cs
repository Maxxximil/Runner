using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    [SerializeField] private Text _scoreCoins;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.ADD_COINS, OnAddCoins);
    }

    private void OnDestroy()
    {
        Messenger.AddListener(GameEvent.ADD_COINS, OnDestroy);
    }

    private void Start()
    {
        _scoreCoins.text = ": " + Managers.Coin.GetCoins();
    }

    private void OnAddCoins()
    {
        _scoreCoins.text = ": " + Managers.Coin.GetCoins();
    }
}
