using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KnifeHi : MonoBehaviour
{
    public Text apple, score, stage;
    public Image KnifeUI;
    public GameObject Knfe, Brevno, stagePanel,knifePanel,GamePan, BrevnoWin, BrevnoWin1,StagePan;
    public int[] KnifesOnLevel = new int[250];
  public  int Stage = 1;
   public int Score = 0;
    public bool tap = false;
   public bool next = true;
    public float ForceSpeed;
   public Sprite[] currentKN;
    public int KnifesOnStage;
    public ParticleSystem hit;

    public GameObject BossBrevno,BrevnoSimple, respown;

    GameObject res, KnPan;
    public GameObject[] applePrefab;
    public GameObject[] appleHit;
    public GameObject[] KnifeInWood;

   public GameObject KnW;
    public int Rot;

    void Start()
    {
        res =  Instantiate(respown, GamePan.transform);
        Brevno = Instantiate(BrevnoSimple, res.transform);
        KnPan = Instantiate(knifePanel, transform.GetChild(1).gameObject.transform);



        Vibration.Init();
       
        int n = KnifesOnLevel[Stage];
        for (int i = 0; i<n; i++)
        {
           Image k1 =  Instantiate(KnifeUI, KnPan.transform);
        }


       GameObject kn =  Instantiate(Knfe, GamePan.transform);
        kn.transform.SetAsFirstSibling();
        kn.transform.GetComponent<Image>().sprite = currentKN[PlayerPrefs.GetInt("current")];


        Stage = 1;





    }

 
    void FixedUpdate()
    {
        
        


        apple.text = PlayerPrefs.GetInt("apple").ToString();
        stage.text ="STAGE " + Stage;
        score.text = Score.ToString();


        if (tap && GameObject.FindGameObjectWithTag("next") != null)

        {
            GameObject.FindGameObjectWithTag("next").transform.GetComponent<Animator>().enabled = false;

            GameObject.FindGameObjectWithTag("next").transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, ForceSpeed), ForceMode2D.Impulse);
        }


        if ((KnifesOnStage) != 0 && KnifesOnStage <= KnifesOnLevel[Stage] && !WIN && KnPan != null ) 
            KnPan.transform.GetChild(KnifesOnLevel[Stage] - (KnifesOnLevel[Stage] - KnifesOnStage) -1).transform.GetComponent<Image>().color = new Color(0, 0, 0, 1);

        if (KnifesOnStage == KnifesOnLevel[Stage])
        {


            WIN = true;

            StartCoroutine(NEXtBrevno());

        }
        else WIN = false;

    }

    public bool WIN = false;
    public bool GG = false;
    public void Restart( int i)
    {
        SceneManager.LoadScene(i);
    }

    public void taptap()
    {

        next = false;
            tap = true;
           
            
            
    }
 int colorr = 0;
    IEnumerator NEXtBrevno()
    {
        next = false;
        tap = false;
        colorr++;
        if (colorr == 5)
        {
            colorr = 0;
            if (PlayerPrefs.GetInt("boss") == 0)
            {
                PlayerPrefs.SetInt("boss", 2);
            }
        }

        if (PlayerPrefs.GetInt("vibro") == 1) Vibration.Vibrate(200);

        Brevno.transform.GetComponent<Image>().enabled = false;
        Brevno.transform.GetComponentInParent<Rotate>().enabled = false;
        if (GameObject.FindGameObjectWithTag("breWin") == null && colorr != 4 && (colorr == 2 || colorr == 4)) Instantiate(BrevnoWin1, Brevno.transform);
        if (GameObject.FindGameObjectWithTag("breWin") == null && colorr != 4 && (colorr == 1 || colorr == 3)) Instantiate(BrevnoWin, Brevno.transform);

        KnifesOnStage = 0;
        Stage++;


        


          //  StagePan.transform.GetChild(colorr).gameObject.GetComponent<Image>().color = StagePan.transform.GetChild(0).gameObject.GetComponent<Image>().color;
        for (int i = 0; i < 5; i++)
        {
            if (i<=colorr)
            StagePan.transform.GetChild(i).gameObject.GetComponent<Image>().color = StagePan.transform.GetChild(0).gameObject.GetComponent<Image>().color;
            if (i > colorr ) StagePan.transform.GetChild(i).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }

        
        if(GameObject.FindGameObjectWithTag("apl1") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("apl1"));
            Instantiate(appleHit[0], Brevno.transform);
        }
        if (GameObject.FindGameObjectWithTag("apl2") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("apl2"));
            Instantiate(appleHit[1], Brevno.transform);
        }
        if (GameObject.FindGameObjectWithTag("apl3") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("apl3"));
            Instantiate(appleHit[2], Brevno.transform);
        }


        


        Destroy(KnPan);

        yield return new WaitForSeconds(.5f);


        WIN = false;
        GG = false;
       

        Destroy(res);
        KnPan = Instantiate(knifePanel, transform.GetChild(1).gameObject.transform);


        int n = KnifesOnLevel[Stage];
        for (int i = 0; i < n; i++)
        {
            Image k1 = Instantiate(KnifeUI, KnPan.transform);
        }


        

        if (colorr == 1 || colorr==3)
        {
            Rot = Random.Range(0, 100);
            res = Instantiate(respown, GamePan.transform);
            Brevno = Instantiate(BrevnoSimple, res.transform);
            Brevno.GetComponent<Image>().sprite = br2sprite;




            int rnd = Random.Range(0, 100);
            for (int i= 0;i<applePrefab.Length;i++)
            {
                int a = Random.Range(0, 100);
                if (a<=rnd) Instantiate(applePrefab[i], Brevno.transform);
            }


            if (rnd <= 20)
            {
                 KnW = Instantiate(KnifeInWood[0], res.transform);
                KnW.transform.SetSiblingIndex(0);
            }

            if (rnd <= 40 && rnd > 20)
            {
                 KnW = Instantiate(KnifeInWood[1], res.transform);
                KnW.transform.SetSiblingIndex(0);
            }

            if (rnd <= 60 && rnd > 40)
            {
                 KnW = Instantiate(KnifeInWood[2], res.transform);
                KnW.transform.SetSiblingIndex(0);
            }

            if (rnd <= 80 && rnd > 60)
            {
                 KnW = Instantiate(KnifeInWood[3], res.transform);
                KnW.transform.SetSiblingIndex(0);
            }

            if (rnd > 80)
            {
                 KnW = Instantiate(KnifeInWood[4], res.transform);
                KnW.transform.SetSiblingIndex(0);
            }

        }
        if (colorr == 0 || colorr == 2)
        {
            Rot = Random.Range(0, 100);
            res = Instantiate(respown, GamePan.transform);
            Brevno = Instantiate(BrevnoSimple, res.transform);
            Brevno.GetComponent<Image>().sprite = br1sprite;

            int rnd = Random.Range(0, 100);
            for (int i = 0; i < applePrefab.Length; i++)
            {
                int a = Random.Range(0, 100);
                if (a <= rnd) Instantiate(applePrefab[i], Brevno.transform);
            }

            if (rnd <= 20)
            {
                 KnW = Instantiate(KnifeInWood[0], res.transform);
                KnW.transform.SetSiblingIndex(0);
            }

            if (rnd <= 40 && rnd > 20)
            {
                 KnW = Instantiate(KnifeInWood[1], res.transform);
                KnW.transform.SetSiblingIndex(0);
            }

            if (rnd <= 60 && rnd > 40)
            {
                 KnW = Instantiate(KnifeInWood[2], res.transform);
                KnW.transform.SetSiblingIndex(0);
            }

            if (rnd <= 80 && rnd > 60)
            {
                 KnW = Instantiate(KnifeInWood[3], res.transform);
                KnW.transform.SetSiblingIndex(0);
            }

            if (rnd > 80)
            {
                 KnW = Instantiate(KnifeInWood[4], res.transform);
                KnW.transform.SetSiblingIndex(0);
            }
        }
        if (colorr == 4)
        {
            Rot = 35;
            Instantiate(BossStart, transform.GetChild(1).transform);
            yield return new WaitForSeconds(.6f);
            res = Instantiate(respown, GamePan.transform);
            Brevno = Instantiate(BossBrevno, res.transform);
            
        }
        Brevno.transform.GetComponent<Animator>().Rebind();
        Brevno.transform.GetComponent<Image>().enabled = true ;
        Brevno.transform.parent.GetComponent<Rotate>().enabled = true;


        yield return new WaitForSeconds(.5f);
        if (GameObject.FindGameObjectWithTag("next") == null)
        {
            GameObject kn = Instantiate(Knfe, GamePan.transform);
            kn.transform.SetSiblingIndex(0);
            kn.transform.GetComponent<Image>().sprite = currentKN[PlayerPrefs.GetInt("current")];
        }
       

    }
    public int appleChanse;
    public GameObject BossStart;
    public Sprite br1sprite, br2sprite, boss;

    public IEnumerator NEXTClick()
    {
        
        yield return new WaitForSeconds(TimeForNextCick);
        if (KnPan != null && KnifesOnStage < KnifesOnLevel[Stage])
        {
            
                GameObject kn = Instantiate(Knfe, GamePan.transform);
                kn.transform.SetSiblingIndex(0);
                kn.transform.GetComponent<Image>().sprite = currentKN[PlayerPrefs.GetInt("current")];
            
        }

        StopCoroutine(NEXTClick());
    }


    public float TimeForNextCick;
    


}
