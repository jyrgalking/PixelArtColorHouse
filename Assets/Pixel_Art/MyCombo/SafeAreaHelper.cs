using UnityEngine;

public class SafeAreaHelper : MonoBehaviour {

	private RectTransform panel;

	void Start ()
    {
        panel = GetComponent<RectTransform>();
#if UNITY_IOS
        ApplySafeArea();
#endif
    }

	void ApplySafeArea()
	{
		var anchorMin = Screen.safeArea.position;
		var anchorMax = Screen.safeArea.position + Screen.safeArea.size;
		anchorMin.x /= Screen.width;
		anchorMin.y /= Screen.height;
		anchorMax.x /= Screen.width;
		anchorMax.y /= Screen.height;
		panel.anchorMin = anchorMin;
		panel.anchorMax = anchorMax;
	}
}
