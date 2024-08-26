using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGamePlayTriggerComponent : MonoBehaviour
{
    public void Switch()
    {
        GameManager.gameManger.player[0].Switch();
    }
}
