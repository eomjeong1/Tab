using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    Button btnStart;
    // Start is called before the first frame update
    void Start()
    {
        btnStart = GetComponentInChildren<Button>(); // Button이라는 유니티UI기능 스크립트에서 가져온다는 뜻.
        btnStart.onClick.AddListener(OnClickStart); // 온클릭버튼을 눌렀을때 OnClickStart 함수를 활성화
    }

    // Update is called once per frame
    void OnClickStart()
    {
        SCenesManager.GetInstance().ChangeScene(Scene.Main); // 여기서 Scene은 아까 enum에서 만들어줬던 것.
    }
}
