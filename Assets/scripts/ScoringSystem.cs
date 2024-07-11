using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour {

	public GameObject scoreText;
	public float score = 0;
	
	public void collect(int amount) {
		score += amount;
		update();
	}
	
	public void update()
	{
		scoreText.GetComponent<Text>().text = "Gold: " + score;
	}
	
}
