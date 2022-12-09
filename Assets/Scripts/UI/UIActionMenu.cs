using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIActionMenu : MonoBehaviour
{
    public Button btnPractice;
    public Button btnHealing;
    public Button btnBattle; 
    // Start is called before the first frame update
    void Start()
    {
        // GameObject ui = TabUI.GetInstance().GetUI("UIProfile");
        btnBattle.onClick.AddListener(OnClickBattle); //OnClickBattle이라는 함수를 온클릭에 넣어줌.
        btnHealing.onClick.AddListener(OnClickHealing);
    }

    // Update is called once per frame
    void OnClickBattle()
    {
        SCenesManager.GetInstance().ChangeScene(Scene.Battle); //배틀신으로 이동시키는 작업.
    }

    void OnClickHealing()
    {
        TabGameManager.GetInstance().SpendGold(300);
        TabGameManager.GetInstance().SetCurrentHP(50);
        
        GameObject ui = TabUI.GetInstance().GetUI("UIProfile");
        if (ui != null)
        {
            ui.GetComponent<UIProFile>().RefreshState();
        }
    }
}
