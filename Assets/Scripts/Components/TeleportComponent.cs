using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportComponent : MonoBehaviour
{
    [SerializeField] private bool playerMirror;
    private enum CurrentMove { Right, RightDown, LeftDown, Left }
    [SerializeField] CurrentMove currentMove;
    [SerializeField] private Transform teleportPosition;
    public void Teleport()
    {
        GameManager.gameManger.player[0].transform.position = teleportPosition.position;
        if (playerMirror) GameManager.gameManger.player[0].MirrorMove((int)currentMove);
    }
}
