using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : IStats
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int maxLives;

    [SerializeField] private int currHealth;
    [SerializeField] private int currLives;
    
    void Awake() {
        this.health = maxHealth;
        this.lives = maxLives;
        this.currHealth = maxHealth;
        this.currLives = maxLives;
    }

    public void damage(int dmg) {
        this.currHealth -= dmg;
        if (this.currHealth <= 0) {
            this.currLives --;
            this.currHealth = maxHealth;
            if (this.currLives <= 0) {
                Debug.Log("Player has lost all lives");
            }
        }
    }
}
