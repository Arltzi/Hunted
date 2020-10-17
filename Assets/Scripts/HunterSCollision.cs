using UnityEngine;

public class HunterSCollision : MonoBehaviour
{
    private float damageDealt;
    public GameObject stompObj;

    private void Start()
    {
        damageDealt = stompObj.GetComponent<StompAbil>().damageDealt;
    }
    void OnCollisionEnter(Collision other)
    {
        RaycastHit rch;
        Physics.Raycast(transform.position, other.transform.position - transform.position, out rch);
        Debug.DrawRay(transform.position, other.transform.position - transform.position, Color.yellow, 0.5f, true);
        // FIGURE OUT IF STATEMENT CONDITIONS
        if (rch.transform.gameObject.GetComponent<HealthAndDamage>())
        {
            // change if conditions as needed?
            if (other.gameObject.GetComponent<HealthAndDamage>())
            {
                other.gameObject.GetComponent<HealthAndDamage>().Damage(damageDealt);
            }
            else
            {
                return;
            }
        }
    }
}