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
        hp.DamagedHP(60);
        monster.SetInteger("HP", HP);

        if (monster.GetInteger("HP") <= 0)
        {
            IsDied = true;
            NavMeshAgent nav = GetComponent<NavMeshAgent>();
            nav.SetDestination(transform.position);
        }

        count++;
    }

    public int GetHP()
    {
        return HP;
    }

    public void DamagedHP(int Damage)
    {
        HP -= Damage;
    }
}
