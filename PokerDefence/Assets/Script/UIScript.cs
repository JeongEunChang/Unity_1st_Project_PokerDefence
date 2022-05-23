using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public static bool BuildCheck = false;
    public GameObject Check;

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


    public void ButtonBuildTower()
    {
        Invoke("ClickBuildTower", 0);
    }

    public void ClickBuildTower()
    {
        if (BuildCheck == false)
        {
            //GameObject Check = GameObject.Find("CanCreateTower");
            Check.SetActive(true);
            BuildCheck = true;
        }

        else if (BuildCheck == true)
        {
            //GameObject Check = GameObject.Find("CanCreateTower");
            Check.SetActive(false); ;
            BuildCheck = false;
        }

    }

    public void ButtonLaserTower()
    {
        Invoke("ClickLaserTower", 0);
    }


    public void ClickLaserTower()
    {
        CreateTower.kind = CreateTower.TowerBuildKind.Laser;
    }
}
