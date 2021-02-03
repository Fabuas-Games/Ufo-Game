using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuzak : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.collider.CompareTag("Player"))
        {
            CanSıstemı.can -= 1;
            Debug.Log("Tuzak Sistemi İşe Yarıyor");
        }
    }
}
