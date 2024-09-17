using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartComponent : MonoBehaviour
{
    [SerializeField] private UnityEvent _action;
    void Start()
    {
        _action?.Invoke();   
    }

}
