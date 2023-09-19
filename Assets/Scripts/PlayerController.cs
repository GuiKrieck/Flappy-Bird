using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody thisRigidBody;
    public float jumpForce = 10f;
    public float jumpInterval = 0.5f;
    public float jumpCooldown = 0f;


    // Start is called before the first frame update
    void Start()
    {
        //get the object's rigidbody reference so we can apply force to it
        thisRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // update cooldown
        jumpCooldown -= Time.deltaTime;
        bool isGameActive = GameManager.Instance.isGameActive();
        //check if jumpcooldown is equal or less than 0 AND the variable isGameOver is true; 
        bool canJump = jumpCooldown <= 0 && isGameActive;

        //if it is then JUMP.
        if (canJump)
        {
            bool jumpInput = Input.GetKey(KeyCode.Space);
            if (jumpInput)
            {
                Jump();
            }
        }

        //this will toggle the option useGravity in accordance to the value of isGameActive variable.
        thisRigidBody.useGravity = isGameActive;
                  
    }
    private void OnCollisionEnter(Collision collision)
    {
        OnCustomCollisionEnter(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        OnCustomCollisionEnter(other.gameObject);
    }

    private void OnCustomCollisionEnter(GameObject other)
    {
        bool isSensor = other.CompareTag("Sensor");

        if (isSensor)
        {
            GameManager.Instance.Score++;
            GameManager.Instance.scoreToRaiseDifficultyController++;
            Debug.Log("Score = " + GameManager.Instance.Score);
        }
        else
        {
            thisRigidBody.velocity = Vector3.zero;
            GameManager.Instance.EndGame();
        }
    }
    private void Jump()
    {
        //reset inteval
        jumpCooldown = jumpInterval;

        //this will reset the speed 
        thisRigidBody.velocity = Vector3.zero;


        //apply force to the rigid body
        thisRigidBody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }
}
