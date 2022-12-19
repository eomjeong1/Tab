using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        var player = TabGameManager.GetInstance().SetPlayer(TabGameManager.GetInstance().characterIdx);

        GameObject go = ObjectManager.GetInstance().CreateCharacter(player.characterName);
        go.transform.localScale = new Vector3(2, 2, 2); // 스케일을 2만큼씩 키우기
        go.transform.localPosition = new Vector3(0, 2.5f, 0); // 포지션을 y축으로 2.5이동시킴.

        TabUI.GetInstance().SetEventSystem();
        TabUI.GetInstance().OpenUI("UIProfile");
        TabUI.GetInstance().OpenUI("UIActionMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
