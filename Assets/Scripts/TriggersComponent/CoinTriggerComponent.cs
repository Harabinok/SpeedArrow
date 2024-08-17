using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTriggerComponent : MonoBehaviour
{
    public void AddCoin()
    {
        GameManager.gameManger.AddCoin();
    }
}
