using UnityEngine;
using UnityEngine.UI;

public class UICooldownHandling : MonoBehaviour
{
    public Cooldown cdObject;
    private int cdInt;
    private Text cdText;
    private void Start()
    {
        cdText = gameObject.GetComponent<Text>();
    }
    void Update()
    {
        if(cdObject.cooldown > 0){
            cdInt = (int)cdObject.cooldown + 1;
            cdText.text = cdInt.ToString();
        }
        else{
            cdText.text = " ";
        }
    }
}