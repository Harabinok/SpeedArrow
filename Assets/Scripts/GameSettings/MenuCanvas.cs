using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuCanvas : MonoBehaviour
{
    [SerializeField] private int sceanIndex;
    [SerializeField] private GameObject[] Levels;

    [Header("UI")]
    [SerializeField] private Button start;
    [SerializeField] private Button next;
    [SerializeField] private Button back;

    [SerializeField] private Text money;
    private void Awake()
    {
        for (int i = 0; i < Levels.Length; i++)
        {
            if (Levels[i].gameObject.activeSelf == true) sceanIndex = i;
        }
        money.text = $"{PlayerPrefs.GetInt("money")}";
    }
    public void StartLevel()
    {
        SceneManager.LoadScene(sceanIndex);
    }
    public void NextLevel()
    {
        sceanIndex++;
        if (sceanIndex >= Levels.Length)
        {
            sceanIndex = Levels.Length;
            next.interactable = false;
            return;
        }
        else next.interactable = true;
        for (int i = 0; i < Levels.Length; i++)
        {
            Levels[i].SetActive(false);
        }
        Levels[sceanIndex].SetActive(true);
        back.interactable = true;
    }
    public void BackLevel()
    {
        sceanIndex--;
        if (sceanIndex < 0)
        {
            sceanIndex = 0;
            back.interactable = false;
            return;
        }
        else back.interactable = true;
        for (int i = 0; i < Levels.Length; i++)
        {
            Levels[i].SetActive(false);
        }
        Levels[sceanIndex].SetActive(true);
        next.interactable = true;
    }
}
