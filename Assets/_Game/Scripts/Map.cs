using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    public Transform posStartRed;
    public Transform posStartBlue;
    [SerializeField] List<GameObject> coins;
    [SerializeField] List<GameObject> keys;
    [SerializeField] List<GameObject> doors;
    [SerializeField] List<GameObject> items;


    [EButton]
    public void GenObjectMap()
    {


        Transform parent = transform.GetChild(0).GetChild(2);
        var door = Instantiate(new GameObject("Door"), parent);
        door.name = "Door";
        var key = Instantiate(new GameObject("Key"), parent);
        key.name = "Key";
        var coin = Instantiate(new GameObject("Coin"), parent);
        coin.name = "Coin";
        var item = Instantiate(new GameObject("Item"), parent);
        item.name = "Item";

        var posStartRed = Instantiate(new GameObject("StartRed"), transform.GetChild(0));
        posStartRed.name = "StartRed";
        var posStartBlue = Instantiate(new GameObject("StartBlue"), transform.GetChild(0));
        posStartBlue.name = "StartBlue";
    }

    [EButton]
    public void GetAllObject()
    {
        posStartRed = transform.GetChild(0).Find("StartRed");
        posStartBlue = transform.GetChild(0).Find("StartBlue");
        Transform doorTf = transform.GetChild(0).GetChild(2).Find("Door");
        Transform keyTf = transform.GetChild(0).GetChild(2).Find("Key");
        Transform coinTf = transform.GetChild(0).GetChild(2).Find("Coin");
        Transform itemTf = transform.GetChild(0).GetChild(2).Find("Item");
        foreach (Transform item in doorTf)
        {
            doors.Add(item.gameObject);
        }
        foreach (Transform item in keyTf)
        {
            keys.Add(item.gameObject);
        }
        foreach (Transform item in coinTf)
        {
            coins.Add(item.gameObject);
        }
        foreach (Transform item in itemTf)
        {
            items.Add(item.gameObject);
        }

    }
    public Vector3 PosDoorBlue()
    {
        return doors[0].transform.position;
    }
    public Vector3 PosDoorRed()
    {
        return doors[1].transform.position;
    }

    public void ResetMap()
    {
        foreach (var item in doors)
        {
            if (item.GetComponent<DoorItem>() != null)
            {
                item.GetComponent<DoorItem>().ResetDoor();
            }

        }
        foreach (var item in keys)
        {
            item.SetActive(true);
        }
        foreach (var item in coins)
        {
            item.SetActive(true);
        }
        foreach (var item in items)
        {
            item.SetActive(true);
            if (item.GetComponent<BaseItem>() != null)
            {
                item.GetComponent<BaseItem>().ResetPos();
            }


        }

    }

    void Start()
    {

    }


}
