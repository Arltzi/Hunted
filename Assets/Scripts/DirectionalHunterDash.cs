using UnityEngine;

public class DirectionalHunterDash : MonoBehaviour
{
    public float damageDealt;
    public GameObject hunter;
    private Transform hunterTf;
    private CharacterController huntercc;
    private RaycastHit preFireRay;
    public ParticleSystem preFirePartSys;
    public GameObject preFireEndModel;
    private MeshRenderer preFireEndModelRenderer;
    public ParticleSystem postFirePartSys;
    public BoxCollider postFireBoxCollider;
    private bool nextFrameTest;
    public Cooldown cd;
    private float cdHolder;
    void Start()
    {
        hunterTf = hunter.GetComponent<Transform>();
        huntercc = hunter.GetComponent<CharacterController>();
        preFireEndModelRenderer = preFireEndModel.GetComponent<MeshRenderer>();
        preFireEndModelRenderer.enabled = false;
        postFireBoxCollider.enabled = false;
        cdHolder = cd.cooldown;
    }
    void Update()
    {
        cd.CoolDownCounter();
        // this short if statement is to disable the box collider after
        // 1 frame of being active
        if(nextFrameTest){
            postFireBoxCollider.enabled = false;
            nextFrameTest = false;
        }
        if(Input.GetKey(KeyCode.F) && cd.CoolDownCheck())
        {
            if(Physics.Raycast(hunterTf.position, hunterTf.transform.forward, out preFireRay, 
            100, ~LayerMask.GetMask("hunter", "targets"), QueryTriggerInteraction.Ignore))
            {
                // enable endModel & partSys
                preFireEndModelRenderer.enabled = true;
                // Debug.DrawLine(hunterTf.position, preFireRay.point, Color.yellow, 0.1f, false);
                preFirePartSys.Play();
                // gotta define the struct of partsys.shape because its a bitch :(
                // AKA adjusting the scale of the partSys so it is as long as the ray
                var sc = preFirePartSys.shape;
                Vector3 partSysScale = sc.scale;
                partSysScale.z = preFireRay.distance;
                sc.scale = partSysScale;
                // adjusting the position of the partSys so the center is halfway b/w the 
                // player and the end of the ray
                Transform tfm = preFirePartSys.transform;
                tfm.position = (hunterTf.forward * sc.scale.z)/2 + hunterTf.position;
                // move the endModel
                preFireEndModel.transform.position = preFireRay.point - transform.forward*0.5f;
            }
        }
        if(Input.GetKeyUp(KeyCode.F) && cd.CoolDownCheck())
        {
            if(Physics.Raycast(hunterTf.position, hunterTf.transform.forward, out preFireRay,
            100, ~LayerMask.GetMask("hunter", "targets"), QueryTriggerInteraction.Ignore)){
                // disable then reenable the character controller to bypass the transform 
                // restrictions of the cc
                huntercc.enabled = false;
                hunterTf.position = preFireRay.point - transform.forward*0.5f;
                huntercc.enabled = true;
                // set center of postFireBoxCollider at center of raycast?
                Vector3 pfbcVec = -1 * (hunterTf.forward) * preFireRay.distance/2f;
                pfbcVec.y = huntercc.center.y;
                pfbcVec += hunterTf.position;
                postFireBoxCollider.transform.position = pfbcVec;
                // set the z value of the bc.scale to the length of the vector, 
                // set the y value of the bc.scale to huntercc.height 
                // gotta use the extra vector3 to get past struct limitations.
                pfbcVec = postFireBoxCollider.size;
                pfbcVec.y = huntercc.height;
                pfbcVec.z = preFireRay.distance;
                postFireBoxCollider.size = pfbcVec;
                // enable the postFireBoxCollider before disabling it next frame to 
                // allow collision calculations to happen for 1 frame.
                nextFrameTest = true;
                postFireBoxCollider.enabled = true;
                // play postFirePartSys
                postFirePartSys.Play();
                // start cooldown
                cd.cooldown = cdHolder;
            }
            // regardless of what u hit the end model and partSys need to be turned off
            preFirePartSys.Stop();
            preFireEndModelRenderer.enabled = false;
        }
    }
}