using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMove : MonoBehaviour
{
    public NavMeshAgent nav;
    public GameObject Path;
    int Path_index = 0;
    int Last_Path_index = 9;

    // Start is called before the first frame update
    void Start()
    {
        Path = GameObject.Find("Path");
        Path = Path.transform.Find("Start").gameObject;
        nav = GetComponent<NavMeshAgent>();
        nav.SetDestination(Path.transform.position);
        Path = Path.transform.parent.Find("0").gameObject;
        nav.SetDestination(Path.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(Path_index < Last_Path_index)
        {
            if ((transform.position - Path.transform.position).magnitude < 1.0f)
            {
                Path_index += 1;
                Path = Path.transform.parent.Find(Path_index.ToString()).gameObject;
                nav.SetDestination(Path.transform.position);
            }
        }
    }
}
