using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallContloller : MonoBehaviour {

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //スコア用の変数
　　int score = 0;

    //スコアを表示するテキスト
    private GameObject scoreText;


	// Use this for initialization
	void Start () {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        //シーン中のScoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");
	}
	
	// Update is called once per frame
	void Update () {
        //ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ){
            //GemeoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text> ().text = "Game Over";

        
        }

        
    }

    private void OnCollisionEnter(Collision other){

        if(other.gameObject.tag == "LargeStarTag"){

            score += 20;

        }else if (other.gameObject.tag == "LargeCloudTag"){

            score += 20;

        }else if (other.gameObject.tag == "SmallCloudTag"){

            score += 10;
        }
        this.scoreText.GetComponent<Text>().text = "score:" + score.ToString();
        
    }
}
