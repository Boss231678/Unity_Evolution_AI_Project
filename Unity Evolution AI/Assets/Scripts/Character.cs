using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Character : MonoBehaviour {
    public string type;  //cop or robber

    public float health = 100f;

    public void reduceHealth(float damage) {
        // damage passed in is always 100
        health -= damage;
        Debug.Log(type + " got hurt ");
    } 

    // public void {
    
    // }
    
    
}
public class Robber : Character {
    private string robberType; 
    // later down, maybe use type of robbers, ie shoplifter vs bank robber for now default
    // typical type is default
    // multiplier amongst robbers, can be increased through ML
    private float cooperation = 1f;
    //no honor amongst thieves
    private float competiveness = 1f;
    
    void Start() {

    }
    void Update() {

    }
    void FixedUpdate() {
        TakeDamage(100f);
    }

    //class constructor
    public Robber(string robberType, float cooperation, float competiveness) {
        this.robberType = robberType;
        this.cooperation = cooperation;
        this.competiveness = competiveness;
    }

    public string nameType {
        get { return type; }
        set { type = value; }
    }
    public float nameCooperation {
        get { return cooperation; }
        set { cooperation = value; } // robber2.nameCooperation = value;
    }

    public float nameCompetitveness {
        get { return competiveness; }
        set { competiveness = value; }
    }

    // public void goToFood {
        
    // }
    public void TakeDamage(float damage) {
        damage = 100f; //instant death
        Debug.Log("TEST A");
        reduceHealth(100f); 
        Debug.Log("TEST B");
    }
}

public class Cop : Character {
    private string copType; // same use as robber 

    // public bool catchRobber {
    //     if (true)
        
    // }
}