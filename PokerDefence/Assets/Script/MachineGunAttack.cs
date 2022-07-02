using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MachineGunAttack : TowerAttack
{
    void Start()
    {
        AttackParticle = gameObject.transform.Find("Turret_MachineGun_L01").transform.Find("MachineGunLvl1Effect").transform.Find("Desktop").GetComponent<ParticleSystem>();
    }

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

    private void OnTriggerStay(Collider other) // ���ݹ����� ������ ���� �ν��ؼ�, ���� ����� ������ Ÿ������ ����
    {
        HPScript hp = other.GetComponent<HPScript>();

        if (!Delay && hp.IsDied == false)
        {
            if (NowEnemy == null)
            {
                NowEnemy = other.gameObject;

                TowerHead = transform.Find("Turret_MachineGun_L01").gameObject;
                Vector3 EnemyPosition = NowEnemy.transform.position;
                TowerHead.transform.LookAt(EnemyPosition);

                AttackParticle.Play();
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

                TowerHead = transform.Find("Turret_MachineGun_L01").gameObject;
                Vector3 EnemyPosition = NowEnemy.transform.position;
                TowerHead.transform.LookAt(EnemyPosition);

                AttackParticle.Play();

            }

            Delay = true;
        }
    }
}