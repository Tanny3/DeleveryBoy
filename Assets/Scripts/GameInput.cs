using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Класс GameInput отвечает за обработку ввода от игрока.
// Он реализован как синглтон, чтобы к нему можно было легко обращаться из других скриптов.
public class GameInput : MonoBehaviour
{
    // Статическое свойство для доступа к экземпляру класса (паттерн Singleton)
    public static GameInput Instance { get; private set; }

    // Переменная для хранения экземпляра класса, созданного в Input System (генерируется автоматически)
    private PlayerInputActions playerInputActions;

    // Метод Awake вызывается при создании объекта. Здесь инициализируется система ввода.
    private void Awake()
    {
        // Устанавливаем текущий экземпляр как Instance
        Instance = this;

        // Создаём новый объект действий ввода
        playerInputActions = new PlayerInputActions();

        // Включаем действия ввода, чтобы начать принимать ввод от игрока
        playerInputActions.Enable();
    }

    // Метод для получения вектора движения игрока (например, с клавиатуры или геймпада)
    public Vector2 GetMovementVector()
    {
        // Считываем текущее значение ввода для движения из схемы действий
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        // Возвращаем вектор движения (например, (1, 0) — движение вправо)
        return inputVector;
    }

    // Получаем позицию мыши на экране
    public Vector3 GetMousePosition()
    {
        // Читаем текущую позицию мыши
        Vector3 mousePos = Mouse.current.position.ReadValue();

        // Возвращаем эту позицию
        return mousePos;
    }
}
