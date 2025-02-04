﻿using UnityEngine;
using System.Collections;

public class ChangeMaterial : MonoBehaviour 
{
	public LightController lightController;
	public Material echoMaterial;
	public Renderer[] objects;

	// Use this for initialization
	void Start () 
	{
		lightController.LightsAreOut += SwapMaterial;		
	}
	
	public void SwapMaterial()
	{
		for(int i = 0; i < objects.Length; i++)
		{
			objects[i].material = echoMaterial;
		}
	}

	void OnDestroy()
	{
		lightController.LightsAreOut -= SwapMaterial;
	}
}