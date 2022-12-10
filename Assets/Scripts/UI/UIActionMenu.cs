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
        btnBattle.onClick.AddListener(OnClickBattle); //OnClickBattle�̶�� �Լ��� ��Ŭ���� �־���.
        btnHealing.onClick.AddListener(OnClickHealing);
    }

    // Update is called once per frame
    void OnClickBattle()
    {
        SCenesManager.GetInstance().ChangeScene(Scene.Battle); //��Ʋ������ �̵���Ű�� �۾�.
    }

    void OnClickHealing()
    {
        
        
        TabGameManager.GetInstance().SpendGold(300);
        TabGameManager.GetInstance().SetCurrentHP(50);
            var particle = ObjectManager.GetInstance().CreateHealEffect();
        //ParticleSystem particle = ObjectManager.GetInstance().CreateHitEffect(); �� ����.
        //�Լ� �ȿ����� ����.
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
