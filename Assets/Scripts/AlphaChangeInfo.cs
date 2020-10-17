using UnityEngine;

public class AlphaChangeInfo : MonoBehaviour
{
    public bool isVis;
    public string boolName;
    Animator anim;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        if(!isVis){
            anim.SetBool(boolName, false);
        }
        else{
            anim.SetBool(boolName, true);
        }
    }
}
