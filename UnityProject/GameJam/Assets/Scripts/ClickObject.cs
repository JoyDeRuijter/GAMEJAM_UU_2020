using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObject : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
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
