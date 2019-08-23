using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Vector2 mousePos2D;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray2D = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit = Physics2D.GetRayIntersection(ray2D,Mathf.Infinity);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.transform.parent.gameObject.name);
                SpriteRenderer spriteGO = hit.collider.gameObject.transform.parent.GetComponentInChildren<SpriteRenderer>();
                spriteGO.color = Color.red;
            }
        }
    }
}
