using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private enum CurrentMove { Right, Left}
    [SerializeField] CurrentMove currentMove;
    [SerializeField] private float speed;
    private void Update()
    {
        findPlayerManager();
        Movement();
    }

    private void Movement()
    {
        int x = 1;
        if (currentMove == CurrentMove.Right) x *= 1;
        else x *= -1;
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        transform.Translate(Vector2.right * x * speed * Time.deltaTime);

    }

    public void LeftMove()
    {
        currentMove = CurrentMove.Left;
    }
    public void RightMove()
    {
        currentMove = CurrentMove.Right;
    }

    private void findPlayerManager()
    {
        PlayerManager.playerManager.findPlayer(this);
    }
}
