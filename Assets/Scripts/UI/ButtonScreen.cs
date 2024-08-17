using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScreen : MonoBehaviour
{
    #region Singleton
    private static ButtonScreen singleton;
    public static ButtonScreen buttonScreen { get { return singleton; } }
    private void Awake()
    {
        singleton = this;
    }
    #endregion
    public RotationComponent RotationComponent;
    public void RightButton()
    {
        PlayerManager.playerManager.RightMove();
    }
    public void LeftButton()
    {
        PlayerManager.playerManager.LeftMove();
    }
}
