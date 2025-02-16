using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class patrolMove : MonoBehaviour
{
    NavMeshAgent �M��;
    Transform �ت�;
    [SerializeField] GameObject oriTarget;
    [SerializeField] List<Vector3> targetPos;
    // Start is called before the first frame update
    void Start()
    {
        �M�� = GetComponent<NavMeshAgent>();
        GameObject[] allTarget = GameObject.FindGameObjectsWithTag("wayPoint");        
        selectPath();
        
        if (oriTarget == null) return;
        foreach(GameObject tt in allTarget)
        {
            targetPos.Add (tt.transform.position);            
        }
        
    }
    void selectPath() 
    {
        GameObject[] way = GameObject.FindGameObjectsWithTag("wayPoint");        

        if (way.Length == 0)
        {
            �ت� = GameObject.Find("/target").transform;
        }
        else 
        {
            int r = Random.Range(0, way.Length) % way.Length;
            �ت� = way[r].transform;
        }
        �M��.SetDestination(�ت�.position);
    }

    void Update()
    {
        if (�ت� == null) {
            selectPath();
        }
        if (Vector3.Distance(this.transform.position, �ت�.position) < 0.6f) {
            if (�ت�.name != "target")
                Destroy(�ت�.gameObject);
            else 
            {
                //reset game
                foreach (Vector3 tt in targetPos)
                {
                    Instantiate(oriTarget, tt, Quaternion.identity);
                }
                selectPath();
            }
        }
    }
}
