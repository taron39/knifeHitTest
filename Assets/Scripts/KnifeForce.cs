using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeForce : MonoBehaviour
{
    // Start is called before the first frame update


    bool GG = false;
    GameObject canves;
    bool isWoodHit = false;
    bool isKnifeHit = false;
    float speed;

  


    void Start()
    {
        
        Vibration.Init();

        speed = 1000;
        

        canves = GameObject.FindGameObjectWithTag("canvas");
    }




    // Update is called once per frame
    void FixedUpdate()
    {
        if (GG  )
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(1,-40);

            
            transform.Rotate(0, 0, 30);
        }


        if (canves.GetComponent<KnifeHi>().WIN)
        {
            transform.GetComponent<BoxCollider2D>().enabled = false;

            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            gameObject.transform.GetComponent<Rigidbody2D>().AddForce((transform.position - GameObject.FindGameObjectWithTag("brevno").transform.position) * speed);

            speed *= 2;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        if (collision.transform.tag == "apl1")
        {
            Destroy(collision.gameObject);
            Instantiate(canves.GetComponent<KnifeHi>().appleHit[0], GameObject.FindGameObjectWithTag("brevno").transform);
            PlayerPrefs.SetInt("apple", PlayerPrefs.GetInt("apple") + canves.GetComponent<KnifeHi>().Stage);
        }

        if (collision.transform.tag == "apl2")
        {
            Destroy(collision.gameObject);
            Instantiate(canves.GetComponent<KnifeHi>().appleHit[1], GameObject.FindGameObjectWithTag("brevno").transform);
            PlayerPrefs.SetInt("apple", PlayerPrefs.GetInt("apple") + canves.GetComponent<KnifeHi>().Stage);
        }

        if (collision.transform.tag == "apl3")
        {
            Destroy(collision.gameObject);
            Instantiate(canves.GetComponent<KnifeHi>().appleHit[2], GameObject.FindGameObjectWithTag("brevno").transform);
            PlayerPrefs.SetInt("apple", PlayerPrefs.GetInt("apple") + canves.GetComponent<KnifeHi>().Stage);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "brevno" && !isKnifeHit && canves.GetComponent<KnifeHi>().tap)
        {
            transform.tag = "knife";
            transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            transform.GetComponent<Rigidbody2D>().isKinematic = true;
            transform.parent = collision.transform.parent;
            transform.SetSiblingIndex(0);

            canves.GetComponent<KnifeHi>().tap = false;
            canves.GetComponent<KnifeHi>().Score++;
            canves.GetComponent<KnifeHi>().KnifesOnStage++;

            StartCoroutine(canves.transform.GetComponent<KnifeHi>().NEXTClick()) ;
            
            isWoodHit = true;

            if (PlayerPrefs.GetInt("vibro") == 1) Vibration.Vibrate(100);

            Instantiate(canves.GetComponent<KnifeHi>().hit, canves.GetComponent<KnifeHi>().GamePan.transform);
            canves.GetComponent<KnifeHi>().tap = false;
        }

        if (collision.transform.tag == "knife" && !isWoodHit)
        {
            GG = true;
           
            
            isKnifeHit = true;
            transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            StartCoroutine(AWARDS());
            canves.GetComponent<KnifeHi>().GG = true;

            if (PlayerPrefs.GetInt("vibro") == 1) Vibration.Vibrate(300);

            if (canves.GetComponent<KnifeHi>().Score > PlayerPrefs.GetInt("score")) PlayerPrefs.SetInt("score", canves.GetComponent<KnifeHi>().Score);
            if (canves.GetComponent<KnifeHi>().Stage > PlayerPrefs.GetInt("stage")) PlayerPrefs.SetInt("stage", canves.GetComponent<KnifeHi>().Stage);

        }
    }


   


    IEnumerator AWARDS()
    {
        GameObject.FindGameObjectWithTag("Finish").GetComponent<Animator>().enabled = true;
       
        
        yield return new WaitForSeconds(.5f);
        canves.transform.GetChild(2).gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("Finish").GetComponent<Animator>().enabled = false;

        Destroy(canves.transform.GetChild(0).gameObject);
    }
}
