using UnityEngine;
using System.Collections;

public class Match : MonoBehaviour {

	public static float matchLightLevel = 100;
	public Light matchGlow;
	int extinguishRate = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		matchGlow.intensity = matchLightLevel / 50;

		matchLightLevel -= extinguishRate * Time.deltaTime;

		if(matchGlow.intensity <= 0.1){
			matchGlow.intensity = 0.1f;
		}
	}
}
