using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchscript : MonoBehaviour
{
    //画面サイズを取得
    int width = Screen.width;
    int height = Screen.height;


    //HingeJointコンポーネント取得
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;

    //弾いた時の傾き
    private float flickAngle = -20;

    // Use this for initialization
    void Start()
    {

        //HingJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);


    }

    // Update is called once per frame
    void Update()
    {

        //右画面左画面の判定
        foreach (var touch in Input.touches){

            if (touch.phase == TouchPhase.Began)
            {

                if (touch.position.x < Screen.width / 2 && tag == "LeftFripperTag")
                {

                    SetAngle(this.flickAngle);

                }

            }else if (touch.phase == TouchPhase.Ended){
              
                if (touch.position.x < Screen.width/2 && tag == "LeftFripperTag"){

                    SetAngle(this.defaultAngle);

                }
            }

            if(touch.phase == TouchPhase.Began)
            {

                if (touch.position.x > Screen.width/2 && tag == "RightFripperTag")
                {

                    SetAngle(this.flickAngle);

                }
            }else if (touch.phase == TouchPhase.Ended){

                if (touch.position.x > Screen.width/2 && tag == "RightFripperTag")
                {

                    SetAngle(defaultAngle);
                }
            }
        }

        
    }


    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {

        JointSpring jointSpr = this.myHingeJoint.spring;

        jointSpr.targetPosition = angle;

        this.myHingeJoint.spring = jointSpr;

    }



}




