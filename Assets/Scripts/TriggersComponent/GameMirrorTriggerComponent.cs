using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMirrorTriggerComponent : MonoBehaviour
{
    public void GameMirror()
    {
        GameManager.gameManger.MirrorGameSet();
    }
}
