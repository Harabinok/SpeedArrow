using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeTriggerComponent : MonoBehaviour
{
    [SerializeField] private int indexColorChange;

    public void ColorChange()
    {
        GameManager.gameManger.ColorsChange(indexColorChange);
    }
}
