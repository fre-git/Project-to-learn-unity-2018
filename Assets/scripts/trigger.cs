
using UnityEngine;


public class trigger : MonoBehaviour {
	
		public AudioSource collectSound;
	
		
	void OnTriggerStay  (Collider other)
	{
		if((other.gameObject.tag=="Player") &&  (Input.GetKey(KeyCode.F)))
		{
			collectSound.Play();			
			Destroy (GameObject.FindWithTag("triggerDoor"));
		}
	}
	
	
}
