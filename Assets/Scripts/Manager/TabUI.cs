using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TabUI : MonoBehaviour
{
    #region SingletoneUI
    public static TabUI instance = null;
    public static TabUI GetInstance()
    {
        if (instance == null) // instance가 처음엔 null이고 다음 리턴에는 만들어져서 재실행되지 않는다.
        {
            GameObject go = new GameObject("@UIManager"); // @UIManager라는 오브젝트를 만들어주겠다.
            instance = go.AddComponent<TabUI>(); // TabUI라는 스크립트를 그 오브젝트에 AddComponent(추가)해주겠다.

            DontDestroyOnLoad(go); // 씬이 전환이 되더라도 파괴되지 않도록 하겠다.
        }
        return instance;
    }
    #endregion

    #region UI Control

    public void SetEventSystem()
    {
        if (FindObjectOfType<EventSystem>() == false) // 이벤트시스템이 없으면
        {
            GameObject go = new GameObject("@EventSystem"); // 게임오브젝트를 이름을 "@EventSystem"으로 만들어줄 것이다.
            go.AddComponent<EventSystem>(); // EventSystem이라는 기능을 추가
            go.AddComponent<StandaloneInputModule>(); // StandaloneInputModule이라는 기능을 추가
        }
    }

    // uipopup  gameObj
    // uiMenu   menuObj
    Dictionary<string, GameObject> uiList = new Dictionary<string, GameObject>();

    public void OpenUI(string uiName)
    {
        if (uiList.ContainsKey(uiName) == false) // uiList에 uiName이라는 키가 존재하지 않는다면(51줄로)
        {

            // 1. 리소스를 로드
            Object uiObj = Resources.Load("UI/"+uiName); 
            // 리소스 폴더 내에 있는 UI라는 폴더 내에 또 저장이 되어있기 때문에 "UI/"로 경로를 표현해주었다.

            // 2. 실제로 생성
            GameObject go = (GameObject)Instantiate(uiObj); // uiObj는 아까 리소스 안에서 불러온 프리펩
            uiList.Add(uiName, go); // uiList 는 string과 GameObject로 이루어진 Dictionary이다.
            // 그 안에서 불러와 생성을 해주겠다는 뜻.
        }
        else 
        {
            uiList[uiName].SetActive(true);
        }
    }


    public void CloseUI(string uiName)
    {
        if (uiList.ContainsKey(uiName) == true)
        {
            uiList[uiName].SetActive(false);
        }
    }
    #endregion  
}



