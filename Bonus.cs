using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    Vector2 apple;

    // Start is called before the first frame update
    void Start()
    {
        apple = GameObject.FindGameObjectWithTag("apple").transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, apple, 3f*Time.deltaTime);
        if (Vector2.Distance(transform.position, apple) < .3f)
        {
            Destroy(gameObject);
            PlayerPrefs.SetInt("apple", PlayerPrefs.GetInt("apple") + 5);
            PlayerPrefs.SetInt("bonusApple", PlayerPrefs.GetInt("bonusApple") - 5);
        }
    }
}
