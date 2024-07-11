
using UnityEngine;


public class TeleportBack : MonoBehaviour {
	
	public AudioSource collectSound;
	
		
	void OnTriggerStay  (Collider other)
	{
		if((other.gameObject.tag=="Player") &&  (Input.GetKey(KeyCode.F)))
		{
			collectSound.Play();	
			other.transform.position = new Vector3(12.5f, 0.5f, -1.5f);
		}
	}
	
	
}
