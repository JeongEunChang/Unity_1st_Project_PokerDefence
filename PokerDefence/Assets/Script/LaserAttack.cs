using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LaserAttack : TowerAttack
{
    public GameObject test;
    //public GameObject NowEnemy = null;
    //public GameObject Hit; // ������ ������ ������Ʈ�� ��Ƶδ� ������Ʈ ����
    //public GameObject obj; // ������ �������� �޾ƿ��� ������Ʈ ����
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
    //    Debug.Log("�浹");
    //    //if (LaserParticle.isPlaying) LaserParticle.Stop();
    //    HPScript hp = other.GetComponent<HPScript>();
    //    hp.DamagedHP(60);
    //    LaserParticle.Stop();
    //}

    private void OnTriggerStay(Collider other) // ���ݹ����� ������ ���� �ν��ؼ�, ���� ����� ������ Ÿ������ ����
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

            else if (NowEnemy != null) // ��� ���� ���� ���� ���� �� ����� �� ó���� ����
            {
                Debug.Log("ī����");
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
