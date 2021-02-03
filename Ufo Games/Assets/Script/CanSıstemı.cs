using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanSıstemı : MonoBehaviour
{
    public GameObject can1,can2,can3;
    public static int can;
    // Start is called before the first frame update

    public static bool gameOver;

    public GameObject gameOverPanel;
    public GameObject joyistikKapat;
    void Start()
    {
        gameOver = false;
        can = 3;
        can1.gameObject.SetActive(true);
        can2.gameObject.SetActive(true);
        can3.gameObject.SetActive(true);
/*      oyunbıttı.gameObject.SetActive(false);*/
    }

    // Update is called once per frame
    void Update()
    {
       if (can > 3)
            can = 3;

        switch (can)
        {
            case 3:
                can1.gameObject.SetActive(true);
                can2.gameObject.SetActive(true);
                can3.gameObject.SetActive(true);
                Debug.Log("Şu Anda Canın Full");
                break;
            case 2:
                can1.gameObject.SetActive(true);
                can2.gameObject.SetActive(true);
                can3.gameObject.SetActive(false);
                Debug.Log("Şu Anda Canın azaldı 2");
                break;
            case 1:
                can1.gameObject.SetActive(true);
                can2.gameObject.SetActive(false);
                can3.gameObject.SetActive(false);
                Debug.Log("Şu Anda Canın azaldı 1");
                break;
            case 0:
                can1.gameObject.SetActive(false);
                can2.gameObject.SetActive(false);
                can3.gameObject.SetActive(false);

                gameOver = true;
                gameOverPanel.SetActive(true);
                joyistikKapat.SetActive(false);
                Debug.Log("Şu Anda Öldün");
                break;
        }

       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Nesnler ile etkileşim var.");

        if (other.collider.CompareTag("Zemin"))
        {
            
        }
    }

}
