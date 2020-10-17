using UnityEngine;

public class RoofAlphaChange : MonoBehaviour
{
    public AlphaChangeInfo[] objectsToInvis;
    public bool onOff;
    // public bool XorZ;
    // public bool invertedDirection;
    public string whoToCollideWith;
    // public float ratioInCollider;
    // private BoxCollider bc;
    // private float colliderMax, colliderMin;
    private void Start()
    {
        // bc = gameObject.GetComponent<BoxCollider>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == whoToCollideWith & onOff)
        {
            foreach(AlphaChangeInfo objToInvis in objectsToInvis){
                objToInvis.isVis = true;
            }
        }
        if(other.tag == whoToCollideWith & !onOff)
        {
            foreach(AlphaChangeInfo objToInvis in objectsToInvis){
                objToInvis.isVis = false;
            }
        }
    }
    // private void OnTriggerStay(Collider other)
    // {
    //     if(other.tag == whoToCollideWith)
    //     {
    //         if(XorZ)
    //         {
    //             colliderMax = transform.position.x + bc.size.x;
    //             colliderMin = transform.position.x - bc.size.x;
    //             float hunterX = other.transform.position.x;
    //         }
    //         if(!XorZ)
    //         {
    //             colliderMax = transform.position.z + bc.size.z/2;
    //             colliderMin = transform.position.z - bc.size.z/2;
    //             float hunterZ = other.transform.position.z;
    //         }
    //         if(invertedDirection)
    //         {
    //             colliderMax *= -1;
    //             colliderMin *= -1;
    //         }
    //     }
    // }

}
