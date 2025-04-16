using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// основной класс управления игроком, отвечает за передвижение и состояние персонажа
public class Player : MonoBehaviour
{
    // статическая ссылка на игрока (шаблон singleton)
    public static Player instance { get; private set; }

    [SerializeField] 
    private float movingSpeed = 10f; // базовая скорость перемещения персонажа

    private Rigidbody2D rb; // компонент физики для 2D перемещения
    private Vector2 inputVector; // вектор направления ввода (клавиши/джойстик)
    private const float minMovingSpeed = 0.1f; // минимальное значение ввода для учета движения
    private bool isRunning = false; // флаг, указывающий что персонаж движется

    // инициализация компонентов при создании объекта
    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    // обновление ввода управления каждый кадр
    private void Update()
    {
        // получаем текущий вектор ввода из системы управления
        inputVector = GameInput.instance.GetMovementVector();
    }

    // обработка физики перемещения с фиксированным интервалом
    private void FixedUpdate()
    {
        HandleMovement();
    }

    // основной метод обработки перемещения персонажа
    private void HandleMovement()
    {
        // перемещаем персонажа с учетом физики
        rb.MovePosition(rb.position + inputVector * (movingSpeed * Time.fixedDeltaTime));

        // проверяем достаточно ли сильный ввод для учета движения
        isRunning = Mathf.Abs(inputVector.x) > minMovingSpeed || 
                  Mathf.Abs(inputVector.y) > minMovingSpeed;
    }

    // метод проверки состояния движения персонажа
    public bool IsRunning()
    {
        return isRunning;
    }

    // получение текущей позиции игрока в экранных координатах
    public Vector3 GetPlayerScreenPosition()
    {
        // конвертируем координаты в экранные
        return Camera.main.WorldToScreenPoint(transform.position);
    }
}
