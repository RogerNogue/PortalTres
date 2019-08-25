using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollTheBarrel : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("CLICKED");
        transform.parent.gameObject.GetComponent<rollingBarrelScript>().clicked();
    }
}
