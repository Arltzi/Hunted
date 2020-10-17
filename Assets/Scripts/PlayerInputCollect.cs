using UnityEngine;

public class PlayerInputCollect : MonoBehaviour
{
    public float x, z, mouseX, mouseY;
    private PlayerSettings ps;

    
    private void Start()
    {
        ps = gameObject.GetComponent<PlayerSettings>();
    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        mouseX = Input.GetAxis("Mouse X") * ps.rotSens;
        mouseY = Input.GetAxis("Mouse Y") * ps.vertMouseSens;
    }
}
