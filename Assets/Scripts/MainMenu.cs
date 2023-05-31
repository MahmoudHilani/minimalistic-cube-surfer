
using UnityEngine;
using UnityEngine.SceneManagement;
using HmsPlugin;
using HuaweiMobileServices.Ads;

public class MainMenu : MonoBehaviour
{
    public GameObject DoubleItButton;

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        try{
            HMSAdsKitManager.Instance.ShowInterstitialAd();
        }
        catch(System.Exception e){
            Debug.Log("Mainmenu ShowInterstitialAd Exception: " + e);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Mainmenu()
    {
        try{
            HMSAdsKitManager.Instance.ShowInterstitialAd();
        }
        catch(System.Exception e){
            Debug.Log("Mainmenu ShowInterstitialAd Exception: " + e);
        }
        SceneManager.LoadScene(0);
    }
    public void DoubleIt()
    {
        try{
            HMSAdsKitManager.Instance.OnRewarded = OnRewarded;
            HMSAdsKitManager.Instance.ShowRewardedAd();
            void OnRewarded(Reward reward)
            {
                Debug.Log("Reward received");
                FindObjectOfType<PlayerInventory>().DoubleCoins();
                DoubleItButton.SetActive(false);
            }
        }
        catch(System.Exception e){
            Debug.Log("Mainmenu ShowRewardedAd Exception: " + e);
        }
    }
}
