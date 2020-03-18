using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObject : MonoBehaviour
{
    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay((Input.mousePosition));

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform)
                {
                    Debug.Log("yes");
                }
            }
        }
    }
}
