using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class patrolMove : MonoBehaviour
{
    NavMeshAgent 專員;
    Transform 目的;
    [SerializeField] GameObject oriTarget;
    [SerializeField] List<Vector3> targetPos;
    // Start is called before the first frame update
    void Start()
    {
        專員 = GetComponent<NavMeshAgent>();
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
            目的 = GameObject.Find("/target").transform;
        }
        else 
        {
            int r = Random.Range(0, way.Length) % way.Length;
            目的 = way[r].transform;
        }
        專員.SetDestination(目的.position);
    }

    void Update()
    {
        if (目的 == null) {
            selectPath();
        }
        if (Vector3.Distance(this.transform.position, 目的.position) < 0.6f) {
            if (目的.name != "target")
                Destroy(目的.gameObject);
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
