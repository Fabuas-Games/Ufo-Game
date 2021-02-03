using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFuel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Ufo"))
        {
            inputislemleri.fuelAmount = 10000;
            Destroy(gameObject);
        }
    }
}
