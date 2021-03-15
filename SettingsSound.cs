using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingsSound : MonoBehaviour
{
    private void Awake()
    {
        
    }

    private void FixedUpdate()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            gameObject.transform.GetChild(1).GetComponent<Text>().text = "ON";
            gameObject.transform.GetChild(1).GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
            PlayerPrefs.SetInt("sound", 1);
            gameObject.GetComponent<Animator>().SetBool("ON", true);
        }
        else if (PlayerPrefs.GetInt("sound") == 0)
        {
            gameObject.transform.GetChild(1).GetComponent<Text>().text = "OFF";
            gameObject.transform.GetChild(1).GetComponent<Text>().alignment = TextAnchor.MiddleRight;
            PlayerPrefs.SetInt("sound", 0);
            gameObject.GetComponent<Animator>().SetBool("ON", false);
        }
    }



    public void Click()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            gameObject.transform.GetChild(1).GetComponent<Text>().text = "OFF";
            gameObject.transform.GetChild(1).GetComponent<Text>().alignment = TextAnchor.MiddleRight;
            PlayerPrefs.SetInt("sound", 0);
            gameObject.GetComponent<Animator>().SetBool("ON", false);
            
            
        }
        else if (PlayerPrefs.GetInt("sound") == 0)
        {
            gameObject.transform.GetChild(1).GetComponent<Text>().text = "ON";
            gameObject.transform.GetChild(1).GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
            PlayerPrefs.SetInt("sound", 1);
            gameObject.GetComponent<Animator>().SetBool("ON", true);
        }


    }
}
