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
        // Создаем загрузчик рекламы
        interstitialAdLoader = new InterstitialAdLoader();

        // Подписываемся на события загрузки и ошибки
        interstitialAdLoader.OnAdLoaded += HandleAdLoaded;
        interstitialAdLoader.OnAdFailedToLoad += HandleAdFailedToLoad;
    }

    // Метод для запроса межстраничной рекламы
    public void RequestInterstitial()
    {
        MobileAds.SetAgeRestrictedUser(true);  // COPPA - пользователь младше 13 лет

        string adUnitId = "R-M-12176701-1";  // Замените на реальный идентификатор рекламного блока

        // Если реклама уже загружена, уничтожаем её перед новой загрузкой
        if (interstitial != null)
        {
            interstitial.Destroy();
        }

        interstitialAdLoader.LoadAd(CreateAdRequest(adUnitId));
        DisplayMessage("Запрошена межстраничная реклама.");
    }

    // Метод для показа межстраничной рекламы
    public void ShowInterstitial()
    {
        if (interstitial == null)
        {
            DisplayMessage("Межстраничная реклама еще не готова.");
            return;
        }
        print("SSS");
        // Подписываемся на события показа рекламы
        interstitial.OnAdClicked += HandleAdClicked;
        interstitial.OnAdShown += HandleAdShown;
        interstitial.OnAdFailedToShow += HandleAdFailedToShow;
        interstitial.OnAdImpression += HandleImpression;
        interstitial.OnAdDismissed += HandleAdDismissed;
        print("1233123312");
        // Показ рекламы
        interstitial.Show();
    }

    // Создание запроса для рекламы
    private AdRequestConfiguration CreateAdRequest(string adUnitId)
    {
        return new AdRequestConfiguration.Builder(adUnitId).Build();
    }

    // Отображение сообщений
    private void DisplayMessage(string message)
    {
        this.message = message + (this.message.Length == 0 ? "" : "\n--------\n" + this.message);
        Debug.Log(message);
    }

    #region Обработчики событий рекламы

    // Когда реклама успешно загружена
    public void HandleAdLoaded(object sender, InterstitialAdLoadedEventArgs args)
    {
        DisplayMessage("Реклама успешно загружена.");
        interstitial = args.Interstitial;
    }

    // Когда реклама не загрузилась
    public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        DisplayMessage($"Ошибка загрузки рекламы: {args.Message}");
    }

    // Когда реклама была показана
    public void HandleAdShown(object sender, EventArgs args)
    {
        DisplayMessage("Реклама показана.");
    }

    // Когда реклама была закрыта пользователем
    public void HandleAdDismissed(object sender, EventArgs args)
    {
        DisplayMessage("Реклама закрыта.");
        interstitial.Destroy();
        interstitial = null;
    }

    // Когда пользователь кликнул по рекламе
    public void HandleAdClicked(object sender, EventArgs args)
    {
        DisplayMessage("Клик по рекламе.");
    }

    // Когда возникла ошибка показа рекламы
    public void HandleAdFailedToShow(object sender, AdFailureEventArgs args)
    {
        DisplayMessage($"Ошибка показа рекламы: {args.Message}");
    }

    // Когда была зафиксирована импрессия рекламы (показ)
    public void HandleImpression(object sender, ImpressionData impressionData)
    {
        string data = impressionData == null ? "null" : impressionData.rawData;
        DisplayMessage($"Зафиксирована импрессия: {data}");
    }

    #endregion
}
