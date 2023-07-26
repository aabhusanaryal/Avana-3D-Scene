using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private Vector3 playerVelocity;
    public bool isGrounded = false;

    [SerializeField]
    public CharacterController controller;
    public float speed = 5.0f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;    // Start is called before the first frame update
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        Debug.Log("wtf");
        Debug.Log(controller);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;   
    }

    public void ProcessMove(Vector2 input)
    {
        //controller = GetComponent<CharacterController>();
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        //print(controller);
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y<0)
        {
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded) { 
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            Debug.Log("jmped");
        }
    }

    
}
