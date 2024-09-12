using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinConmponent : MonoBehaviour
{
    [SerializeField] private string idMoney;

    public void SaveMoney()
    {
        if (idMoney == "") return;
        PlayerPrefs.SetString($"{idMoney}", "true");
    }
    public void LoadCoin()
    {
        var enb = PlayerPrefs.GetString(idMoney);
        if (enb == "") return;
        print(enb);
        if(enb == "true") Destroy(gameObject);
    }
}
