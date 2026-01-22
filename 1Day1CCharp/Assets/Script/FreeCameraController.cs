using UnityEngine;

public class FreeCameraController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float fastSpeed = 15f;

    [Header("Mouse Look")]
    public float mouseSensitivity = 2f;
    public float maxYAngle = 80f;

    bool isActive = false;
    float rotX;
    float rotY;

    void Start()
    {
        var euler = transform.eulerAngles;
        rotX = euler.y;
        rotY = euler.x;
    }

    void Update()
    {
        if (!isActive)
            return;

        Look();
        Move();
    }

    void Look()
    {
        rotX += Input.GetAxis("Mouse X") * mouseSensitivity * 100f * Time.deltaTime;
        rotY -= Input.GetAxis("Mouse Y") * mouseSensitivity * 100f * Time.deltaTime;
        rotY = Mathf.Clamp(rotY, -maxYAngle, maxYAngle);

        transform.rotation = Quaternion.Euler(rotY, rotX, 0f);
    }

    void Move()
    {
        float speed = Input.GetKey(KeyCode.LeftShift) ? fastSpeed : moveSpeed;

        float h = Input.GetAxis("Horizontal"); // A/D
        float v = Input.GetAxis("Vertical");   // W/S
        float y = 0f;

        if (Input.GetKey(KeyCode.E)) y += 1f;
        if (Input.GetKey(KeyCode.Q)) y -= 1f;

        Vector3 dir = new Vector3(h, y, v);
        transform.Translate(dir * speed * Time.deltaTime, Space.Self);
    }

    public void Toggle()
    {
        isActive = !isActive;

        Cursor.lockState = isActive ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !isActive;
    }
}
