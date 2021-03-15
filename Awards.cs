using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Awards : MonoBehaviour
{
    Text score, stage;
    GameObject canv;
    public GameObject newKn;
    void Start()
    {
        score = transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
        stage = transform.GetChild(0).transform.GetChild(2).GetComponent<Text>();
        canv = GameObject.FindGameObjectWithTag("canvas");
        score.text =  canv.GetComponent<KnifeHi>().Score.ToString();
        stage.text = canv.GetComponent<KnifeHi>().Stage.ToString();

        if(PlayerPrefs.GetInt("boss") == 2)
        {
            PlayerPrefs.SetInt("boss", 1);
            PlayerPrefs.SetInt("current", 6);
            Instantiate(newKn, transform);
        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
