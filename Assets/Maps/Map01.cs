using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map01 : MonoBehaviour
{
    

    public static Map01 Instanse;

    private void Awake()
    {
        Instanse = this;

        
    }

    public int statusFirstOpen
    {
        get => PlayerPrefs.GetInt("firstopen", 0);
        set => PlayerPrefs.SetInt("firstopen", value);
    }

    public float animTime = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
       

        if (statusFirstOpen == 0)
        {
            statusFirstOpen = 1;
            Invoke("HideAnim", 0.3f);
        }
        else
        {
            ShowElements();
        }

    }

    [Header("Map Sprites")]
    [SerializeField]
    public GameObject[] elements;
    [SerializeField]
    public GameObject el43_02, el43_03, el46_02;


    //
    public void HideAnim()
    {
        iTween.FadeTo(elements[48].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[46].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[26].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[7].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[18].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[6].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[2].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[24].gameObject, 0f, animTime); //Hide

        Invoke("HideAnim01", 0.50f);
    }


    private void HideAnim01()
    {

        iTween.FadeTo(elements[47].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[25].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[22].gameObject, 0f, animTime); //Hide

        Invoke("HideAnim02", 0.50f);
    }

    private void HideAnim02()
    {
        iTween.FadeTo(elements[44].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[37].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[38].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[39].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[29].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[16].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[13].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[27].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[1].gameObject, 0f, animTime); //Hide

        Invoke("HideAnim03", 0.50f);
    }


    private void HideAnim03()
    {

        iTween.FadeTo(elements[43].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[34].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[30].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[41].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[9].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[23].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[28].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[40].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[8].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[33].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[42].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[45].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[11].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(el43_02.gameObject, 0f, animTime); //Hide
        iTween.FadeTo(el43_03.gameObject, 0f, animTime); //Hide
        iTween.FadeTo(el46_02.gameObject, 0f, animTime); //Hide

        Invoke("HideAnim04", 0.50f);
    }

    private void HideAnim04()
    {
        iTween.FadeTo(elements[3].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[10].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[49].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[51].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[50].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[32].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[14].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[17].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[52].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[31].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[36].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[35].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[4].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[19].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[0].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[5].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[12].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[15].gameObject, 0f, animTime); //Hide
        iTween.FadeTo(elements[21].gameObject, 0f, animTime); //Hide

        Invoke("ShowElements", animTime);
    }



    //Show Elements
    public void ShowElements()
    {
        for (int i = 1; i <= elements.Length; i++)
        {
            string item = "item_status_" + i;

            string status = PlayerPrefs.GetString(item);

            if(status == "complete")
            {

                iTween.FadeTo(elements[i - 1].gameObject, 1f, 0f);

                if (i == 42)
                {
                    iTween.FadeTo(el43_02.gameObject, 1f, 0f);
                    iTween.FadeTo(el43_03.gameObject, 1f, 0f);
                }
                if (i == 45)
                {
                    iTween.FadeTo(el46_02.gameObject, 1f, 0f);
                }
            }
            else
            {
                if(i == 42)
                {
                    iTween.FadeTo(el43_02.gameObject, 0f, 0f);
                    iTween.FadeTo(el43_03.gameObject, 0f, 0f);
                }
                if(i == 45)
                {
                    iTween.FadeTo(el46_02.gameObject, 0f, 0f);
                }

                iTween.FadeTo(elements[i - 1].gameObject, 0f, 0f);
            }
        }
        
    }

    public void ShowAnimElement()
    {

        //ShowElements();

        //PlayerPrefs.SetString("item_status_" + name, "complete");

        string name = PlayerPrefs.GetString("statusIteamkey");
        string itemStatusPrefKey = "item_status_" + name;
        PlayerPrefs.SetString(itemStatusPrefKey, "complete");

        Debug.Log("Show name => " + name);

        for (int i = 0; i < elements.Length; i++)
        {
            if(elements[i].name == name)
            {

                Debug.Log("Show Element Win");

                Zoom.Instance.SetPossition(i);

                iTween.FadeTo(elements[i].gameObject, 1f, 1.3f);

                if (name == "43")
                {
                    iTween.FadeTo(el43_02.gameObject, 1f, 1.3f);
                    iTween.FadeTo(el43_03.gameObject, 1f, 1.3f);
                }

                if (name == "46")
                {
                    iTween.FadeTo(el46_02.gameObject, 1f, 1.3f);
                }

                break;
            }
        }

    }


    bool valueTest = true;
    public void TestFadeOut()
    {
        Zoom.Instance.SetPossition(0);

        //elements[0].gameObject.SetActive(false);

        if(valueTest)
        {
            //iTween.FadeFrom(elements[0].gameObject, 0f, animTime); //Show
            iTween.FadeTo(elements[0].gameObject, 0f, animTime); //Hide
            valueTest = false;
        }

        else
        {
            iTween.FadeTo(elements[0].gameObject, 1f, animTime); //Hide
            valueTest = true;
        }
    }


    private int keyDetal = 1;
    public void TestShow()
    {

        PlayerPrefs.SetString("statusIteamkey", "" + keyDetal);
        ShowAnimElement();

        keyDetal++;

        if(keyDetal > elements.Length)
        {
            keyDetal = 1;
        }
    }

}
