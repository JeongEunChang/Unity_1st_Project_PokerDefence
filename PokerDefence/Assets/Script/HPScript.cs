using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPScript : MonoBehaviour
{
    public int HP;
    public ParticleSystem LaserParticle;
    public int count = 0;


    // Start is called before the first frame update
    void Start()
    {
        LaserParticle = GameObject.Find("Desktop").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
            Regen.DiedMonster++;
        }
    }

    public void OnParticleCollision(GameObject other)
    {
        //Debug.Log("Ãæµ¹");
        //if (LaserParticle.isPlaying) LaserParticle.Stop();
        HPScript hp = gameObject.GetComponent<HPScript>();
        hp.DamagedHP(60);
        count++;
        LaserParticle.Stop();
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
