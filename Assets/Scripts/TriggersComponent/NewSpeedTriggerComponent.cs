using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpeedTriggerComponent : MonoBehaviour
{
    [SerializeField] private int speed;
    public void NewSpeed()
    {
        GameManager.gameManger.player[0].NewSpeed(speed);
    }
}
