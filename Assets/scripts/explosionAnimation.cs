using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionAnimation : MonoBehaviour {
	
	
	public float delay = 1f;
	
	public GameObject explosionEffect;
	float countdown;
	bool hasExploded = false;

	// Use this for initialization
	void Start () {
		countdown = delay;
		
	}
	
	// Update is called once per frame
	void Update () {
		countdown -= Time.deltaTime;
		if (countdown <= 0f && !hasExploded)
		{
			Explode();
			hasExploded = true;
		}
	}
	
	void Explode ()
	{
		Instantiate(explosionEffect, transform.position, transform.rotation);
		
		Destroy(gameObject);
	}
}
