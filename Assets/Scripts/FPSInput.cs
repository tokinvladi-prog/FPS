using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float speed = 6f;
    public float gravity = -9.8f;

    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        var movement = new Vector3(deltaX, 0f, deltaZ) * Time.deltaTime;
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;

        movement = transform.TransformDirection(movement);
        _characterController.Move(movement);
    }
}
