using UnityEngine;
using System.Collections;

public class Pusher : MonoBehaviour
{
	private Vector3 origin;
	
	void Update () 
	{
		float zmove =  Mathf.Sin(Time.time * 1.3f) * 0.5f;
		zmove = zmove / 10;
		Vector3 offset = new Vector3 (0, 0, zmove);
		
		GetComponent<Rigidbody>().MovePosition (origin + offset);
	}
	
	void Awake ()
	{
		 // save origin position
		origin = GetComponent<Rigidbody>().position;
	}
}