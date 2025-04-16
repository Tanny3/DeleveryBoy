using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    // статическое свойство для доступа к единственному экземпляру класса GameInput
    // реализует паттерн Singleton, гарантируя единственность экземпляра
    public static GameInput Instance { get; private set; }

    // экземпляр класса PlayerInputActions, сгенерированного Input System
    // содержит все действия (actions) и привязки ввода, определённые в Input Actions
    private PlayerInputActions playerInputActions;


    // 1. присваивает текущий экземпляр статическому свойству Instance
    //    (это делает объект доступным из любого места кода через GameInput.Instance)
    // 2. создаёт новый экземпляр PlayerInputActions - это инициализирует систему ввода
    // 3. включает систему ввода вызовом Enable(), после чего можно получать ввод от игрока
    private void Awake()
    {
        Instance = this;
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
    }

    // возвращает направление движения игрока (wasd/джойстик) в виде vector2 (x и y от -1 до 1)
    public Vector2 GetMovementVector()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        return inputVector;
    }

    // возвращает текущие координаты мыши на экране в пикселях (vector3, но z = 0)
    public Vector3 GetMousePosition()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        return mousePos;
    }
}
