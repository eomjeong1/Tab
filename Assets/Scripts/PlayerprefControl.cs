using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerprefControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // PlayerPrefs.SetInt("testKey", 2); // 테스트 키라는 이름으로 숫자 2를 저장해놓는 것
        Debug.Log(PlayerPrefs.HasKey("testKey"));
        Debug.Log(PlayerPrefs.GetInt("testKey"));
    }

    // key        testkey
    // value         2

    // Update is called once per frame
    void Update()
    {
        
    }
}
