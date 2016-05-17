using UnityEngine;
using System.Collections;

public class DestroyByBondary : MonoBehaviour
{

    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
