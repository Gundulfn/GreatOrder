using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class AdController : MonoBehaviour 
{
	private BannerView bannerView;
	private RewardedInterstitialAd rewardedInterstitialAd;

	public bool isRewardedAdPlayed
	{
		get;
		private set;
	}

	void Start () 
	{
		MobileAds.Initialize(initStatus => { });

		if(SceneManager.GetActiveScene().name == "EntranceScene")
		{
			RequestBanner();
		}

		RequestRewardedInterstitial();
	}
	
	private void RequestBanner() 
	{
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
        #else
            string adUnitId = "unexpected_platform";
        #endif

		AdSize adaptiveSize = AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);

        this.bannerView = new BannerView(adUnitId, adaptiveSize, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        this.bannerView.LoadAd(request);
    }

	private void RequestRewardedInterstitial() 
	{
		#if UNITY_ANDROID
			string adUnitId = "ca-app-pub-3940256099942544/5354046379";
		#elif UNITY_IPHONE
			string adUnitId = "ca-app-pub-3940256099942544/6978759866";
		#else
			string adUnitId = "unexpected_platform";
		#endif

		AdRequest request = new AdRequest.Builder().Build();
        RewardedInterstitialAd.LoadAd(adUnitId, request, adLoadCallback);
	}
	
	private void adLoadCallback(RewardedInterstitialAd ad, AdFailedToLoadEventArgs args)
    {
        if (args == null)
        {
            rewardedInterstitialAd = ad;
        }
    }

	public void ShowRewardedInterstitialAd()
	{
		if (rewardedInterstitialAd != null)
		{
			rewardedInterstitialAd.Show(ExtraTimeRewardCallback);
			isRewardedAdPlayed = true;
		}
	}

	public void ExtraTimeRewardCallback(Reward reward)
	{
		GameModeHandler.instance.AddExtraTime();
	}

	public void ShowBanner()
    {
		RequestBanner();
	}

	public void HideBanner() 
    {
		bannerView.Destroy();
	}
}