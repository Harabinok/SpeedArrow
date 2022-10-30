using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region singletone
    private static PlayerManager singletone;
    public static PlayerManager playerManager { get { return singletone; } }
    #endregion

    private Player player;


    private void Awake()
    {
        singletone = this;
    }
    public void LeftMove()
    {
        player.LeftMove();
    }
    public void RightMove()
    {
        player.RightMove();
    }

    public void findPlayer(Player _player)
    {
        player = _player;
    }
}
