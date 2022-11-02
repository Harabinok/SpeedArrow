using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColorChange : MonoBehaviour
{
    [SerializeField] private Colors[] colors;

    public void SelectColors(int _index)
    {
        var wall = GameManager.gameManger.wall;
        var player = GameManager.gameManger.player;
        var camera = GameManager.gameManger.camera;
            for (int p = 0; p < player.Length; p++)
            {
                player[p].GetSprite().color = colors[_index].Player;
            }
            for (int w = 0; w < wall.Length; w++)
            {
                wall[w].GetComponent<SpriteRenderer>().color = colors[_index].Wall;
            }
            for (int c = 0; c < camera.Length; c++)
            {
                camera[c].backgroundColor = colors[_index].camera;
            }
    }
}
[Serializable]
public class Colors
{
    [SerializeField] private Color _player;
    [SerializeField] private Color _wall;
    [SerializeField] private Color _camera;

    public Color Player => _player;
    public Color Wall => _wall;
    public Color camera => _camera;
}
