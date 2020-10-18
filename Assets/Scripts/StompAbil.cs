using UnityEngine;

// DONE enable preFirePartSys
// play travel up anim
// DONE play secondary partSys
// DONE flash box collider
// damage implementation
// DONE cooldown implementation

public class StompAbil : MonoBehaviour
{
    public float damageDealt;
    public ParticleSystem preFirePartSys;
    public GameObject postFireMeshCol;
    public ParticleSystem postFirePartSys;
    public Cooldown cd;
    private bool nextFrameTest;
    void Update()
    {
        transform.rotation = Quaternion.identity;
        cd.CoolDownCounter();
        if (nextFrameTest)
        {
            postFireMeshCol.SetActive(false);
            nextFrameTest = false;
        }
        if (Input.GetKey(KeyCode.G) && cd.CoolDownCheck())
        {
            preFirePartSys.Play();
        }
        if (Input.GetKeyUp(KeyCode.G) && cd.CoolDownCheck())
        {
            preFirePartSys.Stop();
            postFirePartSys.Play();
            postFireMeshCol.SetActive(true);
            nextFrameTest = true;
            cd.RestartCD();
        }
    }
}