using System;
using UnityEngine;
using YandexMobileAds;
using YandexMobileAds.Base;

public class YandexMobileAdsInterstitial : MonoBehaviour
{
    private InterstitialAdLoader interstitialAdLoader;
    private Interstitial interstitial;
    private string message = "";

    public void Awake()
    {
        // ������� ��������� �������
        interstitialAdLoader = new InterstitialAdLoader();

        // ������������� �� ������� �������� � ������
        interstitialAdLoader.OnAdLoaded += HandleAdLoaded;
        interstitialAdLoader.OnAdFailedToLoad += HandleAdFailedToLoad;
    }

    // ����� ��� ������� ������������� �������
    public void RequestInterstitial()
    {
        MobileAds.SetAgeRestrictedUser(true);  // COPPA - ������������ ������ 13 ���

        string adUnitId = "R-M-12176701-1";  // �������� �� �������� ������������� ���������� �����

        // ���� ������� ��� ���������, ���������� � ����� ����� ���������
        if (interstitial != null)
        {
            interstitial.Destroy();
        }

        interstitialAdLoader.LoadAd(CreateAdRequest(adUnitId));
        DisplayMessage("��������� ������������� �������.");
    }

    // ����� ��� ������ ������������� �������
    public void ShowInterstitial()
    {
        if (interstitial == null)
        {
            DisplayMessage("������������� ������� ��� �� ������.");
            return;
        }
        print("SSS");
        // ������������� �� ������� ������ �������
        interstitial.OnAdClicked += HandleAdClicked;
        interstitial.OnAdShown += HandleAdShown;
        interstitial.OnAdFailedToShow += HandleAdFailedToShow;
        interstitial.OnAdImpression += HandleImpression;
        interstitial.OnAdDismissed += HandleAdDismissed;
        print("1233123312");
        // ����� �������
        interstitial.Show();
    }

    // �������� ������� ��� �������
    private AdRequestConfiguration CreateAdRequest(string adUnitId)
    {
        return new AdRequestConfiguration.Builder(adUnitId).Build();
    }

    // ����������� ���������
    private void DisplayMessage(string message)
    {
        this.message = message + (this.message.Length == 0 ? "" : "\n--------\n" + this.message);
        Debug.Log(message);
    }

    #region ����������� ������� �������

    // ����� ������� ������� ���������
    public void HandleAdLoaded(object sender, InterstitialAdLoadedEventArgs args)
    {
        DisplayMessage("������� ������� ���������.");
        interstitial = args.Interstitial;
    }

    // ����� ������� �� �����������
    public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        DisplayMessage($"������ �������� �������: {args.Message}");
    }

    // ����� ������� ���� ��������
    public void HandleAdShown(object sender, EventArgs args)
    {
        DisplayMessage("������� ��������.");
    }

    // ����� ������� ���� ������� �������������
    public void HandleAdDismissed(object sender, EventArgs args)
    {
        DisplayMessage("������� �������.");
        interstitial.Destroy();
        interstitial = null;
    }

    // ����� ������������ ������� �� �������
    public void HandleAdClicked(object sender, EventArgs args)
    {
        DisplayMessage("���� �� �������.");
    }

    // ����� �������� ������ ������ �������
    public void HandleAdFailedToShow(object sender, AdFailureEventArgs args)
    {
        DisplayMessage($"������ ������ �������: {args.Message}");
    }

    // ����� ���� ������������� ��������� ������� (�����)
    public void HandleImpression(object sender, ImpressionData impressionData)
    {
        string data = impressionData == null ? "null" : impressionData.rawData;
        DisplayMessage($"������������� ���������: {data}");
    }

    #endregion
}
