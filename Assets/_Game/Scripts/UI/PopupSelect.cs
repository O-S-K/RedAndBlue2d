using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PopupSelect : MonoBehaviour
{
    public Button buttonBack;
    [SerializeField] GameObject _holder;
    [SerializeField] List<LevelItem> _levelItems;
    [SerializeField] Button _buttonBack;
    [SerializeField] TextMeshProUGUI _textLevel;

    void Start()
    {
        _textLevel.text = GameRes.Level.ToString() + "/10";
        _buttonBack.onClick.AddListener(OnBack);
        int id = GameRes.IDSkin;
        foreach (var item in _levelItems)
        {
            item.SetLevelInfo();
            item.button.onClick.AddListener(() =>
            {
                
              
                GameManager.Instance.StartGameLV(item.level);
                gameObject.SetActive(false);
                UI_Manager.Instance.menuUI.HideMenu();

                UI_Manager.Instance.popupUI.ShowGameUI();
            });
        }
        buttonBack.onClick.AddListener(() =>
        {
            UI_Manager.Instance.BackToMenu();
            gameObject.SetActive(false);
        });
    }

    private void OnBack()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
