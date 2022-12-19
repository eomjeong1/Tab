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
        if (instance == null) // instance가 처음엔 null이고 다음 리턴에는 만들어져서 재실행되지 않는다.
        {
            GameObject go = new GameObject("@TabBattleManager"); // @UIManager라는 오브젝트를 만들어주겠다.
            instance = go.AddComponent<TabBattleManager>(); // TabUI라는 스크립트를 그 오브젝트에 AddComponent(추가)해주겠다.

            DontDestroyOnLoad(go); // 씬이 전환이 되더라도 파괴되지 않도록 하겠다.
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

    // 2~3 초 시간을 가지고 몬스터가 나를 공격
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


            Debug.Log($"몬스터가 플레이어에게 공격을 했습니다. - 데미지 : {damage} 남은 체력 :{TabGameManager.GetInstance().curHP}");

        }
        Lose(); // while 문은 ~하는 동안 계속 진행되기때문에 0 이 되면 진다는 뜻.

    }
   

    void Victory()
    {
        ObjectManager.GetInstance().ImgVictory();
        Debug.Log("게임에서 승리했습니다.");
        StopCoroutine("BattleProgress");
        // StopAllCoroutines는 코루틴 전부 꺼버림 
        TabUI.GetInstance().CloseUI("UITab");

        TabGameManager.GetInstance().AddGold(monsterData.gold);

        Invoke("MoveToMain", 2.5f);
    }

    void Lose()
    {
        ObjectManager.GetInstance().ImgGameOver();
        Debug.Log("게임에서 패배했습니다.");
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
