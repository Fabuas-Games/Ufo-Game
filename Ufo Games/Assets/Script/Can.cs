using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other)
    {
        CanSıstemı.can += 1;
        this.gameObject.SetActive(false);
        Debug.Log("Can Sistemi İşe Yarıyor");

    }


}
