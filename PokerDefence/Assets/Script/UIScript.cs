using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public static bool BuildCheck = false;
    public GameObject Check;
    public static int count = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Button_X()
    {
        Invoke("Click_X_Button", 0);
    }

    public void Click_X_Button()
    {
        GameObject.Find("CardCombPrint").SetActive(false);
    }

    public void ButtonBuildTower()
    {
        Invoke("ClickBuildTower", 0);
    }

    public void ClickBuildTower()
    {
        if (Regen.StageComplate == true)
        {
            if (CardDrowScript.CanCardDrow == false)
            {
                if (count == 1)
                {
                    GameObject.Find("Main Camera").transform.position = new Vector3(12.44f, 20.56f, 23.51f);
                    CameraMove.CanMoveCamera = true;
                    count++;
                }

                if (BuildCheck == false)
                {
                    //GameObject Check = GameObject.Find("CanCreateTower");
                    Check.SetActive(true);
                    BuildCheck = true;
                    CreateTower.kind = CreateTower.TowerBuildKind.None;
                    CreateTower.SelectLocate = null;
                }

                else if (BuildCheck == true)
                {
                    //GameObject Check = GameObject.Find("CanCreateTower");
                    Check.SetActive(false); ;
                    BuildCheck = false;
                }
            }

            else if (CardDrowScript.CanCardDrow == true)
                print("카드를 모두 뽑아주세요");
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

    public void ButtonMachineGunTower()
    {
        Invoke("ClickMachineGunTower", 0);
    }


    public void ClickMachineGunTower()
    {
        CreateTower.kind = CreateTower.TowerBuildKind.MachineGun;
    }

    public void ButtonRocketTower()
    {
        Invoke("ClickRocketTower", 0);
    }


    public void ClickRocketTower()
    {
        CreateTower.kind = CreateTower.TowerBuildKind.Rocket;
    }

    public void ButtonPylonTower()
    {
        Invoke("ClickPylonTower", 0);
    }


    public void ClickPylonTower()
    {
        CreateTower.kind = CreateTower.TowerBuildKind.Pylon;
    }
}
