
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class trigger01 : MonoBehaviour {
	
	public AudioSource collectSound;
	
	

    //Get the GameObject’s mesh renderer to access the GameObject’s material and color
  //  public Renderer rend;
	
	// void Start()
   // {
	//	GetComponent<Renderer>();
   // }


	
	//void OnMouseEnter ()
	//{
	//rend.material.color -= Color.red;
//	}
	
	void OnMouseDown() 
			{
				
				{
					collectSound.Play();			
					SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
				}
			}
}
	 
//	void OnMouseExit ()
	//{
	//	rend.material.color = Color.green;
	//}
		

