using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class  SoundPlayer {
	
	private GameObject soundPlayerObj;
	private AudioSource audioSource;
	Dictionary<string,AudioClipInfo> audioClips = new Dictionary<string, AudioClipInfo>();
	
	// AudioClipInformation
	class AudioClipInfo{
		public string resourceName;
		public string name;
		public AudioClip clip;
		
		public AudioClipInfo( string resourceName, string name){
			this.resourceName = resourceName;
			this.name = name;
		}
	}
	
	//Constructor
	public SoundPlayer(){
		audioClips.Add("se001", new AudioClipInfo("meat_boil","se001"));
	}
	
	 public bool playSE(string seName){
		if(audioClips.ContainsKey(seName) == false)
			return false;
		
		AudioClipInfo info = audioClips["se001"];
	
		//Load
		if(info.clip == null){
			Debug.Log (info.resourceName);
			info.clip = (AudioClip)Resources.Load(info.resourceName);
		}
		if(soundPlayerObj == null){
			soundPlayerObj = new GameObject("SoundPlayer");
			audioSource = soundPlayerObj.AddComponent<AudioSource>();
		}
	
		//PlaySE
		audioSource.PlayOneShot(info.clip);
		
		return true;
	}
}
