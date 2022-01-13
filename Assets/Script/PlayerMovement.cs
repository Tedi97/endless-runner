using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float kecepatan, jumpForce;
    Rigidbody rb;

    private int desiredlane = 1;
    public float laneDistance = 3;
    //public float crouchingHeight = 1.25f;
    Animator anim;

    //Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredlane++;
            if (desiredlane == 3)
                desiredlane = 2;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredlane--;
            if (desiredlane == -1)
                desiredlane = 0;
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        //

        if (desiredlane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredlane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        transform.position = targetPosition;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }

    }

    void FixedUpdate()
    {
        Vector3 forwardmove = transform.forward * kecepatan * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardmove);

        bergerak();
        anim.SetBool("run", true);
    }
    // Update is called once per frame


    private void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        rb.AddForce(Vector3.up * jumpForce);
        anim.SetBool("jump", true);
        FindObjectOfType<AudioManager>().PlaySound("JumpSound");

    }

    private void bergerak()
    {
        anim.SetBool("jump", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            PlayerManager.gameOver = true;
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
            FindObjectOfType<AudioManager>().StopSound("MainSound");
        }
    }

}
