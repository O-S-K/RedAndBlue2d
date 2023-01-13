using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupUI : MonoBehaviour
{
    [Header("PopUp")]
    [SerializeField] private GameUI _gameUI;
    [SerializeField] GameObject _selectLevelPopup;
    [SerializeField] GameObject _skinPopup;
    [SerializeField] GameObject _shopPopup;
    [SerializeField] GameObject _sprinBoardPopup;
    [SerializeField] GameObject _resultPopup;
    [SerializeField] ContinuePanelUI _continuePanel;


    // Start is called before the first frame update
    void Start()
    {

    }
    public GameUI GetGameUI()
    {
        return _gameUI;
    }
    public void ShowPausePanel()
    {
        _continuePanel.gameObject.SetActive(true);
        _continuePanel.ShowPausePanel();
    }
    public void ShowFailPanel()
    {
        _continuePanel.gameObject.SetActive(true);
        _continuePanel.ShowFailPanel();
    }
    public void HideAllPopup()
    {
        _gameUI.gameObject.SetActive(false);
        _selectLevelPopup.SetActive(false);
        _skinPopup.SetActive(false);
        _shopPopup.SetActive(false);
        _sprinBoardPopup.SetActive(false);
    }
    public void SetHeart(int heart)
    {
        _gameUI.GetComponent<GameUI>().SetHeart(heart);
    }
    public void ShowGameUI()
    {
        _gameUI.gameObject.SetActive(true);

    }
    public void HideGameUI()
    {
        _gameUI.gameObject.SetActive(false);
    }
    public void ShowLevelSelect()
    {
        _selectLevelPopup.SetActive(true);
    }
    public void ShowSkin()
    {
        _skinPopup.SetActive(true);
    }
    public void ShowResult()
    {
        _resultPopup.SetActive(true);
        _resultPopup.transform.GetChild(0).gameObject.SetActive(true);
    }
    public void ShowShop()
    {
        _shopPopup.SetActive(true);
    }
    public void ShowSprinBoard()
    {
        _sprinBoardPopup.SetActive(true);
    }
}
