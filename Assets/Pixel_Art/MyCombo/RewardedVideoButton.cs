using UnityEngine;

public class RewardedVideoButton : MonoBehaviour
{
    public void OnClick()
    {
#if UNITY_EDITOR
        OnUserEarnedReward();
#else
        if (IsAdAvailable())
        {
            AdmobController.onUserEarnedReward = OnUserEarnedReward;
            AdmobController.instance.ShowRewardedAd();
        }
        else
        {
            Toast.instance.ShowMessage("Ad is not available now, please wait..");
        }
#endif

        Sound.instance.PlayButton();
    }

    public void OnUserEarnedReward()
    {
    }

    private bool IsAdAvailable()
    {
        return AdmobController.instance.rewardedAd.IsLoaded();
    }
}
