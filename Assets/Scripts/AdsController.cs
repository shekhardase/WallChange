using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class AdsController : MonoBehaviour
{
    private string storeId = "3439021";
    private static string videoAd = "video";

    private void Start()
    {
        Monetization.Initialize(storeId, true);
    }

    public static void VideoAd()
    {
        if (Monetization.IsReady(videoAd))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(videoAd) as ShowAdPlacementContent;
            if (ad != null)
            {
                ad.Show();
            }
        }
    }
}
