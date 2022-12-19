using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region SingletoneUI
    public static SoundManager instance = null;
    public static SoundManager GetInstance()
    {
        if (instance == null) // instance가 처음엔 null이고 다음 리턴에는 만들어져서 재실행되지 않는다.
        {
            GameObject go = new GameObject("@SoundManager"); // @ObjectManager라는 오브젝트를 만들어주겠다.
            instance = go.AddComponent<SoundManager>(); // ObjectManager라는 스크립트를 그 오브젝트에 AddComponent(추가)해주겠다.

            DontDestroyOnLoad(go); // 씬이 전환이 되더라도 파괴되지 않도록 하겠다.
        }
        return instance;
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
