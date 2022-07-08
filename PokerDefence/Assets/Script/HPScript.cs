using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HPScript : MonoBehaviour
{
    public int HP;
    //public ParticleSystem LaserParticle;
    public int count = 0;
    public GameObject hit;
    public ParticleSystem MachineGun;
    public Vector3 HitPoint;
    public ParticleSystem NowParticle;
    public Animator monster;
    public bool IsDied = false;

    // Start is called before the first frame update
    void Start()
    {
        monster = GetComponent<Animator>();
        //NowParticle = Instantiate(MachineGun);
        //LaserParticle = GameObject.Find("Desktop").GetComponent<ParticleSystem>();
        //StartCoroutine(CountDied());
    }

    // Update is called once per frame
    void Update()
    {
        if (monster.GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            monster.SetBool("Animation_ing", false);
        }

        if (HP <= 0 && monster.GetBool("Animation_ing") == false)
        {
            Destroy(gameObject);
            Regen.DiedMonster++;
        }
    }

    public void OnParticleCollision(GameObject other)
    {
        HitPoint = gameObject.GetComponent<BoxCollider>().ClosestPointOnBounds(other.transform.position);
        NowParticle = Instantiate(MachineGun);
        NowParticle.transform.position = HitPoint;
        NowParticle.Play();
        //hit = other;
        //if (LaserParticle.isPlaying) LaserParticle.Stop();
        HPScript hp = gameObject.GetComponent<HPScript>();
        Debug.Log(other);
        if (other.name == "Laser")
        {
            hp.DamagedHP(60);
        }

        else if (other.name == "Tracer")
        {
            hp.DamagedHP(5);
        }
        //hp.DamagedHP(60);
        monster.SetInteger("HP", HP);

        if (monster.GetInteger("HP") <= 0)// 죽은 상태에서는 다시 대상이 되지 않도록 조정하기
        {
            IsDied = true;
            NavMeshAgent nav = GetComponent<NavMeshAgent>();
            nav.SetDestination(transform.position);
        }

        count++;
    }

    IEnumerator CountDied()
    {
        while (true)
        {
            if ( HP <= 0 )
            {
                Regen.DiedMonster++;
                Debug.Log("died");
                yield break;
            }

            yield return null;
        }
    }

    public int GetHP()
    {
        return HP;
    }

    public void SetHP(int data)
    {
        HP = data;
    }

    public void DamagedHP(int Damage)
    {
        HP -= Damage;
    }
}
