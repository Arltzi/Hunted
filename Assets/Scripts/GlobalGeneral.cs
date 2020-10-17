using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGeneral : MonoBehaviour
{
    void Start()
    {
        Physics.IgnoreLayerCollision(8, 10);
        Physics.IgnoreLayerCollision(8, 9);
    }
}
