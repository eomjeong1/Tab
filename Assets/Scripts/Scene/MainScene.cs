using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ObjectManager.GetInstance().CreateCharacter();

        TabUI.GetInstance().SetEventSystem();
        TabUI.GetInstance().OpenUI("UIProfile");
        TabUI.GetInstance().OpenUI("UIActionMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
