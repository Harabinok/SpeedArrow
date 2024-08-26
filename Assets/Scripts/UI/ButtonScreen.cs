using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] private GameObject leftButton;
    [SerializeField] private GameObject rightButton;
    [SerializeField] private GameObject jumpButton;
    public void RightButton()
    {
        PlayerManager.playerManager.RightMove();
    }
    public void LeftButton()
    {
        PlayerManager.playerManager.LeftMove();
    }

    public void Switch()
    {
        if (jumpButton.activeSelf == false)
        {
            jumpButton.SetActive(true);
            leftButton.SetActive(false);
            rightButton.SetActive(false);
        }
        else 
        {
            jumpButton.SetActive(false);
            leftButton.SetActive(false);
            rightButton.SetActive(false);
        }

    }
}
