using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour {

    public delegate void OnCharacterDeathDelegate();
    public static event OnCharacterDeathDelegate onCharacterDeath;

    private static float defMaxHealth = 100f;
    private static float defHealth = defMaxHealth;

    public float health;
    public float maxHealth;

    // Start is called before the first frame update
    private void Start() {
        // Some default values if defHealth is not pre set.
            if (health <= 1f) health = defHealth;
            if (maxHealth <= 1f) maxHealth = defMaxHealth;
    }
    // Deal x amount of damage to health
    public void DamageHealth(float amount_) {
        if ((health - amount_) > 0) health -= amount_;
        else { onCharacterDeath?.Invoke(); }
    }
    // Heal x amount of missing health
    public void HealHealth(float amount_) {
        if ((health + amount_) < defMaxHealth) health += amount_;
        else health = defMaxHealth;
    }

    public float GetHealth() { return health; }
    public float GetMaxHealth() { return maxHealth; }
    // Return the remaining health percent
    public float GetHealthPercent() { return health / maxHealth * 100f; }

    public void SetHealth(int health_) { defHealth = health_; }
    public void SetMaxHealth(int maxHealth_) { defMaxHealth = maxHealth_; }


}
