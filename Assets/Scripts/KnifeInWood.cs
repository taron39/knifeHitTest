using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeInWood : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    float speed = 1000;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("canvas").GetComponent<KnifeHi>().WIN)
        {
            if (transform.parent.tag == "Respawn")
            {
                if(transform.GetComponent<Animator>().enabled)
                transform.GetComponent<Animator>().enabled = false;
            }
            transform.GetComponent<BoxCollider2D>().enabled = false;

            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            gameObject.transform.GetComponent<Rigidbody2D>().AddForce((transform.position - GameObject.FindGameObjectWithTag("brevno").transform.position) * speed);

            speed *= 2;
        }
    }
}
