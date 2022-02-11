using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public GameObject ps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "lowerBound")
        {
            Instantiate(ps, collision.contacts[0].point, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if (collision.transform.tag == "Player")
        {
            PlayerController.pc.hit = true;
        }
    }
}
