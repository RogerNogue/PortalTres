using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindEmitterToggleScript : MonoBehaviour
{
    void OnMouseDown()
    {
        transform.parent.gameObject.GetComponent<WindScript>().toggled();
    }
}
