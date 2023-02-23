using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBee : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue))
            {
                if (hit.collider.tag == "Bee")
                {
                    GameObject bee = hit.collider.gameObject;
                    bee.GetComponent<Bee>().Hit();
                }
            }
        }
    }
}
