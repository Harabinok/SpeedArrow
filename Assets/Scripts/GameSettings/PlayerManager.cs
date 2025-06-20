using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    #region singletone
    private static PlayerManager singletone;
    public static PlayerManager playerManager { get { return singletone; } }
    #endregion

    [SerializeField] private UnityEvent _onDia;
    [SerializeField] private UnityEvent _onFinish;
    private Player player;


    private void Awake()
    {
        singletone = this;
    }
    public void NewSpeed(float speed)
    {
        player.NewSpeed(speed);
    }
    public void LeftMove()
    {
        player.LeftMove();
    }
    public void RightMove()
    {
        player.RightMove();
    }
    public void Finish()
    {
        _onFinish?.Invoke();
    }
    public void Jump()
    {
        player.JumpBall();
    }
    public void PlayerDia()
    {
        _onDia?.Invoke();
    }
    public void findPlayer(Player _player)
    {
        player = _player;
    }
}
