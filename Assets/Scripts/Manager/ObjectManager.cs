using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectManager : MonoBehaviour
{
    
    #region SingletoneUI
    public static ObjectManager instance = null;
    public static ObjectManager GetInstance()
    {
        if (instance == null) // instance가 처음엔 null이고 다음 리턴에는 만들어져서 재실행되지 않는다.
        {
            GameObject go = new GameObject("@ObjectManager"); // @ObjectManager라는 오브젝트를 만들어주겠다.
            instance = go.AddComponent<ObjectManager>(); // ObjectManager라는 스크립트를 그 오브젝트에 AddComponent(추가)해주겠다.

            DontDestroyOnLoad(go); // 씬이 전환이 되더라도 파괴되지 않도록 하겠다.
        }
        return instance;
    }
    #endregion

    public GameObject CreateCharacter(string characterName)
    {
        Object characterObj = Resources.Load("Sprite/" + characterName); // 리소스폴더에서 스프라이트 - 캐릭터라는 친구를 로드할거야.
        GameObject character = (GameObject)Instantiate(characterObj); //불러온 캐릭터라는 친구를 인스턴스화 할거야.
        return character; // void만 return이 없어도 가능하다.
    }

    public GameObject CreateMonster(string MonsterName)
    {
        Object MonsterObj = Resources.Load("Sprite/"+ MonsterName);
        GameObject monster = (GameObject)Instantiate(MonsterObj);

        return monster;
    }
    public GameObject CreateMDie()
    {
        Object MonsterObj = Resources.Load("Sprite/MDie");
        GameObject monster = (GameObject)Instantiate(MonsterObj);

        return monster;
    }

    public ParticleSystem CreateHitEffect()
    {
        
        Object EffectObj = Resources.Load("Effect/Hit2");
        GameObject effect = (GameObject)Instantiate(EffectObj);
        
        

        return effect.GetComponent<ParticleSystem>();
    }
    public ParticleSystem CreateHealEffect()
    {

        Object EffectObj = Resources.Load("Effect/Heal");
        GameObject effect = (GameObject)Instantiate(EffectObj);



        return effect.GetComponent<ParticleSystem>();
    }

    public GameObject ImgVictory()
    {
        Object SCImg = Resources.Load("Sprite/SC");
        GameObject SC = (GameObject)Instantiate(SCImg);

        return SC;
    }
    public GameObject ImgTimeOver()
    {
        Object TOImg = Resources.Load("Sprite/TO");
        GameObject TO = (GameObject)Instantiate(TOImg);

        return TO;
    }

    public GameObject ImgGameOver()
    {
        Object GOImg = Resources.Load("Sprite/GO");
        GameObject GO = (GameObject)Instantiate(GOImg);

        return GO;
    }
}

