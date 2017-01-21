﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour {

	private static TeamManager _instance;
	public static TeamManager instance 
	{
		get
		{
			return _instance;
		}
	}


	public List<TeamMember> playerTeam;
	public List<TeamMember> enemyTeam;


	void Awake()
	{
		if (_instance != null) {Destroy(this);}
		_instance = this;

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public List<TeamMember> GetTargetTeam(TeamMember.Team targetTeam)
	{
		switch(targetTeam) 
		{
			case TeamMember.Team.Player:
				return playerTeam;
			case TeamMember.Team.Enemy:
				return enemyTeam;

			default:
				Debug.LogErrorFormat("Supplied unaccounted for team : {0}", targetTeam.ToString());
				return enemyTeam;
		}
	}

	public void AddToTeam(TeamMember.Team newTeam, params TeamMember[] membersToAdd)
	{
		Debug.LogFormat("Adding {0} members to team", membersToAdd.Length);

		foreach (TeamMember member in membersToAdd) 
		{
			Debug.Log("performing action on member");

			//if (member.currentTeam != newTeam) //only do work if it's a differnt team
			//{
				switch (newTeam)
				{
					case TeamMember.Team.Player:	//add to player team
						Debug.Log("Switch to Player Team");
						if (playerTeam.Contains(member)) {return;}
						enemyTeam.Remove(member);
						playerTeam.Add(member);
						member.ChangeTeam(TeamMember.Team.Player);
						break;
					case TeamMember.Team.Enemy:		//add to enemy team
						Debug.Log("Switch to Enemy Team");
						if (enemyTeam.Contains(member)) {return;}
						playerTeam.Remove(member);
						enemyTeam.Add(member);
						member.ChangeTeam(TeamMember.Team.Enemy);
						break;
				}

				member.ChangeTeam(newTeam);		//signal the change on the team member
			//}
		}
	}

	public void RemoveFromAllTeams(params TeamMember[] membersToRemove)
	{
		foreach(TeamMember member in membersToRemove)
		{
			playerTeam.Remove(member);
			enemyTeam.Remove(member);
		}
	}
}
