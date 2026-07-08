using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum Axes
    {
        MouseXandY,
        MouseX,
        MouseY
    }

    public Axes currentAxes = Axes.MouseXandY;

    public float sensitivity = 9f;

    public Vector2 clampVert = new(-45f, 45f);

    private float _rotationX = 0;

    private void Update()
    {
        if (currentAxes == Axes.MouseX)
        {
            transform.Rotate(0f, Input.GetAxis("Mouse X") * sensitivity, 0f);
        }
        else if (currentAxes == Axes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
            _rotationX = Mathf.Clamp(_rotationX, clampVert.x, clampVert.y);

            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY);
        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
            _rotationX = Mathf.Clamp(_rotationX, clampVert.x, clampVert.y);

            float delta = Input.GetAxis("Mouse X") * sensitivity;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY);
        }
    }
}
