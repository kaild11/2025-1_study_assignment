using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    const float CharacterJumpPower = 7f;
    const int MaxJump = 2;
    int RemainJump = 0;
    GameManager GM;

    void Awake()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        RemainJump = MaxJump;
    }

    void Update()
    {
        if (RemainJump > 0 && Input.GetMouseButtonDown(0))
        {
            RemainJump--;
            Jump(CharacterJumpPower);
        }
    }

    void Jump(float power)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
        GetComponent<Rigidbody2D>().AddForce(new Vector3(0, power, 0), ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Platform"))
        {
            RemainJump = MaxJump;
        }
        else if (col.gameObject.CompareTag("Obstacle"))
        {
            GM.GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Point"))
        {
            GM.GetPoint(1);
            Destroy(col.gameObject);
        }
    }
}
