using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] Player playerRed;
    [SerializeField] Player playerBlue;
    [SerializeField] int countDoor;
    public Player currentPlayer;
    Vector3 posOriginRed;
    Vector3 posOriginBlue;
    Vector3 posDoorRed;
    Vector3 posDoorBlue;

    public int CountDoor
    {
        get { return countDoor; }
        set
        {
            countDoor = value;
            if (countDoor == 2)
            {
                Onwin();
            }
        }
    }

    public void Onwin()
    {
        GameManager.Instance.ChangeStateGame(GameState.GameOver);
        if (GameRes.IsSelectLV == 1)
        {
            // GameManager.Instance.SetLV(1);
            if (GameRes.LevelSelectMode < 10)
            {
                GameRes.LevelSelectMode++;
            }
            if (GameRes.LevelSelectMode >= GameRes.Level)
            {
                GameRes.Level = GameRes.LevelSelectMode;
            }
            Debug.Log("vao rofoi");
        }
        else
        {
            if (GameRes.Level < 10)
            {
                GameRes.Level++;
            }
        }
        Debug.Log("wwin");
        UI_Manager.Instance.popupUI.HideGameUI();
        GameRes.Coin += GameManager.Instance.countCoin;
        int randID = Random.Range(1, 5);
        playerBlue.ResetPlayer();
        playerRed.ResetPlayer();
        playerBlue.transform.position = posDoorBlue;
        playerRed.transform.position = posDoorRed;
        playerBlue.Victory(randID);
        playerRed.Victory(randID);
        AudioManager.Instance.PlayOneShot("win4");
        this.Wait(1.5f, () =>
        {
            playerBlue.transform.localPosition = Vector3.zero;
            playerRed.transform.localPosition = Vector3.zero;
            GameManager.Instance.OnWin();
            UI_Manager.Instance.popupUI.ShowResult();
        });

    }
    public void ResetPlayer()
    {
        CountDoor = 0;
        playerRed.checkDie = 0;
        playerBlue.checkDie = 0;
        playerBlue.hasKey = false;
        playerRed.hasKey = false;
        playerBlue.ResetPlayer();
        playerBlue.SetIdleRestart();
        playerRed.SetIdleRestart();

        playerBlue.transform.position = posOriginBlue;
        playerRed.PlayerUpdateState();
        playerRed.transform.position = posOriginRed;
        playerBlue.SetKinematic(true);
        playerRed.SetKinematic(false);
        currentPlayer = playerRed;

    }
    public void Init(Vector2 posRed, Vector2 posBlue, Vector2 posDoorRed, Vector2 posDoorBlue)
    {
        CountDoor = 0;
        posOriginBlue = posBlue;
        posOriginRed = posRed;
        this.posDoorRed = posDoorRed;
        this.posDoorBlue = posDoorBlue;
        playerBlue.hasKey = false;
        playerRed.hasKey = false;

        playerBlue.Initialized();
        playerRed.Initialized();
        playerBlue.SetKinematic(false);
        playerRed.SetKinematic(false);
        playerBlue.ResetPlayer();
        playerBlue.transform.position = posBlue;
        playerRed.PlayerUpdateState();
        playerRed.transform.position = posRed;
        playerBlue.SetKinematic(true);
        playerRed.SetKinematic(false);
        currentPlayer = playerRed;
        UI_Manager.Instance.popupUI.GetGameUI().SetColorUI(currentPlayer.GetPlayerType() == PlayerType.Blue);

    }
    public void ResfeshPlayer()
    {
        currentPlayer.Resfesh();
     
    }
    public void SwitchPlayer()
    {
        if (currentPlayer == playerRed)
        {
            playerBlue.PlayerUpdateState();
            playerRed.ResetPlayer();
            playerRed.LockX();
            playerBlue.UnLockX();
            playerBlue.SetKinematic(false);
            playerRed.SetKinematic(true);
            currentPlayer = playerBlue;
        }
        else
        {
            playerBlue.SetKinematic(true);
            playerRed.SetKinematic(false);
            playerBlue.ResetPlayer();
            playerRed.PlayerUpdateState();
            playerRed.UnLockX();
            playerBlue.LockX();
            currentPlayer = playerRed;
        }

        UI_Manager.Instance.popupUI.GetGameUI().SetColorUI(currentPlayer.GetPlayerType() == PlayerType.Blue);

        CameraCtr.Instance.SetTarget(currentPlayer.transform);
    }


    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GetStateGame() == GameState.GamePause)
        {
           // playerRed.ResetPlayer();
          //  playerBlue.ResetPlayer();

        }
    }
}
