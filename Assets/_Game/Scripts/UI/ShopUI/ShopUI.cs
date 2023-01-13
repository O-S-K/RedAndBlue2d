using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class ShopUI : MonoBehaviour
{
    [SerializeField] Button btnBack;
    [SerializeField] Button btnUnLockSkin;
    [SerializeField] Button btnUnLockSkin1;

    [SerializeField] Button btnHeart;
    [SerializeField] Button btnHeart1;

    [SerializeField] Button btnCoin;
    [SerializeField] Button btnCoin1;

    [SerializeField] TextMeshProUGUI txtCoin;
    [SerializeField] TextMeshProUGUI txtHeart;
    private void OnEnable()
    {
        txtCoin.text = GameRes.Coin.ToString();
        txtHeart.text = GameRes.Heart.ToString();
    }
    void Start()
    {
        btnBack.onClick.AddListener(() =>
        {
            UI_Manager.Instance.BackToMenu();
            gameObject.SetActive(false);
        });

        btnUnLockSkin.onClick.AddListener(OnClickUnlockSkin);
        btnUnLockSkin1.onClick.AddListener(OnClickUnlockSkin);
        btnHeart.onClick.AddListener(OnClickHeart);
        btnHeart1.onClick.AddListener(OnClickHeart);
        btnCoin.onClick.AddListener(OnClickCoin);
        btnCoin1.onClick.AddListener(OnClickCoin);
    }
    public void OnClickCoin()
    {
        GameRes.Coin += 1000;
        DOVirtual.Int(Int32.Parse(txtCoin.text), GameRes.Coin, 1, (x) => txtCoin.text = x.ToString());
        DOVirtual.Int(Int32.Parse(txtHeart.text), GameRes.Heart, 1, (x) => txtHeart.text = x.ToString());
    }
    public void OnClickHeart()
    {
        GameRes.Heart += 10;
        DOVirtual.Int(Int32.Parse(txtCoin.text), GameRes.Coin, 1, (x) => txtCoin.text = x.ToString());
        DOVirtual.Int(Int32.Parse(txtHeart.text), GameRes.Heart, 1, (x) => txtHeart.text = x.ToString());
    }


    public void OnClickUnlockSkin()
    {
        for (int i = 0; i < 10; i++)
        {
            GameRes.listSkinUnlock.Add(i);
        }
    }
}
