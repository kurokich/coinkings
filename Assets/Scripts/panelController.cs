using UnityEngine;
using System.Collections;

public class panelController : MonoBehaviour {
	
	public GameObject debugText;
	public GameObject[] bottons;
	
	public static float screenScale;	
	
	// Use this for initialization
	void Start () {
		
		//Check the Scale
		float totalHeight = 0;
		screenScale = backPanelController.screenScale;
		
		//DebugText
		debugText.transform.localPosition = new Vector3(Screen.width - 120.0f,0.0f,0.0f);		
		totalHeight += 65;
		
		//bottons
		foreach(GameObject g in bottons){
			g.transform.transform.localPosition = new Vector3(Screen.width - 90.0f,-totalHeight,0.0f);
			totalHeight += 44;
		}		
		
		
		//DownPanel(DownRect)
		GameObject downPanel = GameObject.Find("DownPanel").gameObject;
		downPanel.transform.localScale = new Vector3(Screen.width,backPanelController.blackHeight,0.0f);
		downPanel.transform.localPosition = new Vector3(0,backPanelController.blackHeight - Screen.height,0);
		
		
		//Rect
		/*
        Rect rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
		rect.x = blackWidth / Screen.width;
        rect.width = 1.0f - blackWidth / Screen.width * 2;
        rect.y = blackHeight / Screen.height;
        rect.height = 1.0f - blackHeight / Screen.height * 2;
		GameObject bgCam = GameObject.FindWithTag("bgCamera");
		bgCam.camera.rect = rect;
		*/
	}

}
