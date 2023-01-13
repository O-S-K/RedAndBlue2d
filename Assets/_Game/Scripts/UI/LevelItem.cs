using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelItem : MonoBehaviour
{
    public int level;
    public Button button;
    [SerializeField] Sprite _spriteLock;
    [SerializeField] Sprite _spriteUnLock;
    [SerializeField] Sprite _spriteSelect;
    [SerializeField] TextMeshProUGUI _textLevel;
    [SerializeField] Image _panel;

    private void Reset()
    {
        button = GetComponent<Button>();
        _panel = transform.GetChild(0).GetComponent<Image>();
        _textLevel = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        _textLevel.text = level.ToString();
    }
    public void SetLevelInfo()
    {
        if (level > GameRes.Level)
        {
            button.interactable = false;
            _panel.sprite = _spriteLock;
        }
        else if (level < GameRes.Level)
        {
            button.interactable = true;
            _panel.sprite = _spriteUnLock;
        }
        else if (level == GameRes.Level)
        {
            button.interactable = true;
            _panel.sprite = _spriteSelect;
        }
        {

        }


    }

}
