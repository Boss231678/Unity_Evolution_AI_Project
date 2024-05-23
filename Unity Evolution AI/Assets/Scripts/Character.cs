// using System;
// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
// using System.Threading;
// using UnityEditor.UI;
// using Palmmedia.ReportGenerator.Core.Parser.Analysis;

public class Character : MonoBehaviour {
    public string _charBaseType;  //cop or robber, eventually should start changing things but guessing unity won't allow you to modify vars in scripts while running, need gamemanager/main
    public float _health = 100f;
    
    // Constructor
    public Character(string characterType) {
        _charBaseType = characterType;
    }

    public void ReduceHealth(float damage) { //example function, make this virtual for override, ie animal.speak() becomes dog.speak() or "woof"
        _health -= damage;
        Debug.Log(_charBaseType + " got hurt ");
    } 
    private void AssignTypeClass() {
        if (_charBaseType == "Robber") {
            gameObject.AddComponent<Robber>(); 
            //attach robber to gameObject or capsule, then Start() in Robber class is run
        }
        else if (_charBaseType == "Cop") {
            gameObject.AddComponent<Cop>();
        }
    }
    void Start() {
        Debug.Log("Start from character is called ");
        _charBaseType = "Robber"; //making everyone robber for now
        AssignTypeClass();
    }

    void Update() {

    }
}

public class Robber : Character { // robber specific functions/attributes
    private string _robberType = "default"; // same purpose as _copType
    private float _cooperation = 1f;
    private float _competitiveness = 1f;

    void Start() {
        inheritedClassTest();
        TakeDamage(2f);
    }

    void Update() {

    }

    // Class constructor
    public Robber(string robberType, float cooperation, float competitiveness) : base("Robber") {
        _robberType = robberType;
        _cooperation = cooperation;
        _competitiveness = competitiveness;
    }

    public string RobberType {
        get { return _robberType; }
        set { _robberType = value; }
    }

    public float Cooperation {
        get { return _cooperation; }
        set { _cooperation = value; }
    }

    public float Competitiveness {
        get { return _competitiveness; }
        set { _competitiveness = value; }
    }

    public void TakeDamage(float damage) { //example purposes, get rid later
        damage = 100f; //instant death for now
        Debug.Log("Robber is taking damage...");
        base.ReduceHealth(damage); //call base class method, include base for explicit use but not needed
    }

    // public override void ReduceHealth(float damage)
    // {
    //     Debug.Log("overriding a function from base class");
    // }

    public void inheritedClassTest() {
        Debug.Log("inherited class test");
    }
}


public class Cop : Character { // cop specific functions/attributes
    private string _copType = "default"; // later use perhaps (sheriff, deputy..)

    public Cop(string copType) : base("Cop") { 
        _copType = copType;
    }

    public string copType {
        get { return _copType; }
        set { _copType = value; }
    }
}