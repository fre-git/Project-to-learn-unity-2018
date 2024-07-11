using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent (typeof (firstPersonController))]
public class playerVitals : MonoBehaviour 
{

	public Slider healthSlider;
	public float maxHealth;
	public float healthFallRate;

	public Slider thirstSlider;
	public float maxThirst;
	public float thirstFallRate;

	public Slider hungerSlider;
	public float maxHunger;
	public float hungerFallRate;

	public Slider staminaSlider;
	public int maxStamina;
	private int staminaFallRate;
	public int staminaFallMult;
	private int staminaRegainRate;
	public int staminaRegainMult;

	public AudioSource audio;
	public float landingVolume;
	
	bool inAir;
	bool hitGround;
	bool check;
	//private float inAirTime;
	private float movementPerFrame;
	Vector3 previousPosition;
	//Vector3 secondPosition;
	Vector3 Distance;
	public float fallingTime;
	public float falldamageMult;
	

	public firstPersonController fpsController;
	//private firstPersonController playerController;

	void Start()
	{
		healthSlider.maxValue =  maxHealth;
		healthSlider.value = maxHealth;

		thirstSlider.maxValue = maxThirst;
		thirstSlider.value = maxThirst;

		hungerSlider.maxValue = maxHunger;
		hungerSlider.value = maxHunger;

		staminaSlider.maxValue = maxStamina;
		staminaSlider.value = maxStamina;


		staminaFallRate = 1;
		staminaRegainRate = 1;
		bool runForT = false;
		bool moving = false;
		bool jumping = false;
		bool inAir = false;
		bool hitGround = false;
		bool check = false;
		//fallingTime = 0f;
		Vector3 Distance;
		Vector3 previousPosition  = transform.position;
		float movementPerFrame = 0f;

	}

	void Update()
	{
		//HEALTH controller
		if (hungerSlider.value <= 0 && (thirstSlider.value <= 0))
		{
			healthSlider.value -= Time.deltaTime / healthFallRate *2;
			Debug.Log("ok");
		}

		else if (hungerSlider.value <= 0 || (thirstSlider.value <= 0))
		{
			healthSlider.value -= Time.deltaTime / healthFallRate;
		}
		
		if (healthSlider.value <= 0)
		{
			CharacterDeath();
		}

		// Hunger controller
		if (hungerSlider.value >= 0)
		{
			hungerSlider.value -= Time.deltaTime / hungerFallRate;
			//Debug.Log("HungerGodown");
		}

		else if(hungerSlider.value <= 0)
		{
			hungerSlider.value = 0;
			//Debug.Log("new");
		}

		else if (hungerSlider.value >= maxHunger)
		{
			hungerSlider.value = maxHunger;
		}

		// Thirst controller
		if (thirstSlider.value >= 0)
		{
			thirstSlider.value -= Time.deltaTime / thirstFallRate;
		}

		else if(thirstSlider.value <= 0)
		{
			thirstSlider.value = 0;
		}

		else if (thirstSlider.value >= maxThirst)
		{
			thirstSlider.value = maxThirst;
		}

		//STAMINA controll section

		if (fpsController.jumping)
		{
			staminaSlider.value -= 15;
		}
		
		if (fpsController.runForT && fpsController.moving)
		//if (charController.velocity.magnitude > 0 && Input.GetKey(KeyCode.LeftShift))
		{
			staminaSlider.value -= Time.deltaTime / staminaFallRate * staminaFallMult;
			//Debug.Log("Cost energy");
		}

		else 
		{
			staminaSlider.value += Time.deltaTime / staminaRegainRate * staminaRegainMult;
			//Debug.Log("gain energy");
		}

		if (staminaSlider.value >= maxStamina)
		{
			staminaSlider.value = maxStamina;
		}

		else if (staminaSlider.value > 0)
		{
			fpsController.sprintSpeed = fpsController.sprintSpeedNorm;
		}
		else if (staminaSlider.value <= 0)
		{
			staminaSlider.value = 0;
			fpsController.sprintSpeed = 5;
		}

		// falldamage & in air
		if (fpsController.grounded)
		{
			inAir = false;
			fallingTime = 0f;
			//Debug.Log("Grounded");
		}
			
			
			
			//Debug.Log("inairfalse");
		
		else// if(fpsController.grounded = true)
		{
			inAir = true;
			if (fpsController.jumping)
			{
				fallingTime += (Time.deltaTime - Time.deltaTime/3f);
				Debug.Log("inairistrue!");
			}

			else
			{				
				fallingTime += Time.deltaTime;
				Debug.Log("inairistrue!");
			}

			//float movementPerFrame = Vector3.Distance (previousPosition, transform.position);
			//previousPosition = transform.position;

			if (fallingTime > 2f && inAir)
			{
				//if (hitGround)
				//{
				Debug.Log("too high!");
				bool check = true;
				healthSlider.value -= ((fallingTime) * falldamageMult);
				Debug.Log(fallingTime * falldamageMult);
				//}
			}
		
			
		}



		//float movementPerFrame = Vector3.Distance (previousPosition, transform.position);
		//previousPosition = transform.position;
	}

		
	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.layer == 10)
		{
			//if (fallingTime >.2)
			
			if (check)
			{
				audio.Play();
				check = false;
			}
	//			healthSlider.value = healthSlider.value - movementPerFrame * falldamageMult;
	//			hitGround = true;
	//			Debug.Log("hitground");
		}
		//}
	//	
	}

	//void OnCollisionExit(Collision collision)
	//{
	//	if(collision.gameObject.layer == 10)
	//	{
	//		hitGround = false;
	//		Debug.Log("noground");
	//	}
	//}
		
	void CharacterDeath()
	{
		SceneManager.LoadScene (3);
	}
}
