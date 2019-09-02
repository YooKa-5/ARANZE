using UnityEngine;
using System.Collections;
using System.Threading.Tasks;
using System;

public class ClickScript : MonoBehaviour
{
    GameObject hoge;
    /// ボタンをクリックした時の処理
    public void OnClick()
    {
        Debug.Log("Button click!");
        hoge = GameObject.Find("Controller");
        GameObject.Destroy(hoge);
        hoge = GameObject.Find("set_canvas");
        GameObject.Destroy(hoge);

        //５秒待つ

        Instantiate((GameObject)Resources.Load("moveScript"));
        //Instantiate((GameObject)Resources.Load("joystickのcanvas")); だしな、てめーのjoystick!!
    }
}

