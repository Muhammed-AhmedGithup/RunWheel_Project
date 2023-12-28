using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    private Vector3 Offset;

    void Start()
    {
        Offset = target.position- transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {

        var newposition= new Vector3(transform.position.x,transform.position.y,target.position.z-Offset.z);
        transform.position = newposition;
        
    }
}
