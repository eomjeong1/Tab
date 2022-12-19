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
        if (instance == null) // instance�� ó���� null�̰� ���� ���Ͽ��� ��������� �������� �ʴ´�.
        {
            GameObject go = new GameObject("@EffectManager"); // @ObjectManager��� ������Ʈ�� ������ְڴ�.
            instance = go.AddComponent<EffectManager>(); // ObjectManager��� ��ũ��Ʈ�� �� ������Ʈ�� AddComponent(�߰�)���ְڴ�.

            DontDestroyOnLoad(go); // ���� ��ȯ�� �Ǵ��� �ı����� �ʵ��� �ϰڴ�.
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
            
            //ParticleSystem particle = ObjectManager.GetInstance().CreateHitEffect(); �� ����.
            //�Լ� �ȿ����� ����.
            effect.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            effect.transform.localPosition = new Vector3(0 + Randx, 0 + Randy, 0);
        
    }

    public void ReturnEffect(ParticleSystem particle)
    {
        particle.gameObject.SetActive(false);
        effectPool.Push(particle); // ����Ʈ Ǯ�� �ϳ��� �����ϰ� �� ��
    }
}
