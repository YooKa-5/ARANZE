using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    public static int score;


    // Start is called before the first frame update
    void Start()
    {
        score = 20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetScore()
    {
        return score;

    }

}
