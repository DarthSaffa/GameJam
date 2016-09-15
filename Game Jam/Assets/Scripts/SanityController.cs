using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SanityController : MonoBehaviour {

	public Slider sanitySlider;
	public float sanityLevel = 100;
	public float sanityMax = 100;
	float insanityTimer;
	public float insanityMultiplier = 0;
	float darknessLevel;
	public static bool isTakingDamage;


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		

		//darknessLevel maximum is 10, once it hits 7 you start to lose sanity based on the light level
		if (darknessLevel <= 7)
		{
			//isTakingDamage will most likely have a screen dark flash this variable can control this
			isTakingDamage = true;

			sanityLevel = (sanityLevel * insanityMultiplier) - darknessLevel * Time.deltaTime;
		}

		insanityTimer = insanityTimer + Time.deltaTime;

		//Insanity Multiplier divides from timer after 5 mins = 300 seconds
		if (insanityTimer <= 300) 
		{
			insanityMultiplier = insanityTimer / 100;
		}
				

	}
}
