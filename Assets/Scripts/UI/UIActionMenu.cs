using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIActionMenu : MonoBehaviour
{
    public Button btnPractice;
    public Button btnHealing;
    public Button btnBattle;
    public AudioSource healSound;
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
            var particle = ObjectManager.GetInstance().CreateHealEffect();
        //ParticleSystem particle = ObjectManager.GetInstance().CreateHitEffect(); 와 같음.
        //함수 안에서만 가능.
        particle.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        particle.transform.localPosition = new Vector3(0 , 3 , 0);
        healSound.Play();

        GameObject ui = TabUI.GetInstance().GetUI("UIProfile");
        if (ui != null)
        {
            ui.GetComponent<UIProFile>().RefreshState();
            ui.GetComponent<UIProFile>().HPBarChange();
        }
    }
}
