using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт игрока: отвечает за движение и позицию на экране
public class Player : MonoBehaviour
{
    // Singleton — доступ к игроку из других скриптов
    public static Player Instance { get; private set; }

    // Скорость передвижения
    [SerializeField] private float movingSpeed = 10f;

    // Направление движения (от ввода)
    Vector2 inputVector;

    // Компонент физики 2D
    private Rigidbody2D rb;

    // Минимальное значение для определения, движется ли игрок
    private float minMovingSpeed = 0.1f;

    // Флаг: игрок бежит или стоит
    private bool isRunning = false;

    // При запуске: сохраняем ссылку на себя и на Rigidbody
    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    // Каждый кадр считываем ввод от игрока
    private void Update()
    {
        inputVector = GameInput.Instance.GetMovementVector();
    }

    // Физика — выполняется через равные промежутки времени
    private void FixedUpdate()
    {
        HandleMovement();
    }

    // Обработка передвижения
    private void HandleMovement()
    {
        // Перемещаем игрока с учётом времени и направления
        rb.MovePosition(rb.position + inputVector * (movingSpeed * Time.fixedDeltaTime));

        // Проверяем, есть ли движение (по x или y)
        if (Mathf.Abs(inputVector.x) > minMovingSpeed || Mathf.Abs(inputVector.y) > minMovingSpeed)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }

    // Проверка: движется ли игрок
    public bool IsRunning()
    {
        return isRunning;
    }

    // Получаем экранную позицию игрока (для UI и т.д.)
    public Vector3 GetPlayerScreenPosition()
    {
        Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return playerScreenPosition;
    }
}
