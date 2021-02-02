using System;
using UnityEngine.UI;
using UnityEngine;

namespace Labyrinth
{
    public sealed class DisplayEndGame
    {
        private Text _finishGameLabel;
        private Button _restartButton;

        public DisplayEndGame(GameObject endGame, Button button)
        {
            _finishGameLabel = endGame.GetComponentInChildren<Text>();
            _finishGameLabel.text = String.Empty;
            _restartButton = button;
        }
        public void GameOver(string name, Color color)
        {
            _finishGameLabel.text = $"Вы проиграли. Вас убил {name} {color} цвета";
            _restartButton.GetComponentInChildren<Text>().text = "Еще раз";
            _restartButton.gameObject.SetActive(true);
        }
    }
}
