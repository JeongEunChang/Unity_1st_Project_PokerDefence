using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunAttack : MonoBehaviour
{
    public static GameObject Aim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - Aim.transform.position).magnitude < 0.1f)
        {
            Destroy(gameObject);
        }

        transform.position = Vector3.MoveTowards(transform.position, Aim.transform.position, 0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

}
