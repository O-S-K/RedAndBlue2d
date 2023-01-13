using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameState gameState;
    [SerializeField] LevelManager levelManager;
    [SerializeField] PlayerManager playerManager;
    public int countCoin = 0;
    public void StartGame()
    {
        countCoin = 0;
        int i = GameRes.LevelSelectMode;
        if (GameRes.IsSelectLV == 1)
        {
            StartGameLV(GameRes.LevelSelectMode);
        }
        else
        {
            AudioManager.Instance.PlayMusic("jungletheme");
            GameRes.IsSelectLV = 0;
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
        GameRes.IsSelectLV = 1;
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
