using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanMove : MonoBehaviour
{

    protected Joystick joystick;
    protected JoyButton joybutton;

    public bool isJump;
    public bool isDoubleJump;

    public float lastjoystickHori = 0;
    public float lastjoystickVer = 0;

    //Rigidbodyを変数に入れる
    Rigidbody rb;
    //移動スピード
    public float speed = 3f;
    public float acceleration = 0.2f;

    //ジャンプ力
    public float thrust = 30;
    //2段ジャンプ力
    public float doubleThrust = 50;
    //Animatorを入れる変数
    private Animator animator;
    //ユニティちゃんの位置を入れる
    Vector3 playerPos;
    //地面に接触しているか否か
    bool ground;



    void Start()
    {
        //Rigidbodyを取得
        rb = GetComponent<Rigidbody>();
        //ユニティちゃんのAnimatorにアクセスする
        animator = GetComponent<Animator>();
        //ユニティちゃんの現在より少し前の位置を保存
        playerPos = transform.position;


        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<JoyButton>();
    }

    void Update()
    {
        //地面に接触していると作動する
        if (ground)
        {


            //ユニティちゃんの最新の位置から少し前の位置を引いて方向を割り出す
            Vector3 direction = transform.position - playerPos;

            //移動距離が少しでもあった場合に方向転換
            if (direction.magnitude > 0.001f)
            {
                //directionのX軸とZ軸の方向を向かせる
                transform.rotation = Quaternion.LookRotation(new Vector3
                    (direction.x, 0, direction.z));
                //走るアニメーションを再生
                animator.SetBool("Running", true);
            }
            else
            {
                //ベクトルの長さがない＝移動していない時は走るアニメーションはオフ
                animator.SetBool("Running", false);
            }

            //ユニティちゃんの位置を更新する
            playerPos = transform.position;


        }


        var rigidbody = GetComponent<Rigidbody>();
        if (joystick.Horizontal + joystick.Vertical == 0)
        {
            rigidbody.velocity = new Vector3((speed
               * lastjoystickHori * Time.time * acceleration), rigidbody.velocity.y, speed * lastjoystickVer * Time.time * acceleration);

        }
        else if (joystick.Horizontal * joystick.Horizontal + joystick.Vertical * joystick.Vertical < 0.80)
        {

            rigidbody.velocity = new Vector3((speed * joystick.Horizontal * Time.time * acceleration), rigidbody.velocity.y, speed * joystick.Vertical * Time.time * acceleration);


        }
        else
        {
            lastjoystickHori = joystick.Horizontal;
            lastjoystickVer = joystick.Vertical;
            rigidbody.velocity = new Vector3((speed * joystick.Horizontal * Time.time * acceleration), rigidbody.velocity.y, speed * joystick.Vertical * Time.time * acceleration);
        }



        //jump
        if (!isJump && joybutton.Pressed)
        {
            isJump = true;
            //thrustの分だけ上方に力がかかる
            rb.AddForce(transform.up * thrust);

        }//doubleJump
        else if (!isDoubleJump && isJump && joybutton.Pressed)
        {
            isDoubleJump = true;

            //doubleThrustの分だけ上方に力がかかる
            rb.AddForce(transform.up * doubleThrust);

        }

    }

    //Planに触れている間作動
    void OnCollisionStay(Collision col)
    {
        ground = true;
        isJump = false;
        isDoubleJump = false;
    }

    //Planから離れると作動
    void OnCollisionExit(Collision col)
    {
        ground = false;

    }


}
