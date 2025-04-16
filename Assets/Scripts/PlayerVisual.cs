using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// управляет визуальным представлением игрока: анимациями и поворотом спрайта
public class PlayerVisual : MonoBehaviour
{
    private Animator animator;              // компонент для управления анимациями
    private SpriteRenderer spriteRenderer;  // компонент для отображения спрайта

    private const string IS_RUNNING = "IsRunning"; // параметр аниматора для бега

    private void Awake()
    {
        // получаем необходимые компоненты при инициализации
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // обновляем состояние анимации бега каждый кадр
        animator.SetBool(IS_RUNNING, Player.instance.IsRunning());

        // корректируем направление взгляда персонажа
        AdjustPlayerFacingDirection();
    }

    // изменяет направление взгляда персонажа в зависимости от позиции мыши
    private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePos = GameInput.instance.GetMousePosition();
        Vector3 playerPosition = Player.instance.GetPlayerScreenPosition();

        // если курсор слева от персонажа - поворачиваем спрайт
        spriteRenderer.flipX = mousePos.x < playerPosition.x;
    }
}
