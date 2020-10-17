using UnityEngine;

public class Cooldown : MonoBehaviour
{
    public float cooldown;
    private float cdHolder;

    private void Start()
    {
        cdHolder = cooldown;
    }
    public void CoolDownCounter()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }
    public bool CoolDownCheck()
    {
        if (cooldown > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void RestartCD()
    {
        cooldown = cdHolder;
    }
}
