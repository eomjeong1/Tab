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

    public Monster1[] monsterDatas = new Monster1[]
        {
            new Monster1("Monster1", 10, 30, 2.5f, 300),
            new Monster1("Monster2", 15, 50, 2f, 1000)
        };

    public Monster1 GetRandomMonster()
    { 
        //                      0     ~            1
        int rand = Random.Range(0, monsterDatas.Length);

        return monsterDatas[rand];
    }
    
    public Monster1 monsterData;
    public BattleScene BattleScene;
    GameObject uiTab;

    public  EffectManager EM;

    public void Start()
    {
        BattleScene = FindObjectOfType<BattleScene>();
    }



    public void BattleStart(Monster1 monster)
    { 
        
        monsterData = monster;
        

        TabUI.GetInstance().OpenUI("UITab");
        EffectManager.GetInstance().InitEffectpool(7);
        

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
        EffectManager.GetInstance().UseEffect();
        
        Debug.Log($"MonsterName : {monsterData.monsterName} Hp : {monsterData.hp}");





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
