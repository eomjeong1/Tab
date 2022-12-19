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
        if (instance == null) // instance�� ó���� null�̰� ���� ���Ͽ��� ��������� �������� �ʴ´�.
        {
            GameObject go = new GameObject("@ObjectManager"); // @ObjectManager��� ������Ʈ�� ������ְڴ�.
            instance = go.AddComponent<ObjectManager>(); // ObjectManager��� ��ũ��Ʈ�� �� ������Ʈ�� AddComponent(�߰�)���ְڴ�.

            DontDestroyOnLoad(go); // ���� ��ȯ�� �Ǵ��� �ı����� �ʵ��� �ϰڴ�.
        }
        return instance;
    }
    #endregion

    public GameObject CreateCharacter(string characterName)
    {
        Object characterObj = Resources.Load("Sprite/" + characterName); // ���ҽ��������� ��������Ʈ - ĳ���Ͷ�� ģ���� �ε��Ұž�.
        GameObject character = (GameObject)Instantiate(characterObj); //�ҷ��� ĳ���Ͷ�� ģ���� �ν��Ͻ�ȭ �Ұž�.
        return character; // void�� return�� ��� �����ϴ�.
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

