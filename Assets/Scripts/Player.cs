using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private enum CurrentMove { Right, Left}
    [SerializeField] CurrentMove currentMove;
    [SerializeField] private float speed;

    private bool dia = false;

    [Header("Visual")]
    [SerializeField] private GameObject playerSprite;
    private void Update()
    {
        if (dia) return;
        findPlayerManager();
        Movement();
    }

    private void Movement()
    {
        int x = 1;
        if (currentMove == CurrentMove.Right) x *= 1;
        else x *= -1;
        rotation();
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        transform.Translate(Vector2.right * x * speed * Time.deltaTime);

    }
    private void rotation()
    {
        if (currentMove == CurrentMove.Right) playerSprite.transform.rotation = Quaternion.Euler(0, 0, 45);
        else playerSprite.transform.rotation = Quaternion.Euler(0, 0, 135);
    }
    public void PlayerDia()
    {
        dia = true;
        PlayerManager.playerManager.PlayerDia();
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

    private void OnDrawGizmos()
    {
        if (dia) return;
        int x = 1;
        if (currentMove == CurrentMove.Right) x *= 1;
        else x *= -1;
        rotation();
    }
}
