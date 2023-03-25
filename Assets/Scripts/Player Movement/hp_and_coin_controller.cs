using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class hp_and_coin_controller : MonoBehaviour
{
    public TMP_Text _coin;
    public TMP_Text _hp;
    public TMP_Text _store_coin;

    // Start is called before the first frame update
    public void Start()
    {
    }

    public void IncreaseCoin(int n)
    {
        int tmp;
        int.TryParse(_coin.text, out tmp);
        _coin.text = (tmp + n).ToString();
        PlayerController.coins = tmp + n;
    }

    public void IncreaseCoinInStore()
    {
        int tmp;
        int.TryParse(_store_coin.text, out tmp);
        _store_coin.text = (tmp + PlayerController.coins).ToString();
        //PlayerController.coins = tmp + n;
    }

    public void ChangeHp(int n)
    {
        int tmp;
        int.TryParse(_hp.text, out tmp);
        _hp.text = (tmp + n).ToString();
        PlayerController.health = tmp + n;
    }


    // Update is called once per frame
    void Update()
    {
        //ChangeHp(-1);
    }
}