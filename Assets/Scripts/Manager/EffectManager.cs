using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    Stack<ParticleSystem> effectPool = new Stack<ParticleSystem>();

    #region SingletoneUI
    public static EffectManager instance = null;
    public static EffectManager GetInstance()
    {
        if (instance == null) // instance가 처음엔 null이고 다음 리턴에는 만들어져서 재실행되지 않는다.
        {
            GameObject go = new GameObject("@EffectManager"); // @ObjectManager라는 오브젝트를 만들어주겠다.
            instance = go.AddComponent<EffectManager>(); // ObjectManager라는 스크립트를 그 오브젝트에 AddComponent(추가)해주겠다.

            DontDestroyOnLoad(go); // 씬이 전환이 되더라도 파괴되지 않도록 하겠다.
        }
        return instance;
    }
    #endregion

    public void InitEffectpool(int size)
    {
        for (int i = 0; i < size; i++)
        {
            var effect = ObjectManager.GetInstance().CreateHitEffect();
            effect.gameObject.SetActive(false);
            effectPool.Push(effect);
        }
    }

    public void ReleaseEffectpool()
    {
        effectPool.Clear();
    }

    public void UseEffect()
    {
        ParticleSystem effect = null;

        if (effectPool.Count > 0)
        {
            effect = effectPool.Pop();
            effect.gameObject.SetActive(true);
        }
        else
        {
            effect = ObjectManager.GetInstance().CreateHitEffect();
        }

            effect.Play();

            float Randx = Random.Range(-1.2f, 1.2f);
            float Randy = Random.Range(-1f, -3f);
            
            //ParticleSystem particle = ObjectManager.GetInstance().CreateHitEffect(); 와 같음.
            //함수 안에서만 가능.
            effect.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            effect.transform.localPosition = new Vector3(0 + Randx, 0 + Randy, 0);
        
    }

    public void ReturnEffect(ParticleSystem particle)
    {
        particle.gameObject.SetActive(false);
        effectPool.Push(particle); // 이펙트 풀에 하나씩 저장하게 될 것
    }
}
