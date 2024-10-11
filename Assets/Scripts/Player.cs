using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private enum CurrentMove { Right, RightDown, LeftDown, Left}
    private enum GameMode { Arrow, Ball}
    [SerializeField] private CurrentMove currentMove;
    [SerializeField] private GameMode gameMode;
    

    [Header("Arrow")]
    [SerializeField] private float speedArrow;

    [Header("Ball")]
    [SerializeField] private float speedBall;
    [SerializeField] private float jumpImpuls;


    private bool dia = false;
    private bool cheats = false;

    private Rigidbody2D rd2d;

    [Header("Visual")]
    [SerializeField] private GameObject playerSprite;

    public SpriteRenderer GetSprite()
    {
        return playerSprite.GetComponent<SpriteRenderer>();
    }
    private void Awake()
    {
        if (rd2d == null) { rd2d = GetComponent<Rigidbody2D>(); }

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
        
        if (!dia &&  gameMode == GameMode.Arrow)
        {
            MovementArrow();
        }
        
    }
    private void FixedUpdate()
    {
        if (!dia && gameMode == GameMode.Ball)
        {

            MovementBall();
        }
    }

    private void MovementArrow()
    {
        int x = 1;
        int y = 1;
        switch (currentMove)
        {
            case CurrentMove.Right:
                y *= 1;
                x *= 1;
                rotationArrow(45);
                break;
            case CurrentMove.Left:
                y *= 1;
                x *= -1;
                rotationArrow(135);
                break;
            case CurrentMove.RightDown:
                y *= -1;
                x *= 1;
                rotationArrow(315);
                break;
            case CurrentMove.LeftDown:
                y *= -1;
                x *= -1;
                rotationArrow(225);
                break;
        }

        transform.Translate(Vector2.up *y * speedArrow * Time.deltaTime);
        transform.Translate(Vector2.right * x * speedArrow * Time.deltaTime);

    }
    private void MovementBall()
    {
        rd2d.velocity = new Vector2(speedBall, rd2d.velocity.y);
    }
    private void rotationArrow(int z)
    {
        playerSprite.transform.rotation = Quaternion.Euler(0, 0, z);
    }
    public void PlayerDia()
    {
        //GameManager.gameManger.yandexMobileAdsInterstitial.ShowInterstitial();
        if (cheats)
        {
            return;
        }
        dia = true;
        GameManager.gameManger.AddDeadCount();
        PlayerManager.playerManager.PlayerDia();
        
    }
    public void MirrorMove(int indexMove)
    {
        currentMove = (CurrentMove)indexMove;
    }
    public void JumpBall()
    {
        rd2d.AddForce(Vector2.up * jumpImpuls,ForceMode2D.Impulse);
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
        speedArrow = _speed;
        speedBall = _speed;
    }

    public void Switch()
    {
        ButtonScreen.buttonScreen.Switch();
        if (gameMode == GameMode.Arrow)
        {
            rd2d.bodyType = RigidbodyType2D.Dynamic;
            gameMode = GameMode.Ball;
            return;
        }
        if (gameMode == GameMode.Ball)
        {
            rd2d.bodyType = RigidbodyType2D.Kinematic;
            gameMode = GameMode.Arrow;
            return;
        }
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
