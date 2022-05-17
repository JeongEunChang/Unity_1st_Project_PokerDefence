using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMove : MonoBehaviour
{
    public NavMeshAgent nav;
    public GameObject Path;

    // Start is called before the first frame update
    void Start()
    {
        Path = gameObject.transform.Find("Path").gameObject;
        Path = Path.gameObject.transform.Find("Start").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
