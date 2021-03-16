using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleHited : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(GameObject.FindGameObjectWithTag("canvas").transform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(-3, -8));
        transform.Rotate(0, 0, 5);
        transform.GetChild(0).transform .GetComponent<Rigidbody2D>().AddForce(new Vector2(3, -8));
        transform.GetChild(0).transform. Rotate(0, 0, 5);
    }

    IEnumerator del()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
}
