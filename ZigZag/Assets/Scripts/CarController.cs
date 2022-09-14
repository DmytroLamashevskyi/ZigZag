using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameStarted)
        {
            Move();
            CheckInput();
        }
    }


    void Move()
    {
        transform.position += Time.deltaTime * moveSpeed * transform.forward;
    }

    private bool isFirstClick = true;
    void CheckInput()
    {
        if (isFirstClick)
        { 
            isFirstClick = false;
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Rotate();
        }

        if(transform.position.y < 0)
        {
            GameManager.instance.GameOver();
        }
    }

    bool isMovingLeft = true;
    /// <summary>
    /// Rotate car on 90 degree
    /// </summary>
    void Rotate()
    {
        transform.rotation = isMovingLeft ? Quaternion.Euler(0, 90, 0) : Quaternion.Euler(0, 0, 0);  
        isMovingLeft = !isMovingLeft;
    }
}
