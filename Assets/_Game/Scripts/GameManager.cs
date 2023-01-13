using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameState gameState;
    [SerializeField] LevelManager levelManager;
    [SerializeField] PlayerManager playerManager;
    public int countCoin = 0;
    public bool isSelectLV = false;
    public void StartGame()
    {
        countCoin = 0;
        if (isSelectLV)
        {
            StartGameLV(GameRes.LevelSelectMode);
        }
        else
        {
            AudioManager.Instance.PlayMusic("jungletheme");
            isSelectLV = false;
            gameState = GameState.Playing;
            levelManager.Initialized(GameRes.Level);


        }
        var posRed = levelManager.currenMap.posStartRed.position;
        var posBlue = levelManager.currenMap.posStartBlue.position;
        playerManager.Init(posRed, posBlue,
                  levelManager.currenMap.PosDoorRed(),
                   levelManager.currenMap.PosDoorBlue());
        CameraCtr.Instance.Init();

    }
    public void StartGameLV(int level)
    {
        countCoin = 0;
        AudioManager.Instance.PlayMusic("jungletheme");
        GameRes.LevelSelectMode = level;
        isSelectLV = true;
        gameState = GameState.Playing;
        levelManager.Initialized(GameRes.LevelSelectMode);
        var posRed = levelManager.currenMap.posStartRed.position;
        var posBlue = levelManager.currenMap.posStartBlue.position;

        playerManager.Init(posRed, posBlue,
        levelManager.currenMap.PosDoorRed(),
         levelManager.currenMap.PosDoorBlue());
        CameraCtr.Instance.Init();
        UI_Manager.Instance.popupUI.GetGameUI().SetTextLv(GameRes.LevelSelectMode);
    }

    public void OnWin()
    {
        ChangeStateGame(GameState.GameOver);
        Destroy(levelManager.currenMap.gameObject);
    }
    public void ChangeStateGame(GameState state)
    {
        gameState = state;
    }
    public GameState GetStateGame()
    {
        return gameState;
    }
    public void ClearLV()
    {
        levelManager.ClearLV();
    }
    public void ResetLevel()
    {
        countCoin = 0;
        PlayerManager.Instance.ResetPlayer();
        CameraCtr.Instance.SetTarget(PlayerManager.Instance.currentPlayer.transform);
        UI_Manager.Instance.popupUI.GetGameUI().HideKey();
        levelManager.ResetLevel();
    }
    void Update()
    {

    }
}
