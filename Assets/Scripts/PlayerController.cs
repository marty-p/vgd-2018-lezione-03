using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float speed = 3;
    public float jumpForce = 5;
    public bool isOnGround = true;
    private int scatoleRaccolte = 0;
    public Text scatoleText;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
        refreshScatoleRaccolte();
    }
	
	// Update is called once per frame
	void Update () {


	}

    void FixedUpdate()
    {


        float movementH = Input.GetAxis("Horizontal");
        float movementV = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(movementH, 0.0f, movementV);

        rb.AddForce(movement*speed);

        float jump = 0.0f;

        if (isOnGround){

            jump = Input.GetAxis("Jump");
            Vector3 jumpVector = new Vector3(0f, jump*jumpForce, 0f);
            rb.AddForce(jumpVector, ForceMode.Impulse);
        }



    }

    /*private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }*/

    private void OnCollisionStay(Collision collision)
    {
        isOnGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isOnGround = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("collected");
        if (other.gameObject.CompareTag("Collectible"))
        {
            other.gameObject.SetActive(false);
            // Destroy(other.gameObject);
            scatoleRaccolte += 1;
            Debug.Log("Scatole raccolte: " + scatoleRaccolte);
            refreshScatoleRaccolte();
        }
    }
    private void refreshScatoleRaccolte()
    {
        scatoleText.text = "Scatole raccolte: " + scatoleRaccolte;
    }
}
