using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : Singleton<UI_Manager>
{
    public MenuUI menuUI;
    public PopupUI popupUI;
    void Start()
    {

    }

    public void BackToMenu()
    {
        menuUI.gameObject.SetActive(true);
        menuUI.ShowMenu();
        popupUI.HideAllPopup();
    }

}
