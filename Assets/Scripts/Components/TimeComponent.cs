using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeComponent : MonoBehaviour
{
    public void SetScaleTime(int time)
    {
        Time.timeScale = time;
    }
}
