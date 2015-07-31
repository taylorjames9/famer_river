﻿using UnityEngine;
using System.Collections;

public enum BoatState{EastBank, WestBank, Traveling, Tipped};

public class BoatScript : MonoBehaviour {


  public GameObject EastBankLandingSpot;
  public GameObject WestBankLandingSpot;
  public static BoatState boat_state;
  public static BoatState otherBank;
  public float speed =5.0f;
  public Transform target;
  public bool moving;  
  public static bool objectInBoat;  

  void OnTriggerEnter(Collider other){
    switch (other.gameObject.tag) {
    case "Eastbank":
	  Debug.Log ("Arrived on EastBank");
      boat_state = BoatState.EastBank;
      otherBank = BoatState.WestBank;
      break;
    case "WestBank":
	  Debug.Log ("Arrived on WestBank");
      boat_state = BoatState.WestBank;
      otherBank = BoatState.EastBank;
      break;

    default: 
      break;
    }
  }

  void OnEnable(){
    PlayerScript.OnBoatLaunch += BoatMovement;
  }

  void OnDisable(){
    PlayerScript.OnBoatLaunch -= BoatMovement;
  }


  public void BoatMovement(){
    moving = true;
    //movetowards other shore 
    //while (boat_state != otherBank) {

    //}
  }
  
  public void PlayerInBoat(){
    Debug.Log("Boat responds to player in boat event,as does river");
  }

	// Use this for initialization
	void Start () {
    boat_state = BoatState.EastBank;
    otherBank = BoatState.WestBank;
	}
	
	// Update is called once per frame
	void Update () {
	  if(moving){
      float step = speed * Time.deltaTime;
      if((int)otherBank == (int)BoatState.WestBank){
        transform.position = Vector3.MoveTowards(transform.position, WestBankLandingSpot.transform.position, step);
      } else {
        transform.position = Vector3.MoveTowards(transform.position, EastBankLandingSpot.transform.position, step);
      }
    }
	}
}
