﻿
using UnityEngine;


public class TutTeleport2 : MonoBehaviour {
	
	public AudioSource collectSound;
	
		
	void OnTriggerStay  (Collider other)
	{
		if((other.gameObject.tag=="Player") &&  (Input.GetKey(KeyCode.F)))
		{
			collectSound.Play();	
			other.transform.position = new Vector3(-54.5f, 0.6f, -3.5f);
		}
	}
	
	
}
