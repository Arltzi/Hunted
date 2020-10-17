using UnityEngine;

public class HunterFCollision : MonoBehaviour
{
    private float damageDealt;
    public GameObject damagingObject;

    private void Start()
    {
        damageDealt = damagingObject.GetComponent<DirectionalHunterDash>().damageDealt;
    }
    void OnTriggerEnter(Collider other)
    {
        // change if conditions as needed?
        if (other.GetComponent<HealthAndDamage>())
        {
            other.GetComponent<HealthAndDamage>().Damage(damageDealt);
        }
        else
        {
            return;
        }
    }
}