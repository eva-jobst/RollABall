using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class cube : MonoBehaviour


{

    PlayerControls controls;

    Vector2 move;



    private void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.Grow.performed += ctx => Grow();
        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;
        controls.Gameplay.Antigrow.performed += ctx => Antigrow();
    }

    void Grow()
    {
        transform.localScale *= 1.1f;
    }

    void Antigrow()

    {
        transform.localScale /= 1.1f;
    }


    void Update()
    {
        Vector2 m = new Vector2(move.x, move.y) * Time.deltaTime;
        transform.Translate(m, Space.World);
    }


    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
} 