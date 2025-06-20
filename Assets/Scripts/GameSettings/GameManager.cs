using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager singleton;
    public static GameManager gameManger { get { return singleton; } }
    #endregion

    public static int deathCount = 0;
    [SerializeField] public YandexMobileAdsInterstitial yandexMobileAdsInterstitial;
    [Header("Events")]
    [SerializeField] private UnityEvent changeColor;

    [Header("UI")]

    [SerializeField] private Slider progress;
    [SerializeField] private TextMeshPro deathCountText;

    [Header("GameObjects")]
    [SerializeField] private Transform finish;
    [SerializeField] public Player[] player;
    [SerializeField] public Camera[] camera;
    [SerializeField] public Wall[] wall;
    [SerializeField] public CoinConmponent[] coins;

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
        coins = FindObjectsOfType<CoinConmponent>();
        finish = FindObjectOfType<TriggerFinishComponent>().transform;
        colorChange = GetComponentInChildren<ColorChange>();
        yandexMobileAdsInterstitial.RequestInterstitial();

        playerY = new GameObject();
        playerY.transform.position = finish.transform.position;
        playerY.transform.position = new Vector2(playerY.transform.position.x, player[0].transform.position.y);
        print(playerY.transform.position);
        var distance = Vector2.Distance(finish.position, playerY.transform.position);
        progress.maxValue = distance;
    }
    private void Start()
    {
        for (int i = 0; i < coins.Length; i++)
        {
            coins[i].LoadCoin();
        }
    }
    private void Update()
    {
        playerY.transform.position = new Vector2(playerY.transform.position.x, player[0].transform.position.y);
        var distance = Vector2.Distance(finish.position, playerY.transform.position);
        progress.value = progress.maxValue - distance;

    }
    private void OnEnable()
    {
        deathCountText.text = $"{deathCount}";
    }
    bool addDeadCount = false;
    public void AddDeadCount()
    {
        if (addDeadCount) return; addDeadCount = true;
        if(deathCount == 5)
        {
            yandexMobileAdsInterstitial.ShowInterstitial();
        }
       var d = deathCount+= 1;
        print(d);
    }
    public void AddCoin()
    {
        var coin = PlayerPrefs.GetInt("money");
        PlayerPrefs.SetInt("money",coin + 1);
        print($"�� ������ {PlayerPrefs.GetInt("money")} �����");
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
