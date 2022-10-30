using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerComponent : MonoBehaviour
{
    [SerializeField] private string _tag;
    [SerializeField] private UnityEvent action;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag ==_tag)
        {
            action?.Invoke();
        }
    }
}
