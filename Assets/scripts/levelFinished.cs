
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelFinished : MonoBehaviour {
	public GameManager gameManager;
	//public CompleteLevelUI completeLevelUI;
		
	public float restartDelay = 4f;
	public explosion Explosion;
	bool gameHasEnded = false;
		
	void Update()
	{	
		if (Explosion == true)
			{
				gameHasEnded = true;
				//Invoke("Restart", restartDelay);
			}
	}
	
	public void LoadNextLevel () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	
	
	
	void OnTriggerStay  (Collider other)
	{
		
		if((other.CompareTag("bomb")) &&  (Input.GetKey(KeyCode.F)))
		{
			//completeLevelUI.SetActive (true);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}
			//gameManager.completeLevel();
			//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			
			
	//public void LoadNextLevel () {
	//	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	//}
			
			//if(Explosion == true)
			//{
			//	gameHasEnded = true;
				//Debug.Log("GAME OVER");
				//Invoke("Restart", restartDelay);
			//}
		
			//else if(Explosion == false)
			//{
			//	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			//	gameManager.completeLevel();
			//}
		
	


	//public void LoadNextLevel()
	//{
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	//}