using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using Random = UnityEngine.Random;

public class LuckySpinPopup : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _txtCoin;
    [SerializeField] TextMeshProUGUI _txtHeart;
    [SerializeField] Button btnBack;
    [SerializeField] List<SpinLane> _spinLanes;
    public Transform Spinboard;
    public float spinSpeed = 180f;

    // Time it will take for the wheel to come to a stop
    public float stopTime = 3f;

    [SerializeField] Button btnSpin;

    // Current rotation of the wheel
    private float currentRotation = 0f;

    // Flag to check if the wheel is spinning
    private bool spinning = false;
    private void OnEnable()
    {
        UpdateText();
    }
    void UpdateText()
    {

        DOVirtual.Int(Int32.Parse(_txtCoin.text), GameRes.Coin, 1, (x) => _txtCoin.text = x.ToString());
        DOVirtual.Int(Int32.Parse(_txtHeart.text), GameRes.Heart,1, (x) => _txtHeart.text = x.ToString());

        //  _txtCoin.text = GameRes.Coin.ToString();
        //  _txtHeart.text = GameRes.Heart.ToString();
    }
    private void Awake()
    {
        btnSpin.onClick.AddListener(Spin);
        btnBack.onClick.AddListener(OnBack);
    }

    private void OnBack()
    {
        gameObject.SetActive(false);
        UI_Manager.Instance.BackToMenu();
    }

    void Start()
    {
        spinSpeed = Random.Range(180f, 360f);
        if (GameRes.Coin < 100)
        {
            btnSpin.interactable = false;
        }
        else
        {
            btnSpin.interactable = true;
        }
        // Spin();

    }

    // Update is called once per frame
    void Update()
    {
        if (spinning)
        {
            currentRotation += spinSpeed * Time.deltaTime;
            Spinboard.eulerAngles = new Vector3(0, 0, currentRotation);
        }
    }
    public void Spin()
    {
        GameRes.Coin -= 100;
        UpdateText();

        btnSpin.interactable = false;
        // Set spinning flag to true
        spinning = true;
        // After stopTime seconds, stop the wheel and determine the prize
        Invoke(nameof(Stop), stopTime);

    }
    void Stop()
    {
        if (GameRes.Coin < 100)
        {
            btnSpin.interactable = false;
        }
        else
        {
            btnSpin.interactable = true;
        }
        // Set spinning flag to false
        spinning = false;

        // Calculate the prize index based on the final rotation of the wheel
        int prizeIndex = (int)(currentRotation % 360 / (spinSpeed / _spinLanes.Count));

        // Display the prize won
        int tempIndex = prizeIndex +1;
        Debug.Log("index: " + prizeIndex + " _spinLanes=" + _spinLanes.Count);
      
        Debug.Log("You won: " + _spinLanes[prizeIndex]);

        _spinLanes[prizeIndex].GetInfo();
        if (_spinLanes[prizeIndex].GetInfo().Item1 == SpinLaneType.Coin)
        {
            GameRes.Coin += _spinLanes[prizeIndex].GetInfo().Item2;
        }
        else if (_spinLanes[prizeIndex].GetInfo().Item1 == SpinLaneType.Heart)
        {
            GameRes.Heart += _spinLanes[prizeIndex].GetInfo().Item2;
        }


        UpdateText();

    }
}
