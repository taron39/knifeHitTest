using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GGBrevno : MonoBehaviour
{
    float speed = 40;
    void Start()
    {
        StartCoroutine(delete());
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < 6; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<Rigidbody2D>().AddForce((transform.GetChild(i).gameObject.transform.position - transform.position)*speed);
            transform.GetChild(i).gameObject.GetComponent<Rigidbody2D>().gravityScale = .3f;
            transform.GetChild(i).transform.Rotate(0, 0, 1);

        }
        speed *= 1.5f;
    }
    IEnumerator delete()
    {
        yield return new WaitForSeconds(.9f);
        Destroy(gameObject);
    }
}
