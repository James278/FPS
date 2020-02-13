using Photon.Pun;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PhotonView PV;
<<<<<<< HEAD
    private CharacterController myCC;
    public float movementSpeed;
    public float rotationSpeed;
    
=======
    public float speed = 5f;
    public float jumpForce = 10f;
    private CharacterController _characterController;
    private Vector3 _moveDirection;
    private float _gravity = 20f;
    private float _verticalVelocity;
>>>>>>> acfdab510cc4a08febad949174d9a00df29641f3

    private void Start()
    {
        PV = GetComponent<PhotonView>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
         BasicMovement();
            BasicRotation();
        /* if (PV.IsMine) //REPLACE BEFORE COMMITING
        {
<<<<<<< HEAD
            BasicMovement();
            BasicRotation();
        } */
=======
            Movement();
        }
>>>>>>> acfdab510cc4a08febad949174d9a00df29641f3
    }
    private void Movement()
    {
<<<<<<< HEAD
        if (Input.GetKey(KeyCode.W))
        {
           
            myCC.Move(transform.forward * Time.deltaTime * movementSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            myCC.Move(-transform.right * Time.deltaTime * movementSpeed);//please pay attention to the negative sign in front of the transform.
        }
        if (Input.GetKey(KeyCode.D))
=======
        _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        _moveDirection = transform.TransformDirection(_moveDirection);
        _moveDirection *= speed * Time.deltaTime;

        ApplyGravity();

        _characterController.Move(_moveDirection);
    }

    private void ApplyGravity()
    {
        if (_characterController.isGrounded)
>>>>>>> acfdab510cc4a08febad949174d9a00df29641f3
        {
            _verticalVelocity -= _gravity * Time.deltaTime;
            PlayerJump();
        }
        else
        {
            _verticalVelocity -= _gravity * Time.deltaTime;
        }

<<<<<<< HEAD
=======
        _moveDirection.y = _verticalVelocity * Time.deltaTime;
>>>>>>> acfdab510cc4a08febad949174d9a00df29641f3
    }

    private void PlayerJump()
    {
        if (_characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _verticalVelocity = jumpForce;
        }
    }
}
