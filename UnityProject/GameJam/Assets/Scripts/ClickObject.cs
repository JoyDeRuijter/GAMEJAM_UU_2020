using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObject : MonoBehaviour
{
    Endscreen end;
    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0) && end.isPlaying == true)
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
