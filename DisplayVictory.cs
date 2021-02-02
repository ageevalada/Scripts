using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;


namespace Labyrinth
{
    public sealed class DisplayVictory
    {
        private Text _finishLabel;
        private Button _restartButton;
        private int _bonuses;

        public DisplayVictory(GameObject endGame, Button button)
        {
            _finishLabel = endGame.GetComponentInChildren<Text>();
            _finishLabel.text = String.Empty;
            _restartButton = button;
        }
        public void GameOver()
        {
            _finishLabel.text = $"Вы победили. Вы набрали {_bonuses}";
            _restartButton.GetComponentInChildren<Text>().text = "Еще раз";
            _restartButton.gameObject.SetActive(true);
        }
        public void CountBonuses(int value)
        {
            _bonuses = value;
        }

    }
}
