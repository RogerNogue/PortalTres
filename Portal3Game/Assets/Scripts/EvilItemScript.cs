using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilItemScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.transform.parent.gameObject.name);
        LifeScript lifeGO = col.transform.parent.gameObject.GetComponent<LifeScript>();
        lifeGO.currentHP -= 1;
    }
}
