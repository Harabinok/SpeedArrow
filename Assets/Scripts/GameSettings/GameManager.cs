using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager singleton;
    public static GameManager gameManger { get { return singleton; } }
    #endregion

    [Header("Events")]
    [SerializeField] private UnityEvent changeColor;

    [Header("UI")]

    [SerializeField] private Slider progress;

    [Header("GameObjects")]
    [SerializeField] private Transform finish;
    [SerializeField] public Player[] player;
    [SerializeField] public Camera[] camera;
    [SerializeField] public Wall[] wall;

    [Header("Game Rules")]
    [SerializeField] private bool GameMirror = false;

    private GameObject playerY;
    private ColorChange colorChange;
    private void Awake()
    {
        singleton = this;

        player = FindObjectsOfType<Player>();
        camera = FindObjectsOfType<Camera>();
        wall = FindObjectsOfType<Wall>();
        colorChange = GetComponentInChildren<ColorChange>();

        playerY = new GameObject();
        playerY.transform.position = finish.transform.position;
        playerY.transform.position = new Vector2(playerY.transform.position.x, player[0].transform.position.y);
        print(playerY.transform.position);
        var distance = Vector2.Distance(finish.position, playerY.transform.position);
        progress.maxValue = distance;
    }

    private void Update()
    {
        playerY.transform.position = new Vector2(playerY.transform.position.x, player[0].transform.position.y);
        var distance = Vector2.Distance(finish.position, playerY.transform.position);
        progress.value = progress.maxValue - distance;


    }
    public void ColorsChange(int _index)
    {
        colorChange.SelectColors(_index);
        changeColor?.Invoke();
    }
    public void MirrorGameSet()
    {
        GameMirror = !GameMirror;
        MirrorGame();
    }
    private void MirrorGame()
    {
        ButtonScreen.buttonScreen.RotationComponent.NewRotationOn180();
        CameraMenu.cameraMenu.GetCameraVC().GetComponent<RotationComponent>().NewRotationOn180();
    }
}
