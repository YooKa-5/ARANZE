using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject topobj;
    public GameObject middleobj;
    public GameObject bottomobj;
    public GameObject andy;
    private System.Random rnd = new System.Random();    // インスタンスを生成
    int intResult;
    

    void Start()
    {
        int intResult = rnd.Next(5);        // 0～4の乱数を取得
    }

    // Update is called once per frame
    void Update()
    {

        if(true)
        {
            intResult = rnd.Next(5); // 0～４
            Destroy(bottomobj);
            bottomobj = middleobj;
            topobj = middleobj;
            if (intResult == 0)
            {
                topobj = (GameObject)Resources.Load("hasiNo5");
            }
            else if (intResult == 1)
            {
                topobj = (GameObject)Resources.Load("hasiNo2");
            }
            else if (intResult == 2)
            {
                topobj = (GameObject)Resources.Load("hasiNo3");
            }
            else if (intResult == 3)
            {
                topobj = (GameObject)Resources.Load("hasiNo4");
            }
            else
            {
                topobj = (GameObject)Resources.Load("hasiNo6");
            }
        }
    }
}
