using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationControl : MonoBehaviour
{
    [SerializeField]
    private Transform spear;

    void Update()
    {
        SetSpear();
    }

    private void SetSpear()
    {
        if (Input.GetButtonDown("Fire"))
        {
            Vector3 spearPosition = transform.position + transform.forward * 2;
            Instantiate(spear, spearPosition, transform.rotation);
        }
    }
}
