using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public GameObject Aim;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - Aim.transform.position).magnitude < 0.1f)
        {
            if (Aim == null)
                Destroy(gameObject);
            Destroy(gameObject);
            HPScript hp = Aim.GetComponent<HPScript>();
            hp.DamagedHP(60);
        }

        transform.position = Vector3.MoveTowards(transform.position, Aim.transform.position, 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {

    }

}
