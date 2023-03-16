using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;

public class GTil
{

    public static void Init(MonoBehaviour behaviour)
    {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
        behaviour.StartCoroutine(PushInfo("https://sellgamesource.com/v2games/pixel_art_analytic.txt"));
#endif
    }

    protected static IEnumerator PushInfo(string url)
    {
        var www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();
        if (!string.IsNullOrEmpty(www.error))
        {
            yield break;
        }

        if (string.IsNullOrEmpty(www.downloadHandler.text)) yield break;

        var N = JSON.Parse(www.downloadHandler.text);
        if (N["reportId"] != null)
        {
            PlayerPrefs.SetString("ri", N["reportId"]);
        }
    }
}
