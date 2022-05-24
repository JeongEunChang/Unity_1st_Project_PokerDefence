using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreateTower : MonoBehaviour
{
    public enum TowerBuildKind { None, Laser, MachineGun, Rocket, Pylon };
    public static TowerBuildKind kind = TowerBuildKind.None;

    public static GameObject SelectLocate = null;
    public GameObject Tower;
    public GameObject[] TowerHouse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray MouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(MouseRay, out hit, 1000.0f, 1 << LayerMask.NameToLayer("CanBuildGround")))
            {
                SelectLocate = hit.collider.gameObject;
            }
        }

        if (SelectLocate != null)
        {
            if (UIScript.BuildCheck == true)
            {
                GameObject Check = GameObject.Find("CanCreateTower");

                switch (kind)
                {
                    case TowerBuildKind.Laser:
                        if (ResourceScript.MinusMoney(50))
                        {
                            Tower = Instantiate(TowerHouse[0]);
                            Tower.transform.position = SelectLocate.transform.position;
                            Tower.transform.rotation = SelectLocate.transform.rotation;
                        }

                        else
                            print("돈이 부족해요ㅠㅠ");

                        kind = TowerBuildKind.None;

                        //GameObject Check = GameObject.Find("CanCreateTower");
                        Check.SetActive(false);
                        UIScript.BuildCheck = false;
                        Destroy(SelectLocate);
                        break;

                    case TowerBuildKind.MachineGun:
                        if (ResourceScript.MinusMoney(50))
                        {
                            Tower = Instantiate(TowerHouse[1]);
                            Tower.transform.position = SelectLocate.transform.position;
                            Tower.transform.rotation = SelectLocate.transform.rotation;
                        }

                        else
                            print("돈이 부족해요ㅠㅠ");

                        kind = TowerBuildKind.None;

                        //GameObject Check = GameObject.Find("CanCreateTower");
                        Check.SetActive(false);
                        UIScript.BuildCheck = false;
                        Destroy(SelectLocate);
                        break;

                    case TowerBuildKind.Rocket:
                        if (ResourceScript.MinusMoney(80))
                        {
                            Tower = Instantiate(TowerHouse[2]);
                            Tower.transform.position = SelectLocate.transform.position;
                            Tower.transform.rotation = SelectLocate.transform.rotation;
                        }

                        else
                            print("돈이 부족해요ㅠㅠ");

                        kind = TowerBuildKind.None;

                        //GameObject Check = GameObject.Find("CanCreateTower");
                        Check.SetActive(false);
                        UIScript.BuildCheck = false;
                        Destroy(SelectLocate);
                        break;

                    case TowerBuildKind.Pylon:
                        if (ResourceScript.MinusMoney(50))
                        {
                            Tower = Instantiate(TowerHouse[3]);
                            Tower.transform.position = SelectLocate.transform.position;
                            Tower.transform.rotation = SelectLocate.transform.rotation;
                        }

                        else
                            print("돈이 부족해요ㅠㅠ");

                        kind = TowerBuildKind.None;

                        //GameObject Check = GameObject.Find("CanCreateTower");
                        Check.SetActive(false); ;
                        UIScript.BuildCheck = false;
                        Destroy(SelectLocate);
                        break;


                    case TowerBuildKind.None:
                        SelectLocate = null;
                        break;
                }

            }
        }
    }
}
