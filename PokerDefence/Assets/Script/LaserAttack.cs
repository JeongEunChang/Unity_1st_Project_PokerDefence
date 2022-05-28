using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LaserAttack : MonoBehaviour
{
    public GameObject NowEnemy = null;
    public GameObject Hit; // 생성한 레이저 오브젝트를 담아두는 오브젝트 변수
    public GameObject obj; // 레이저 프리펩을 받아오는 오브젝트 변수
    public GameObject Fire;
    public bool Delay = false;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other) // 공격범위로 들어오는 적을 인식해서, 가장 가까운 적으로 타겟으로 변경
    {
        if (!Delay)
        {
            if (NowEnemy == null)
            {
                NowEnemy = other.gameObject;
                Hit = Instantiate(obj);
                //Debug.Log("0");
                //Debug.Log("1");
                Hit.transform.position = Fire.transform.position;
                //Debug.Log("2");
                //Debug.Log(Fire);
                //Hit.transform.rotation = new Quaternion(Fire.transform.rotation.x, Fire.transform.rotation.y, 180, 0);
                Hit.GetComponent<Missile>().Aim = NowEnemy;
            }

            else if (NowEnemy != null)
            {
                float Now = (NowEnemy.transform.position - gameObject.transform.position).magnitude;
                float New = (other.transform.position - gameObject.transform.position).magnitude;

                if (New < Now)
                {
                    NowEnemy = other.gameObject;
                }

                Hit = Instantiate(obj);
                Hit.transform.position = Fire.transform.position;
                //Hit.transform.rotation = new Quaternion(Fire.transform.rotation.x, Fire.transform.rotation.y, Fire.transform.rotation.z, 0);
                Hit.GetComponent<Missile>().Aim = NowEnemy;
            }

            Delay = true;
        }

        else if (Delay)
        {
            timer += Time.deltaTime;
            
            if (timer > 1.0f)
            {
                timer = 0f;
                Delay = false;
            }
        }
    }
}
