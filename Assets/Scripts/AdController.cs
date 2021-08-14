using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class AdController : MonoBehaviour 
{
	public BannerView bannerView;
	public InterstitialAd interstitial;

	void Start () 
	{
		MobileAds.Initialize(initStatus => { });

		if(SceneManager.GetActiveScene().name == "EntranceScene")
		{
			RequestBanner();
		}
		
		RequestInterstitial();
	}
	
	private void RequestBanner() 
	{
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/6300978111";// YOUR ANDROID BANNER AD ID HERE
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";// YOUR IOS BANNER AD ID HERE
        #else
            string adUnitId = "unexpected_platform";
        #endif

		AdSize adaptiveSize = AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);

        this.bannerView = new BannerView(adUnitId, adaptiveSize, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        this.bannerView.LoadAd(request);
    }

	private void RequestInterstitial() 
	{
		#if UNITY_ANDROID
			string adUnitId = "ca-app-pub-3940256099942544/1033173712";// YOUR ANDROID INTERSTITIAL AD ID HERE
		#elif UNITY_IPHONE
			string adUnitId = "ca-app-pub-3940256099942544/4411468910";// YOUR IOS INTERSTITIAL AD ID HERE
		#else
			string adUnitId = "unexpected_platform";
		#endif

		this.interstitial = new InterstitialAd(adUnitId);
		AdRequest request = new AdRequest.Builder().Build();
		this.interstitial.LoadAd(request);
	}
	
	public void ShowBanner()
    {
		RequestBanner();
	}

	public void HideBanner() 
    {
		bannerView.Destroy();
	}

	public void ShowInterstitial() 
    {
		if(interstitial.IsLoaded()) 
		{
			interstitial.Show();
		}

		RequestInterstitial();
	}
}