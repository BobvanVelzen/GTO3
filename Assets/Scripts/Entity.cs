using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour {

    public Text textHealth;

    private int maxHealth = 30;
    private int health = 30;

	// Use this for initialization
	void Start () {
        textHealth.text = health + "/" + maxHealth;
	}
	
	
}
