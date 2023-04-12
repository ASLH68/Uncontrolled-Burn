using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlareGun : MonoBehaviour
{
    [SerializeField] private GameObject flareShot;

    private int flareAmmo;
    private float flareSpeed;
    [SerializeField] private Transform spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void ShootFlare()
    {
        if(flareAmmo == 0)
        {
            return;
        }
        GameObject flare = Instantiate(flareShot, spawnLocation.position, Quaternion.identity);

        Rigidbody rb = flare.GetComponent<Rigidbody>();

        rb.AddForce(new Vector3(flare.transform.position.x, flare.transform.position.y, flare.transform.position.z), ForceMode.Impulse);
    }
}
