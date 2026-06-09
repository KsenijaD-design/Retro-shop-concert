using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("Настройки")]
    [SerializeField] private float mouseSensitivity = 120f;
    [SerializeField] private float verticalLookLimit = 90f;

    [Header("Ссылки")]
    [SerializeField] private Transform playerBody;      // сюда перетащи корневой объект игрока
    [SerializeField] private Transform cameraTransform; // сюда перетащи камеру

    private float xRotation = 0f; // текущий наклон камеры вверх/вниз

    void Start()
    {
        // Прячем курсор и фиксируем его в центре экрана
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (playerBody == null)
            playerBody = transform; // если скрипт висит на игроке

        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // Получаем движение мыши
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Поворот вверх/вниз (камера)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -verticalLookLimit, verticalLookLimit);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Поворот влево/вправо (тело игрока)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}