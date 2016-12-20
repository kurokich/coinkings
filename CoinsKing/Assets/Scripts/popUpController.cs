using UnityEngine;
using System.Collections;

public class popUpController : MonoBehaviour {

	public GameObject deliObj;
	public GameObject namaObj;
	public GameObject bgObj;

	private float deliObjWidth;
	private float deliObjHeight;
	private float namaObjWidth;
	private float namaObjHeight;
	
	
	// Use this for initialization
	void Start () {
		//Get Texture's Width &  Height
		deliObjWidth = deliObj.transform.localScale.x;
		deliObjHeight = deliObj.transform.localScale.y;

		namaObjWidth = namaObj.transform.localScale.x;
		namaObjHeight = namaObj.transform.localScale.y;

		//DeliciousSprite
		deliObj.transform.localScale = new Vector3(deliObjWidth * panelController.screenScale / 2.0f,deliObjHeight * backPanelController.screenScale / 2.0f,0.0f);
		deliObj.transform.localPosition = new Vector3(0.0f,-backPanelController.bgObjHeight,0.0f);
		
		namaObj.transform.localScale = new Vector3(namaObjWidth * backPanelController.screenScale / 2.0f,namaObjHeight * backPanelController.screenScale / 2.0f,0.0f);
		namaObj.transform.localPosition = new Vector3(0.0f,-backPanelController.bgObjHeight,0.0f);
	}
	
}
