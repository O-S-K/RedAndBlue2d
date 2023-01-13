using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

[CreateAssetMenu(fileName = "Data", menuName = "DataSO/Character", order = 1)]
public class InfoCharacterSO : ScriptableObject
{
    public List<InfoChacracter> infoChacracters;
}

[System.Serializable]
public class InfoChacracter
{
    public int id;

    public Sprite icon;
    public Sprite iconLock;
    public int price;

    public string GetNameSkinRed()
    {
        return id.ToString() + "_2";
    }
    public string GetNameSkinBlue()
    {
        return id.ToString() + "_1";
    }

}
