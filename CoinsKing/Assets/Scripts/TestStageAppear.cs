using UnityEngine;
using System.Collections;

public class TestStageAppear : MonoBehaviour {
	private bool isStageButtonPressed;
	public GameObject mainStage;
	public GameObject leftStage;
	public GameObject rightStage;
	public GameObject wallStage;
	public GameObject backStage;

	void StageButtonPressed(){
		isStageButtonPressed = isStageButtonPressed ? false : true;
		if(isStageButtonPressed){
			mainStage.GetComponent<Renderer>().enabled = false;
			leftStage.GetComponent<Renderer>().enabled = false;
			rightStage.GetComponent<Renderer>().enabled = false;
			wallStage.GetComponent<Renderer>().enabled = false;
			backStage.GetComponent<Renderer>().enabled = false;
		}else{
			mainStage.GetComponent<Renderer>().enabled = true;
			leftStage.GetComponent<Renderer>().enabled = true;
			rightStage.GetComponent<Renderer>().enabled = true;
			wallStage.GetComponent<Renderer>().enabled = true;
			backStage.GetComponent<Renderer>().enabled = true;
		}
	}
}
