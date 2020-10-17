using UnityEngine;

public class HealthAndDamage : MonoBehaviour
{
    public float health;
    public void Damage(float dmg){
        Debug.Log(gameObject.name + " hit for " + dmg);
        health -= dmg;
        if(health <= 0){
            Die(gameObject);
        }
    }
    public void Die(GameObject objToDie){
        GameObject.Destroy(objToDie);
    }
}