using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 100 * Time.deltaTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player") {
            FindObjectOfType<coin_sound>().PlaySource();
            Player_Manager.numberofcoins += 1;
            Destroy(gameObject);
        }
    }
}
