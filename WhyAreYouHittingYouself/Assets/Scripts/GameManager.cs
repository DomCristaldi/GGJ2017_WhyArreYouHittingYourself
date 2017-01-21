﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private static GameManager _instance;
	public static GameManager instance
	{
		get {return _instance;}
	}

	public PlayerController playerRef;

	[SerializeField]
	private float timeCoefficient = 1.0f;

	void Awake()
	{
		if (_instance == null) {_instance = this;}
	}

	// Use this for initialization
	void Start () {
		SetTimeCoefficient(timeCoefficient);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
    /// Sets the time scale
    /// </summary>
    /// <param name="timeCoefficient">desired coefficient of Time. 0.5f -> half speed, 2.0f -> double speed/param>
	public void SetTimeCoefficient(float timeCoefficient)
	{
		this.timeCoefficient = timeCoefficient;
		Time.timeScale = this.timeCoefficient;
	}

	private void EndGame_PlayerWins()
	{

	}

	private void EndGame_PlayerLoses()
	{

	}

}