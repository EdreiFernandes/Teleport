using UnityEngine;

public class TeleportationControl : MonoBehaviour
{
    [SerializeField]
    private Transform spear;
    private Vector3 spearPosition;
    private bool carryingASpear = true;

    void Update()
    {
        if (Input.GetButtonDown("Fire"))
        {
            if(carryingASpear)
            {
                SetSpear();
            }
            else
            {
                teleportToSpear();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        TakingTheSpearBack(other);
    }

    private void SetSpear()
    {
        spearPosition = transform.position + transform.forward * 2;
        Instantiate(spear, spearPosition, transform.rotation);
        carryingASpear = false;
    }

    private void teleportToSpear()
    {
        transform.position = spearPosition;
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
