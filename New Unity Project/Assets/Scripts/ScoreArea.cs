using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreArea : MonoBehaviour
{
    public ScoreController _controller;
    public int _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Ball>()!=null)
        {
            collision.gameObject.GetComponent<Ball>().ResetBall();
            _controller.AddScorePlayer(_player);
            SoundManager.PlaySound(SoundManager.Sound.Score);
        }
    }
}
