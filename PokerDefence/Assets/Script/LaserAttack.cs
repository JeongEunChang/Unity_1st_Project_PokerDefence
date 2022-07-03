using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LaserAttack : TowerAttack
{
    public GameObject test;
    //public GameObject NowEnemy = null;
    //public GameObject Hit; // 생성한 레이저 오브젝트를 담아두는 오브젝트 변수
    //public GameObject obj; // 레이저 프리펩을 받아오는 오브젝트 변수
    //public GameObject Fire;
    //public GameObject tmp;
    //public GameObject LaserHead;
    //public ParticleSystem LaserParticle;
    //public bool Delay = false;
    //float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        AttackParticle = gameObject.transform.Find("LaserTower_TURRET_L01").transform.Find("LaserFireEffect").transform.Find("Desktop").GetComponent<ParticleSystem>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Delay == true)
        {
            timer += Time.deltaTime;

            if (timer > 1.0f)
            {
                timer = 0f;
                Delay = false;
            }
        }
    }

    //private void OnParticleCollision(GameObject other)
    //{
    //    Debug.Log("충돌");
    //    //if (LaserParticle.isPlaying) LaserParticle.Stop();
    //    HPScript hp = other.GetComponent<HPScript>();
    //    hp.DamagedHP(60);
    //    LaserParticle.Stop();
    //}

    private void OnTriggerStay(Collider other) // 공격범위로 들어오는 적을 인식해서, 가장 가까운 적으로 타겟으로 변경
    {
        HPScript hp = other.GetComponent<HPScript>();

        if (!Delay && hp.IsDied == false)
        {
            if (NowEnemy == null)
            {
                NowEnemy = other.gameObject;

                TowerHead = transform.Find("LaserTower_TURRET_L01").gameObject;
                Vector3 EnemyPosition = NowEnemy.transform.position;
                //LaserHead.transform.rotation = Quaternion.LookRotation(EnemyPosition);
                TowerHead.transform.LookAt(EnemyPosition);

                AttackParticle.Play();
                //Hit = Instantiate(obj);
                //Hit.transform.position = Fire.transform.position;
                //Hit.transform.rotation = new Quaternion(Fire.transform.rotation.x, Fire.transform.rotation.y, 180, 0);
                //Hit.GetComponent<Missile>().Aim = NowEnemy;

            }

            else if (NowEnemy != null) // 계산 도중 적이 제거 됐을 때 경우의 수 처리해 놓기
            {
                Debug.Log("카운팅");
                float Now = (NowEnemy.transform.position - gameObject.transform.position).magnitude;
                float New = (other.transform.position - gameObject.transform.position).magnitude;

                if (New < Now)
                {
                    NowEnemy = other.gameObject;
                }

                else if (NowEnemy.GetComponent<HPScript>().IsDied == true)
                {
                    NowEnemy = other.gameObject;
                }

                TowerHead = transform.Find("LaserTower_TURRET_L01").gameObject;
                Vector3 EnemyPosition = NowEnemy.transform.position;
                //LaserHead.transform.rotation = Quaternion.LookRotation(EnemyPosition);
                TowerHead.transform.LookAt(EnemyPosition);

                AttackParticle.Play();
                //Hit = Instantiate(obj);
                //Hit.transform.position = Fire.transform.position;
                //Hit.GetComponent<Missile>().Aim = NowEnemy;

            }

            Delay = true;
        }

        //else if (Delay)
        //{
        //    timer += Time.deltaTime;
            
        //    if (timer > 1.0f)
        //    {
        //        timer = 0f;
        //        Delay = false;
        //    }
        //}
    }
}
