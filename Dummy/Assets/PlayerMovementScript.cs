using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{

    PlayerInput playerInput;
    InputAction moveAction;

    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();
        Vector3 move = transform.right * direction.x + transform.forward * direction.y;
        transform.position += move * speed * Time.deltaTime;
    }
}
