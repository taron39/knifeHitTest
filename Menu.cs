using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Text apple, score, stage;
    public Button Bonus;
    public Image  applePrefab, CurrentKnife;
    public Text NoBonus;
    int bonusScore;
    public GameObject KnPan;

    private void Awake()
    {
        PlayerPrefs.SetInt("0", 1);
        if (PlayerPrefs.GetInt("apple") == 1500)
        {
            PlayerPrefs.SetInt("apple", 0);
            PlayerPrefs.SetInt("score", 0);
            PlayerPrefs.SetInt("stage", 0);
            for (int i = 0; i < 6; i++) PlayerPrefs.SetInt(i.ToString(), 0);
            PlayerPrefs.SetInt("0", 1);
            PlayerPrefs.SetInt("boss", 0);
        }
        
    }


    // Start is called before the first frame update
    void Start()
    {
        
        if (PlayerPrefs.GetInt("apple") < 100) PlayerPrefs.SetInt("bonus", 1);
        

        apple.text = PlayerPrefs.GetInt("apple").ToString();
        score.text = "SCORE " + PlayerPrefs.GetInt("score").ToString();
        stage.text = "STAGE " + PlayerPrefs.GetInt("stage").ToString();

        if (PlayerPrefs.GetInt("bonus") == 1)
        {
            Bonus.GetComponent<Animator>().enabled = true;
            bonusScore = Random.Range(100, 150);
            PlayerPrefs.SetInt("bonusApple", bonusScore);
        }
        else Bonus.GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
            apple.text = PlayerPrefs.GetInt("apple").ToString();
        CurrentKnife.sprite = KnPan.GetComponent<Knifes>().knifs[PlayerPrefs.GetInt("current")];
    }

    public void BonusClick()
    {
        StartCoroutine(BonusGet());
        print(PlayerPrefs.GetInt("bonusApple"));
    }
   
    public void ClickStart()
    {
        StartCoroutine(StartClick());
    }



    IEnumerator StartClick()
    {
        yield return new WaitForSeconds(.25f);
        SceneManager.LoadScene(1);
    }




    IEnumerator BonusGet()
    {
        if (PlayerPrefs.GetInt("bonus") == 1)

        {
           // PlayerPrefs.SetInt("time", date)


            for (int o = 1; o < 15; o++)
            {
                yield return new WaitForSeconds(.15f);
                Image appleBonus = Instantiate(applePrefab, GameObject.FindGameObjectWithTag("GameController").transform);
            }
            yield return new WaitForSeconds(1.5f);
            PlayerPrefs.SetInt("apple", PlayerPrefs.GetInt("apple") + PlayerPrefs.GetInt("bonusApple"));
            apple.text = PlayerPrefs.GetInt("apple").ToString();
            PlayerPrefs.SetInt("bonusApple", 0);
            Bonus.GetComponent<Animator>().enabled = false;
            Bonus.image.color = new Color(0,1,1,1);
            PlayerPrefs.SetInt("bonus", 0);
            StopCoroutine(BonusGet());
        }
        else
        {
            NoBonus.enabled = true;
            yield return new WaitForSeconds(2f);
            NoBonus.enabled = false;
            StopCoroutine(BonusGet());
        }
    }

}
