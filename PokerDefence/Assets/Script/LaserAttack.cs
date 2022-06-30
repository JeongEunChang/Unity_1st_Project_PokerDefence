using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LaserAttack : MonoBehaviour
{
    public GameObject NowEnemy = null;
    public GameObject Hit; // ������ ������ ������Ʈ�� ��Ƶδ� ������Ʈ ����
    public GameObject obj; // ������ �������� �޾ƿ��� ������Ʈ ����
    public GameObject Fire;
    public GameObject tmp;
    public GameObject LaserHead;
    public ParticleSystem LaserParticle;
    public bool Delay = false;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        LaserParticle = gameObject.transform.Find("LaserTower_TURRET_L01").transform.Find("LaserFireEffect").transform.Find("Desktop").GetComponent<ParticleSystem>();
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
        if (!Delay)
        {
            if (NowEnemy == null)
            {
                NowEnemy = other.gameObject;

                LaserHead = transform.Find("LaserTower_TURRET_L01").gameObject;
                Vector3 EnemyPosition = NowEnemy.transform.position;
                //LaserHead.transform.rotation = Quaternion.LookRotation(EnemyPosition);
                LaserHead.transform.LookAt(EnemyPosition);

                LaserParticle.Play();
                //Hit = Instantiate(obj);
                //Hit.transform.position = Fire.transform.position;
                //Hit.transform.rotation = new Quaternion(Fire.transform.rotation.x, Fire.transform.rotation.y, 180, 0);
                //Hit.GetComponent<Missile>().Aim = NowEnemy;

            }

            else if (NowEnemy != null)
            {
                Debug.Log("ī����");
                float Now = (NowEnemy.transform.position - gameObject.transform.position).magnitude;
                float New = (other.transform.position - gameObject.transform.position).magnitude;

                if (New < Now)
                {
                    NowEnemy = other.gameObject;
                }

                LaserHead = transform.Find("LaserTower_TURRET_L01").gameObject;
                Vector3 EnemyPosition = NowEnemy.transform.position;
                //LaserHead.transform.rotation = Quaternion.LookRotation(EnemyPosition);
                LaserHead.transform.LookAt(EnemyPosition);

                LaserParticle.Play();
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