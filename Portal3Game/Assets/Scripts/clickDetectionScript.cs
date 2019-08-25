using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickDetectionScript : MonoBehaviour
{

    void OnMouseDown()
    {
        transform.parent.gameObject.GetComponent<explodingBarrel>().clicked();
    }
}
