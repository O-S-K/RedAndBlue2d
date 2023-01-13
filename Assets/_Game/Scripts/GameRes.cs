using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRes
{
    public static int IsSelectLV
    {
        get
        {
            return PlayerPrefs.GetInt("IsSelectLV", 0);
        }
        set
        {
            PlayerPrefs.SetInt("IsSelectLV", value);
        }
    }
    public static int LevelSelectMode
    {
        get
        {
            return PlayerPrefs.GetInt("LevelSelectMode", 1);
        }
        set
        {
            PlayerPrefs.SetInt("LevelSelectMode", value);
        }
    }
    public static int Level
    {
        get
        {
            return PlayerPrefs.GetInt("Level", 1);
        }
        set
        {
            PlayerPrefs.SetInt("Level", value);
        }
    }
    public static int SoundSetting
    {
        get
        {
            return PlayerPrefs.GetInt("SoundSetting", 1);
        }
        set
        {
            PlayerPrefs.SetInt("SoundSetting", value);
        }
    }
    public static int BgMusicSetting
    {
        get
        {
            return PlayerPrefs.GetInt("BgMusicSetting", 1);
        }
        set
        {
            PlayerPrefs.SetInt("BgMusicSetting", value);
        }
    }
    public static int Coin
    {
        get
        {
            return PlayerPrefs.GetInt("Coin", 100);
        }
        set
        {
            PlayerPrefs.SetInt("Coin", value);
        }
    }

    public static int Heart
    {
        get
        {
            return PlayerPrefs.GetInt("Heart", 5);
        }
        set
        {
            PlayerPrefs.SetInt("Heart", value);
        }
    }
    public static int IDSkin
    {
        get
        {
            return PlayerPrefs.GetInt("IDSkin", 0);
        }
        set
        {
            PlayerPrefs.SetInt("IDSkin", value);
        }
    }

    public static List<int> listSkinUnlock
    {
        get
        {
            return PlayerPrefsExtra.GetList<int>("listSkinUnlock", new List<int>());
        }
        set
        {
            PlayerPrefsExtra.SetList<int>("listSkinUnlock", value);
        }
    }
}