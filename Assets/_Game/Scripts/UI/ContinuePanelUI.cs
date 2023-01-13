using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ContinuePanelUI : MonoBehaviour
{
    public Animator anim;
    [Header("Pause Panel")]
    [SerializeField] GameObject _pausePanel;
    [SerializeField] private Button _btnContinue;
    [SerializeField] private Button _btnRestart;
    [SerializeField] private Button _btnHome;
    [SerializeField] private Button _btnClose;

    [SerializeField] private Button _btnSound;
    [SerializeField] private Button _btnMusic;


    [Header("setting sound")]
    [SerializeField] private GameObject _soundOFF;
    [SerializeField] private GameObject _soundON;

    [SerializeField] private GameObject _musicOFF;
    [SerializeField] private GameObject _musicON;


    [Header("Fail Panel")]
    [SerializeField] GameObject _failPanel;
    [SerializeField] private Button _retry;
    [SerializeField] private Button _close;



    private void OnEnable()
    {
        anim.CrossFadeInFixedTime("settings_open",0.1f);

        if (GameRes.SoundSetting == 1)
        {
            _soundON.SetActive(true);
            _soundOFF.SetActive(false);
        }
        else
        {
            _soundON.SetActive(false);
            _soundOFF.SetActive(true);
        }


        if (GameRes.BgMusicSetting == 1)
        {
            _musicON.SetActive(true);
            _musicOFF.SetActive(false);
        }
        else
        {
            _musicON.SetActive(false);
            _musicOFF.SetActive(true);
        }
    }

    public void ShowFailPanel()
    {
        _pausePanel.SetActive(false);
        _failPanel.SetActive(true);
    }
    public void ShowPausePanel()
    {
        _pausePanel.SetActive(true);
        _failPanel.SetActive(false);
    }
    void Start()
    {
        //settings_close
        //btn pause
        _btnContinue.onClick.AddListener(OnContinue);
        _btnRestart.onClick.AddListener(OnRestart);
        _btnHome.onClick.AddListener(OnHome);
        _btnClose.onClick.AddListener(OnContinue);
        _btnSound.onClick.AddListener(OnSound);
        _btnMusic.onClick.AddListener(OnMusic);

        _retry.onClick.AddListener(OnRestart);
        _close.onClick.AddListener(OnClose);

    }

    private void OnMusic()
    {
        if (GameRes.BgMusicSetting == 1)
        {
            _musicON.SetActive(false);
            _musicOFF.SetActive(true);
            AudioManager.Instance.Pause();
            GameRes.BgMusicSetting = 0;
        }
        else
        {
            _musicON.SetActive(true);
            _musicOFF.SetActive(false);
            AudioManager.Instance.Resume();

            GameRes.BgMusicSetting = 1;
        }
    }

    private void OnSound()
    {
        if (GameRes.SoundSetting == 1)
        {
            _soundON.SetActive(false);
            _soundOFF.SetActive(true);
            GameRes.SoundSetting = 0;
        }
        else
        {
            _soundON.SetActive(true);
            _soundOFF.SetActive(false);
            GameRes.SoundSetting = 1;
        }


    }

    private void OnClose()
    {
        anim.CrossFadeInFixedTime("settings_close",0.1f);

        gameObject.SetActive(false);
        UI_Manager.Instance.BackToMenu();
    }

    private void OnHome()
    {
        GameManager.Instance.ClearLV();
        GameRes.IsSelectLV = 0;

       anim.CrossFadeInFixedTime("settings_close",0.1f);

         gameObject.SetActive(false);
        UI_Manager.Instance.BackToMenu();
    }

    private void OnRestart()
    {
        anim.CrossFadeInFixedTime("settings_close",0.1f);

        GameManager.Instance.ChangeStateGame(GameState.Playing);

          gameObject.SetActive(false);

        GameManager.Instance.ResetLevel();
    }
    public void Deactive()
    {
        //gameObject.SetActive(false);
    }
    private void OnContinue()
    {
        anim.CrossFadeInFixedTime("settings_close",0.1f);
        GameManager.Instance.ChangeStateGame(GameState.Playing);

         gameObject.SetActive(false);
        PlayerManager.Instance.ResfeshPlayer();
    }

    void Update()
    {

    }
}
