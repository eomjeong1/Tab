using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TabBattleManager : MonoBehaviour
{
    #region SingletoneUI
    public static TabBattleManager instance = null;
    public static TabBattleManager GetInstance()
    {
        if (instance == null) // instance�� ó���� null�̰� ���� ���Ͽ��� ��������� �������� �ʴ´�.
        {
            GameObject go = new GameObject("@TabBattleManager"); // @UIManager��� ������Ʈ�� ������ְڴ�.
            instance = go.AddComponent<TabBattleManager>(); // TabUI��� ��ũ��Ʈ�� �� ������Ʈ�� AddComponent(�߰�)���ְڴ�.

            DontDestroyOnLoad(go); // ���� ��ȯ�� �Ǵ��� �ı����� �ʵ��� �ϰڴ�.
        }
        return instance;
    }
    #endregion
    
    public Monster1 monsterData;
    public BattleScene BattleScene;
    GameObject uiTab;

    public void Start()
    {
        BattleScene = FindObjectOfType<BattleScene>();
    }



    public void BattleStart(Monster1 monster)
    { 
        monsterData = monster;
        

        TabUI.GetInstance().OpenUI("UITab");

        

        StartCoroutine("BattleProgress");
    }

    // 2~3 �� �ð��� ������ ���Ͱ� ���� ����
    IEnumerator BattleProgress()
    {
        while (TabGameManager.GetInstance().curHP > 0)
        {
            yield return new WaitForSeconds(monsterData.delay);

            int damage = monsterData.atk;
            TabGameManager.GetInstance().SetCurrentHP(-damage);

            GameObject ui = TabUI.GetInstance().GetUI("UIProfile");
            if (ui != null)
            {
                ui.GetComponent<UIProFile>().RefreshState();
                ui.GetComponent<UIProFile>().HPBarChange();
            }


            Debug.Log($"���Ͱ� �÷��̾�� ������ �߽��ϴ�. - ������ : {damage} ���� ü�� :{TabGameManager.GetInstance().curHP}");

        }
        Lose(); // while ���� ~�ϴ� ���� ��� ����Ǳ⶧���� 0 �� �Ǹ� ���ٴ� ��.

    }
   

    void Victory()
    {
        ObjectManager.GetInstance().ImgVictory();
        Debug.Log("���ӿ��� �¸��߽��ϴ�.");
        StopCoroutine("BattleProgress");
        // StopAllCoroutines�� �ڷ�ƾ ���� ������ 
        TabUI.GetInstance().CloseUI("UITab");

        TabGameManager.GetInstance().AddGold(monsterData.gold);

        Invoke("MoveToMain", 2.5f);
    }

    void Lose()
    {
        ObjectManager.GetInstance().ImgGameOver();
        Debug.Log("���ӿ��� �й��߽��ϴ�.");
        TabUI.GetInstance().CloseUI("UITab");
        if (TabGameManager.GetInstance().SpendGold(500))
            TabGameManager.GetInstance().SetCurrentHP(80);
        else
            TabGameManager.GetInstance().SetCurrentHP(10);

        Invoke("MoveToMain", 2.5f);
    }

    public void AttackMonster()
    {
        
        
        float Randx = Random.Range(-1.2f, 1.2f);
        float Randy = Random.Range(-1f, -3f);

        var particle = ObjectManager.GetInstance().CreateHitEffect();
        //ParticleSystem particle = ObjectManager.GetInstance().CreateHitEffect(); �� ����.
        //�Լ� �ȿ����� ����.
        particle.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        particle.transform.localPosition = new Vector3(0 + Randx, 0 + Randy, 0);
       

        monsterData.hp--;
        if (monsterData.hp <= 0)
        {
            
            Victory();
            BattleScene.MonsterDie();

        }
    }
    void MoveToMain()
    {
        SCenesManager.GetInstance().ChangeScene(Scene.Main);
    }
}
