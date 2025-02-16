using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerFollow : MonoBehaviour
{
    public GameObject follow;
    Vector3 setPos;
    void Start()
    {
        Camera.main.orthographicSize = 5;
    }

    // Update is called once per frame
    void Update()
    {
        setPos = follow.transform.position;
        this.transform.position = new Vector3(setPos.x, setPos.y + 2, setPos.z);

    }
}
