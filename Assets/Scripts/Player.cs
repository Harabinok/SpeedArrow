using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private enum CurrentMove { Right, RightDown, LeftDown, Left}
    [SerializeField] CurrentMove currentMove;
    [SerializeField] private float speed;

    private bool dia = false;
    private bool cheats = false;

    [Header("Visual")]
    [SerializeField] private GameObject playerSprite;

    public SpriteRenderer GetSprite()
    {
        return playerSprite.GetComponent<SpriteRenderer>();
    }
    private void Awake()
    {
        
    }
    private void Start()
    {
        findPlayerManager();
    }
    private void Update()
    {
        if (Debug.isDebugBuild)
        {
            if (Input.GetKeyDown(KeyCode.C)) cheats = !cheats;
            if (Input.GetKeyDown(KeyCode.D)) RightMove();
            if (Input.GetKeyDown(KeyCode.A)) LeftMove();
        }
        
        if (dia && !cheats) return;
        Movement();
    }

    private void Movement()
    {
        int x = 1;
        int y = 1;
        switch (currentMove)
        {
            case CurrentMove.Right:
                y *= 1;
                x *= 1;
                rotation(45);
                break;
            case CurrentMove.Left:
                y *= 1;
                x *= -1;
                rotation(135);
                break;
            case CurrentMove.RightDown:
                y *= -1;
                x *= 1;
                rotation(315);
                break;
            case CurrentMove.LeftDown:
                y *= -1;
                x *= -1;
                rotation(225);
                break;
        }

        transform.Translate(Vector2.up *y * speed * Time.deltaTime);
        transform.Translate(Vector2.right * x * speed * Time.deltaTime);

    }
    private void rotation(int z)
    {
        playerSprite.transform.rotation = Quaternion.Euler(0, 0, z);
    }
    public void PlayerDia()
    {
        if (cheats)
        {
            return;
        }
        dia = true;
        PlayerManager.playerManager.PlayerDia();
    }
    public void MirrorMove(int indexMove)
    {
        currentMove = (CurrentMove)indexMove;
    }
    public void LeftMove()
    {
        int rot = ((int)currentMove);
        if (rot == 0) rot = System.Enum.GetValues(typeof(CurrentMove)).Length - 1;
        else rot--;
        currentMove = (CurrentMove)rot;
    }
    public void RightMove()
    {
        int rot = ((int)currentMove);
        if (rot == System.Enum.GetValues(typeof(CurrentMove)).Length - 1) rot = 0;
        else rot++;
        currentMove = (CurrentMove)rot;
    }
    public void NewSpeed(float _speed)
    {
        speed = _speed;
    }

    private void findPlayerManager()
    {
        PlayerManager.playerManager.findPlayer(this);
    }

    private void OnDrawGizmos()
    {/*
        if (dia) return;
        int x = 1;
        if (currentMove == CurrentMove.Right) x *= 1;
        else x *= -1;
        rotation();
        */
    }
}
