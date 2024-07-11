
using UnityEngine;

public class explosion : MonoBehaviour {
	
	public cube movement;
	public GameObject explosionEffect;
	bool hasExploded = false;
	public float delay = 1f;
	public AudioSource bomb;
	Vector3 originalPosition;
	
	float countdown;
	
	void Start() {
		bomb = GetComponent<AudioSource>();
		countdown = delay;
		originalPosition = transform.position;
	}
	
	//void OnCollisionEnter (Collision collisionInfo)
	void OnTriggerEnter (Collider otherObject)
	{
		
		//countdown -= Time.deltaTime;
		if (otherObject.GetComponent<Collider>().tag == ("object")) 
		//{
			//if (countdown <= 0f)
			{
			bomb.Play();
			Explode();
			hasExploded = true;
			//transform.position = originalPosition;
		
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


 