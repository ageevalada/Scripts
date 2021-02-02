using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


namespace Labyrinth
{
    public sealed class DisplayBonuses
    {
        private Text _bonusLabel;

        public DisplayBonuses(GameObject bonus)
        {
            _bonusLabel = bonus.GetComponentInChildren<Text>();
            _bonusLabel.text = String.Empty;
        }
        public void Display(int value)
        {
            _bonusLabel.text = $"Вы набрали {value}";
        }
    }
}
