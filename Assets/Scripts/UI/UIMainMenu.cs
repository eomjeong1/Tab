using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    Button[] btnStart;
    // Start is called before the first frame update
    void Start()
    {
        btnStart = GetComponentsInChildren<Button>(); // Button이라는 유니티UI기능 스크립트에서 가져온다는 뜻.
        btnStart[0].onClick.AddListener(OnClickStart);
        btnStart[1].onClick.AddListener(OnClickStart2);// 온클릭버튼을 눌렀을때 OnClickStart 함수를 활성화
    }

    // Update is called once per frame
    void OnClickStart()
    {
        TabGameManager.GetInstance().characterIdx = 0;
        SCenesManager.GetInstance().ChangeScene(Scene.Main); // 여기서 Scene은 아까 enum에서 만들어줬던 것.
    }
    void OnClickStart2()
    {
        TabGameManager.GetInstance().characterIdx = 1;
        SCenesManager.GetInstance().ChangeScene(Scene.Main); // 여기서 Scene은 아까 enum에서 만들어줬던 것.
    }
}

