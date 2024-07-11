
using UnityEngine;


public class teleport : MonoBehaviour {
	
	public AudioSource collectSound;
	
		
	void OnTriggerStay  (Collider other)
	{
		if((other.gameObject.tag=="Player") &&  (Input.GetKey(KeyCode.F)))
		{
			collectSound.Play();	
			other.transform.position = new Vector3(-6.5f, 0.5f, 8.5f);
		}
	}
	
	
}
