using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    ParticleSystem explosionFx;
    int ballIndex;

    void Start()
    {
        explosionFx = transform.GetChild(0).GetComponent<ParticleSystem>();
        ballIndex = transform.position.x > 0 ? 1 : 0;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            GameManager.Instance.isGameOver = true;

            explosionFx.Play();
            Splatters.Instance.AddSplatter(collision.transform, collision.contacts[0].point, ballIndex);

            PlayerMovement.Instance.Restart();
        }
    }
}
