using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Knifes : MonoBehaviour
{
    public Color knifeColor, ramaColorOpen, ramaColorClose, OpenColor, bossColor;
    public Sprite[] knifs;
    public GameObject rama;
    public Image curKnife;



    
    private void Awake()
    {
        
        
    }
    void Start()
    {

        for (int i = 0; i < 6; i++) print(PlayerPrefs.GetInt(i.ToString()) + " knife " + i);



        //print(PlayerPrefs.GetInt("apple") + " количетво яблок" ); 
        //print(PlayerPrefs.GetInt("current") + " текущий нож(номер ножа)");
        //print(PlayerPrefs.GetInt("stage") + " количество пройднных уровней");
        //print(PlayerPrefs.GetInt("score") + " количество брошенный ножей (рекорд)");
        //print(PlayerPrefs.GetInt("bonusApple") + " накопившиеся бонусы");
        //print(PlayerPrefs.GetInt("bonus") + " наличие бонусов");





        if (PlayerPrefs.GetInt("current") == 6)
        {
           
            Destroy(GameObject.FindGameObjectWithTag("rama"));
            Instantiate(rama, GameObject.FindGameObjectWithTag("boss").transform);
            rama.GetComponent<Image>().color = ramaColorOpen;

        }

        if (PlayerPrefs.GetInt("boss") != 0) //если нож открыт
        {
            GameObject.FindGameObjectWithTag("boss").GetComponent<Image>().color = bossColor;
            GameObject.FindGameObjectWithTag("boss").transform.GetChild(0).gameObject.GetComponent<Image>().sprite = knifs[6];
            GameObject.FindGameObjectWithTag("boss").transform.GetChild(0).gameObject.GetComponent<Image>().color = knifeColor;
        }


        for (int i = 0; i < transform.childCount; i++)
            {
                if (PlayerPrefs.GetInt(i.ToString()) != 0) //если нож открыт
                {
                    transform.GetChild(i).GetComponent<Image>().color = OpenColor;
                    transform.GetChild(i).transform.GetChild(0).gameObject.GetComponent<Image>().sprite = knifs[i];
                    transform.GetChild(i).transform.GetChild(0).gameObject.GetComponent<Image>().color = knifeColor;
                }
                if (i == PlayerPrefs.GetInt("current"))
                {
                    Instantiate(rama, transform.GetChild(i).gameObject.transform);
                    rama.GetComponent<Image>().color = ramaColorOpen;
                }

            }
        
    }

    public void BossClick()
    {
        if (PlayerPrefs.GetInt("boss") != 0)
        {
            PlayerPrefs.SetInt("current", 6);
            Destroy(GameObject.FindGameObjectWithTag("rama"));
            Instantiate(rama, GameObject.FindGameObjectWithTag("boss").transform);
            rama.GetComponent<Image>().color = ramaColorOpen;

        }
    }

    public void ClickRandom()
    {
        if (PlayerPrefs.GetInt("apple") >= 250)
        {
            PlayerPrefs.SetInt("apple", PlayerPrefs.GetInt("apple") - 250);
            StartCoroutine(OpenKnife());
        }
    }



    public void knifeClick(int i)
    {
        if (PlayerPrefs.GetInt(i.ToString()) != 0)
        {
            PlayerPrefs.SetInt("current", i);
            Destroy(GameObject.FindGameObjectWithTag("rama"));
            Instantiate(rama, transform.GetChild(i).gameObject.transform);
            rama.GetComponent<Image>().color = ramaColorOpen;
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        int LOckKnifes = 0;

        for (int e = 0; e < transform.childCount; e++)
        {
            if (PlayerPrefs.GetInt(e.ToString()) == 0) LOckKnifes++;
        }

        if (LOckKnifes == 0)
        {
            GameObject.FindGameObjectWithTag("BUY").GetComponent<Button>().enabled = false;
            GameObject.FindGameObjectWithTag("BUY").GetComponent<Image>().color = ramaColorClose;
        }


        curKnife.sprite = knifs[PlayerPrefs.GetInt("current")];



  }


    IEnumerator OpenKnife()
    {
        int LOckKnifes =0 ;

        for (int e = 0; e<transform.childCount;e++)
        {
            if (PlayerPrefs.GetInt(e.ToString()) == 0) LOckKnifes++;
        }

        if (LOckKnifes > 1)
        {


            int i = Random.Range(0, 10);
            float t = .5f;
            int g = 0;

            int r = Random.Range(0, 10);



            while (i != r)
            {
                for (int count = 0; count < transform.childCount; count++)
                {
                    if (PlayerPrefs.GetInt(count.ToString()) == 0)
                    {
                        GameObject ram = Instantiate(rama, transform.GetChild(count).transform);
                        ram.transform.GetComponent<Image>().color = ramaColorClose;


                        yield return new WaitForSeconds(t);

                        r = Random.Range(0, 10);
                        if (i == r)
                        {
                            g = count;
                            Destroy(ram);
                            break;
                        }

                        if (t > .2f) t -= t / 5;

                        Destroy(ram);

                    }

                }

            }

           
            transform.GetChild(g).GetComponent<Image>().color = OpenColor;
            transform.GetChild(g).transform.GetChild(0).GetComponent<Image>().sprite = knifs[g];
            transform.GetChild(g).transform.GetChild(0).GetComponent<Image>().color = knifeColor;
                        



            PlayerPrefs.SetInt((g).ToString(), 1);
            PlayerPrefs.SetInt("current", g);

           for (int a = 0; a<3;a++)
            {
                if (GameObject.FindGameObjectWithTag("rama"))  Destroy(GameObject.FindGameObjectWithTag("rama"));
            }
          

            Instantiate(rama, transform.GetChild(g).gameObject.transform);
            rama.GetComponent<Image>().color = ramaColorOpen;
            
            StopCoroutine(OpenKnife());

        }



        if (LOckKnifes==1)
        {
            for (int k=0;k<transform.childCount;k++)
            {
                if (PlayerPrefs.GetInt(k.ToString()) == 0)
                {
                        transform.GetChild(k).GetComponent<Image>().color = OpenColor;
                        transform.GetChild(k).transform.GetChild(0).GetComponent<Image>().sprite = knifs[k];
                        transform.GetChild(k).transform.GetChild(0).GetComponent<Image>().color = knifeColor;
                        
                    


                    PlayerPrefs.SetInt((k).ToString(), 1);
                    PlayerPrefs.SetInt("current", k);
                    for (int a = 0; a < 3; a++)
                    {
                        if (GameObject.FindGameObjectWithTag("rama")) Destroy(GameObject.FindGameObjectWithTag("rama"));
                    }

                    Instantiate(rama, transform.GetChild(k).gameObject.transform);
                    rama.GetComponent<Image>().color = ramaColorOpen;

                    break;
                    StopCoroutine(OpenKnife());
                }
            }
        }
        


    }

}
