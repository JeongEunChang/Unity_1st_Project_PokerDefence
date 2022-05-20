using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonNextStage()
    {
        Invoke("ClickNextStage", 3);
    }

    public void ClickNextStage()
    {
        // 다음 스테이지로 넘어가기
    }

}
