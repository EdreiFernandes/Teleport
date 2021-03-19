using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationControl : MonoBehaviour
{
    [SerializeField]
    private Transform spear;
    private bool carryingASpear = true;

    void Update()
    {
        SetSpear();
    }

    private void OnTriggerEnter(Collider other)
    {
        TakingTheSpearBack(other);
    }

    private void SetSpear()
    {
        if (Input.GetButtonDown("Fire") && carryingASpear)
        {
            Vector3 spearPosition = transform.position + transform.forward * 2;
            Instantiate(spear, spearPosition, transform.rotation);
            carryingASpear = false;
        }
    }

    private void TakingTheSpearBack(Collider spearCollider)
    {
        if (spearCollider.tag == Tags.Spear.ToString())
        {
            Destroy(spearCollider.gameObject);
            carryingASpear = true;
        }
    }
}
