using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text _textPlayer1;
    public Text _textPlayer2;
    private int _scorePlayer1 = 0;
    private int _scorePlayer2 = 0;

    public void AddScorePlayer(int pPlayer)
    {
        if (pPlayer == 1)
        {
            _scorePlayer1++;
            _textPlayer1.text = _scorePlayer1.ToString();
        }
        if(pPlayer==2)
        {
            _scorePlayer2++;
            _textPlayer2.text = _scorePlayer2.ToString();
        }
    }

}
