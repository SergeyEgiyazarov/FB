using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ScrollBackground();
    }

    private void Update()
    {
        if (GameController.Instance.gameOver == true)
        {
            rb2D.velocity = Vector2.zero;
        }
    }

    private void ScrollBackground()
    {
        rb2D.velocity = new Vector2(GameController.Instance.scrollSpeed, 0);
    }
}
