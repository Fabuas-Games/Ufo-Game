using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using TMPro;
using UnityEngine.UI;

public class inputislemleri : MonoBehaviour
{
    [SerializeField] SpriteRenderer playerImage;
    [SerializeField] TMP_Text playerNameText;
    [SerializeField] float moveSpeed;


    private const int V = 90;
    public Quaternion target;
    private Rigidbody2D rb;
    private float dirX, dirY, dirZ;
    ParticleSystem parct;

    public float yRotation;
    float smooth = 5.0f;
    float tiltAngle = -30.0f;
    float energy = 3000f;
    public GameObject gameOverPanel;
    public GameObject joyistikKapat;

    /*    [SerializeField]
        private Text fuelMeter;
        private int fuelAmount;*/

    private float jumpForce = 40f;
    private bool engineIsOn;

    [SerializeField]
    private Text fuelMeter;
    public static int fuelAmount;

    private bool engineIsON;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        /* moveSpeed = 15f;*/
        // parct = Ge1tComponentInChildren<ParticleSystem>().
        //GetComponentInChildren<ParticleSystem>(Effector2D).e
        ChangePlayerSkin();
        /*fuelAmount = 1000;*/

        Time.timeScale = 1;
        engineIsOn = false;
        rb = GetComponent<Rigidbody2D>();

        fuelAmount = 10000;
    }
    void ChangePlayerSkin()
    {
        Character character = GameDataManager.GetSelectedCharacter();
        if (character.image != null)
        {
            engineIsON = false;
            playerImage.sprite = character.image;
            playerNameText.text = character.name;
            moveSpeed = character.speed;
        }
    }




    void Update()
    {

        dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
        dirY = CrossPlatformInputManager.GetAxis("Vertical") * moveSpeed;
        dirZ = CrossPlatformInputManager.GetAxis("Horizontal") * tiltAngle;
        // dirZ = CrossPlatformInputManager.GetAxis("Horizontal") ;

            fuelMeter.text = "Fuel: " + fuelAmount.ToString() + "%";
                if (fuelAmount == 0)
                {
                    engineIsON = false;
                    gameOverPanel.SetActive(true);
                    joyistikKapat.SetActive(false);
                }


        Quaternion target = Quaternion.Euler(dirX, 0, dirZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        if (CrossPlatformInputManager.GetAxis("Horizontal") < 0)
        {
            
            foreach (Transform child in transform)
            {
                engineIsON = true;
                StartCoroutine(BurnFuel());


                if (child.CompareTag("sol"))
                    child.GetComponent<ParticleSystem>().Stop();

                if (child.CompareTag("sag"))
                    child.GetComponent<ParticleSystem>().Play();
                //child.GetComponent<ParticleSystem>().Stop();    // stop children to emit particles and destroy them in 3 seconds
                // Destroy(child.gameObject);                  //
            }



        }
        else if (CrossPlatformInputManager.GetAxis("Horizontal") > 0)
        {

            
            foreach (Transform child in transform)
            {
                engineIsON = true;
                StartCoroutine(BurnFuel());
                // yRotation = 90;
                // target = Quaternion.Euler(0, 0, yRotation);
                if (child.CompareTag("sol"))
                    child.GetComponent<ParticleSystem>().Play();

                if (child.CompareTag("sag"))
                    child.GetComponent<ParticleSystem>().Stop();
            }
        }
        else
        {
            foreach (Transform child in transform)
            {
                if (child.CompareTag("sag"))
                    child.GetComponent<ParticleSystem>().Play();    // stop children to emit particles and destroy them in 3 seconds
                if (child.CompareTag("sol"))
                    child.GetComponent<ParticleSystem>().Play();                                             // Destroy(child.gameObject, 3f);                  //
            }





        }



    }
    private IEnumerator BurnFuel()
    {
        for(int i = fuelAmount; i >= 1; i++)
        {
            fuelAmount -= 1;
            yield return new WaitForSeconds(100000);
            if(CrossPlatformInputManager.GetAxis("Horizontal") > 0 || CrossPlatformInputManager.GetAxis("Vertical") > 0)
            {
                break;
            }

        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, dirY);

        switch (engineIsOn)
        {
            case true:
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
                break;
            case false:
                rb.AddForce(new Vector2(0f, 0f), ForceMode2D.Force);
                break;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        string tag = other.collider.tag;

        if (tag.Equals("coin"))
        {
            //Add Coins 
            GameDataManager.AddCoins(32);

            // Cheating (while moving hold key "C" to get extra coins) 
#if UNITY_EDITOR
            if (Input.GetKey(KeyCode.C))
                GameDataManager.AddCoins(179);
#endif

            GameSharedUI.Instance.UpdateCoinsUIText();

            Destroy(other.gameObject);
        }
    }

}



