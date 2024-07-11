
using UnityEngine;
using System.Collections;


public class PlayerExplode : MonoBehaviour {
	
	public cube movement;
	public GameObject explosionEffect;
	bool hasExploded = false;
	public float delay = 1f;
	public AudioSource bomb;
	
	float countdown;
	
	void Start() {
		bomb = GetComponent<AudioSource>();
		countdown = delay;
	}
	
	void OnCollisionEnter (Collision collision)

	{
		
		//countdown -= Time.deltaTime;
		 if((collision.gameObject.name == "wall")||(collision.gameObject.name == "Player"))
		//{
			//if (countdown <= 0f)
			{
			bomb.Play();
			Explode();
			hasExploded = true;
		
			FindObjectOfType<GameManager>().EndGame();
			}
		//if (otherObject.GetComponent<Collider>().tag == ("Finish")) 
			//{
			
			//bakuhatu75.Play();
			//Explode();
			//hasExploded = true;
		
			//FindObjectOfType<GameManager>().EndGame();
			//}
			
		//}
	}
	void Explode ()
	{
		//bakuhatu75.Play();
		Instantiate(explosionEffect, transform.position, transform.rotation);
		
		//Destroy(gameObject);
	}
}


 