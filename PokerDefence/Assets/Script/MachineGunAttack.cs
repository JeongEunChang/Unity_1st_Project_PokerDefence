using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MachineGunAttack : TowerAttack
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    void Start()
    {
        AttackParticle = gameObject.transform.Find("Turret_MachineGun_L01").transform.Find("MachineGunLvl1Effect").transform.Find("Desktop").GetComponent<ParticleSystem>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Delay == true)
        {
            timer += Time.deltaTime;

            if (timer > 0.1f)
            {
                timer = 0f;
                Delay = false;
            }
        }
    }

    private void OnTriggerStay(Collider other) // ���ݹ����� ������ ���� �ν��ؼ�, ���� ����� ������ Ÿ������ ����
    {
        HPScript hp = other.GetComponent<HPScript>();

        if (!Delay && hp.IsDied == false)
        {
            if (NowEnemy == null)
            {
                NowEnemy = other.gameObject;

                if (NowEnemy.GetComponent<HPScript>().IsDied != true)
                {
                    TowerHead = transform.Find("Turret_MachineGun_L01").gameObject;
                    Vector3 EnemyPosition = NowEnemy.transform.position;
                    TowerHead.transform.LookAt(EnemyPosition);

                    AttackParticle.Play();
                    audioSource.Play();
                }
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

                else if (NowEnemy.GetComponent<HPScript>().IsDied == true)
                {
                    NowEnemy = other.gameObject;
                }

                if (NowEnemy.GetComponent<HPScript>().IsDied != true)
                {
                    TowerHead = transform.Find("Turret_MachineGun_L01").gameObject;
                    Vector3 EnemyPosition = NowEnemy.transform.position;
                    TowerHead.transform.LookAt(EnemyPosition);
                    
                    AttackParticle.Play();
                    audioSource.Play();
                }
            }

            Delay = true;
        }
    }
}