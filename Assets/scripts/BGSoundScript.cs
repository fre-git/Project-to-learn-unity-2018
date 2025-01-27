﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSoundScript : MonoBehaviour {

	
	
	private static BGSoundScript instance = null;
	public static BGSoundScript Instance
	{
	get {return instance; }
	}
	
	void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(this.gameObject);
			return;
		}
		
		DontDestroyOnLoad(this.gameObject);
	}
}
