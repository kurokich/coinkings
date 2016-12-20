using UnityEngine;
using System.Collections;

public class backPanelController : MonoBehaviour {

	public GameObject bgObj;
	
	public static float screenScale;	
	public static float bgObjWidth;
	public static float bgObjHeight;
	public static float blackHeight;
	public static float blackWidth;
	
	// Use this for initialization
	void Awake () {
		//Get Texture's Width &  Height
		bgObjWidth = bgObj.transform.localScale.x;
		bgObjHeight = bgObj.transform.localScale.y;
	
		//Check the Scale
		float totalHeight = 0;
		screenScale = Screen.width / bgObjWidth;
		
		//BackGround
		bgObj.transform.localScale = new Vector3(Screen.width,bgObjHeight * screenScale,0.0f);
		blackHeight = (Screen.height - Screen.width * 3 / 2) / 2;
		blackHeight = blackHeight < 0 ? 0 : blackHeight;
		bgObj.transform.localPosition = new Vector3(0.0f,-blackHeight,0.0f);	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
