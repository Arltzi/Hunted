using UnityEngine;

public class HunterMovement : MonoBehaviour
{
    public float flatSpeed;
    private float inputMethodX, inputMethodZ;
    private float xRotation;
    public GameObject camParent;
    [SerializeField] private CharacterController cc;
    [SerializeField] private PlayerInputCollect pic;
    private void Start()
    {
        // TODO: set method of setting pic to collect from correct input class (AI, Keyboard Player, Mobile Player?, Controller Player?)
        pic = gameObject.GetComponent<PlayerInputCollect>();
        cc = gameObject.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        xRotation = 0;
    }
    void Update()
    {
        // get floats from input method
        inputMethodX = pic.x;
        inputMethodZ = pic.z;
        // set movement vector from input floats
        Vector3 moveVector = transform.right * inputMethodX + transform.forward * inputMethodZ;
        // normalize movement vector and multiply
        // if multiply before normalize, normalize negates multiplication by setting vector magnitude to 1 anyway
        moveVector = moveVector.normalized * flatSpeed * Time.deltaTime;
        cc.Move(moveVector);
        // rotation controls
        xRotation -= pic.mouseY;
        xRotation = Mathf.Clamp(xRotation, -60f, -10f);
        camParent.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * pic.mouseX);
    }
}