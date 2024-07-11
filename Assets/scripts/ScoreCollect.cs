using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollect : MonoBehaviour {
	
	public AudioSource collectSound;

	public ScoringSystem scoringSystem;

	void OnTriggerEnter (Collider other)
	{
		collectSound.Play();
		
		//print("1");
		scoringSystem.collect(1);
		Destroy(gameObject);
	}
	
}
