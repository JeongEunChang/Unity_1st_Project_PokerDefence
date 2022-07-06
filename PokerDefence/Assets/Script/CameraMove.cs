using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    GameObject camera1;
    public Vector3 tmpPosition;
    // Start is called before the first frame update
    void Start()
    {
        camera1 = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (CardDrowScript.CanCardDrow == false || Regen.StageComplate == false)
        {
            if (Input.GetKey(KeyCode.A))
            {
                camera1.transform.position -= new Vector3(5f, 0, 0) * Time.deltaTime;
                RemeberPositon();
            }

            if (Input.GetKey(KeyCode.W))
            {
                //camera1.transform.position+= transform.forward * Time.deltaTime;
                camera1.transform.position -= new Vector3(0, 0, -5f) * Time.deltaTime;
                RemeberPositon();
            }

            if (Input.GetKey(KeyCode.S))
            {
                //camera1.transform.position -= transform.forward * Time.deltaTime;
                camera1.transform.position -= new Vector3(0, 0, 5f) * Time.deltaTime;
                RemeberPositon();
            }

            if (Input.GetKey(KeyCode.D))
            {
                //camera1.transform.position += transform.right * Time.deltaTime;
                camera1.transform.position -= new Vector3(-5f, 0, 0) * Time.deltaTime;
                RemeberPositon();
            }

            if (Input.GetKey(KeyCode.Space))
            {
                camera1.transform.position = new Vector3(5.08f, 41.3f, 10.5f);
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                camera1.transform.position = tmpPosition;
            }
        }
    }

    public void RemeberPositon()
    {
        tmpPosition = camera1.transform.position;
    }
}
