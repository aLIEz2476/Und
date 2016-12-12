using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;
    public Slider healthSlider;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
        healthSlider.value = currentHealth;
	}
}
