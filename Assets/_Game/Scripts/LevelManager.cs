using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<Map> maps;
    public Map currenMap;


    void Start()
    {
        
    }
    public void ClearLV()
    {
        Destroy(currenMap.gameObject);
    }
    public void Initialized(int levelGame)
    {
        currenMap = Instantiate(maps[levelGame-1], transform);
    }
    public void ResetLevel()
    {
        currenMap.ResetMap();
    }
}
