using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScreen : MonoBehaviour
{
    public void RightButton()
    {
        PlayerManager.playerManager.RightMove();
    }
    public void LeftButton()
    {
        PlayerManager.playerManager.LeftMove();
    }
}
