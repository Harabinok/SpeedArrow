using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerComponent : MonoBehaviour
{
    [SerializeField] private UnityEvent action;
    [SerializeField] private float TimeForTimer;
    private float historyTime;
    private bool timerWork = false;

    private void Awake()
    {
        historyTime = TimeForTimer;
    }

    private void Update()
    {
        if (!timerWork) return;
        TimeForTimer -= Time.deltaTime;
        if(TimeForTimer <= 0)
        {
            timerWork = false;
            action?.Invoke();
        }
    }
    public void StartTimer()
    {
        timerWork = true;
    }
    public void StopTimer()
    {
        timerWork = false;
    }
    public void RestartTimer()
    {
        timerWork = true;
        TimeForTimer = historyTime;
    }
}
