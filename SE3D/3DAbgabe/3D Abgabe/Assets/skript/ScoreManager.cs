using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;        // The player's score


    Text text;                      //  Text component score


    void Awake()
    {
     
        text = GetComponent<Text>();

        // Reset score.
        score = 0;
    }


    void Update()
    {

        text.text = "Score: " + ScoreStatic.ReturnPoints().ToString();
       
    }
  



}