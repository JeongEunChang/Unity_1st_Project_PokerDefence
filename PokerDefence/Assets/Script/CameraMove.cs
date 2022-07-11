using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    GameObject camera1;
    public Vector3 tmpPosition;
    bool SpaceCamera = false;
    public static bool CanMoveCamera = false;
    // Start is called before the first frame update
    void Start()
    {
        camera1 = GameObject.Find("Main Camera");
        tmpPosition = new Vector3(12.44f, 20.56f, 23.51f);
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMoveCamera)
        {
            if (SpaceCamera == false)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    if (!(Input.GetKey(KeyCode.Space)))
                    {
                        camera1.transform.position -= new Vector3(5f, 0, 0) * Time.deltaTime;
                        RemeberPositon();
                    }
                }

                if (Input.GetKey(KeyCode.W))
                {
                    if (!(Input.GetKey(KeyCode.Space)))
                    {
                        camera1.transform.position -= new Vector3(0, 0, -5f) * Time.deltaTime;
                        RemeberPositon();
                    }
                }

                if (Input.GetKey(KeyCode.S))
                {
                    if (!(Input.GetKey(KeyCode.Space)))
                    {
                        camera1.transform.position -= new Vector3(0, 0, 5f) * Time.deltaTime;
                        RemeberPositon();
                    }
                }

                if (Input.GetKey(KeyCode.D))
                {
                    if (!(Input.GetKey(KeyCode.Space)))
                    {
                        camera1.transform.position -= new Vector3(-5f, 0, 0) * Time.deltaTime;
                        RemeberPositon();
                    }
                }
            }

            if (Input.GetKey(KeyCode.Space))
            {
                camera1.transform.position = new Vector3(5.08f, 41.3f, 10.5f);
                SpaceCamera = true;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                camera1.transform.position = tmpPosition;
                SpaceCamera = false;
            }
        }
    }

    public void RemeberPositon()
    {
        tmpPosition = camera1.transform.position;
    }
}
