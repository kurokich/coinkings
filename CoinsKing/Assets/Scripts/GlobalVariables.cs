using UnityEngine;
using System.Collections;

public class GlobalVariables : MonoBehaviour {

	public static int score;
	public static int meatCount;
	public static int currentCount;
	public static int maxCount;
	public static int level;
	public static int growCount;
	public static int vertsCount;
	public UILabel scoreText;
	public UILabel debugText;

	
	void Start () {
		vertsCount = 0;
		score = 0;
		meatCount = 2000;
		currentCount = 400;
		maxCount = 400;
		level = 1;
		//scoreText = GameObject.Find("ScoreText").GetComponent<UILabel>();
	}
	
	void Update () {
		float fps = 1F/Time.deltaTime;
		//scoreText.text = "スコア:" + score.ToString() + "\n焼けるお肉:" + meatCount.ToString() + "\nお肉ストック" + currentCount.ToString() + "/" + maxCount.ToString() + "\nレベル" + level.ToString(); 
		//debugText.text = "頂点数:" + vertsCount + "\nFPS:" +  fps.ToString("N2");
		//if(timer_start)timer += Time.deltaTime;
		//  meatCountUp
		
		//guiText.text = score.ToString ();
		//guiText.text += "\n\ncoin count : " +  GameObject.FindGameObjectsWithTag ("coin").Length;;
	}
}
