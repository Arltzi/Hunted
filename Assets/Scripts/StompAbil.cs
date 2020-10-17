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
    public MeshCollider postFireMeshCol;
    public ParticleSystem postFirePartSys;
    public Cooldown cd;
    private bool nextFrameTest;
    void Update()
    {
        transform.rotation = Quaternion.identity;
        cd.CoolDownCounter();
        if (nextFrameTest)
        {
            postFireMeshCol.enabled = false;
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
            postFireMeshCol.enabled = true;
            nextFrameTest = true;
            cd.RestartCD();
        }
    }
    private void LateUpdate()
    {
        transform.rotation = Quaternion.identity;
    }
}