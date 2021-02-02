using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;


namespace Labyrinth
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        public PlayerType PlayerType = PlayerType.Ball;
        private ListExecuteObject _interactiveObject;
        private CameraController _cameraController;
        private InputController _inputController;
        private DisplayEndGame _displayEndGame;
        private DisplayBonuses _displayBonuses;
        private DisplayVictory _displayVictory;
        private int _countBonuses;

        private void Awake()
        {
            _interactiveObject = new ListExecuteObject();

            var _refernce = new Reference();

            PlayerBase player = null;
            if (PlayerType == PlayerType.Ball)
            {
                player = _refernce.PlayerBall;
            }

            _cameraController = new CameraController(player.transform, _refernce.MainCamera.transform);
            _interactiveObject.AddExecuteObject(_cameraController);

            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                _inputController = new InputController(player);
                _interactiveObject.AddExecuteObject(_inputController);    
            }
            
            _displayEndGame = new DisplayEndGame(_refernce.EndGame, _refernce.RestartButton);
            _displayBonuses = new DisplayBonuses(_refernce.Bonuse);
            _displayVictory = new DisplayVictory(_refernce.Victory, _refernce.RestartButton);

            foreach(var obj in _interactiveObject)
            {
                if (obj is BadBonus badBonus)
                {
                    badBonus.OnCaughtPlayerChange += CaughtPlayer;
                    badBonus.OnCaughtPlayerChange += _displayEndGame.GameOver;
                }                
                if (obj is GoodBonus goodBonus)
                {
                    goodBonus.OnPointChange += AddBonus;
                }
                if (obj is TrapBonus trapBonus)
                {
                    trapBonus.OnPoint += AddForce;
                }
                if (obj is VictoryPosition victoryPosition)
                {
                    CaughtPlayer();
                    _displayVictory.GameOver();
                }
            }

            _refernce.RestartButton.onClick.AddListener(RestartGame);
            _refernce.RestartButton.gameObject.SetActive(false);
        }

        private void AddForce(float force, float upforce, float radius)
        {
            var ob = GameObject.FindGameObjectsWithTag("Player");
            var rigidbody = ob[0].GetComponent<Rigidbody>();
            var explosionPosition = ob[0].transform.position;
            rigidbody.AddExplosionForce(force, explosionPosition, radius, upforce, ForceMode.Impulse);
        }

        private void CaughtPlayer(string value, Color color)
        {
            Time.timeScale = 0.0f;
        }

        private void CaughtPlayer()
        {
            Time.timeScale = 0.0f;
        }

        private void AddBonus(int value)
        {
            _countBonuses += value;
            _displayBonuses.Display(_countBonuses);
            _displayVictory.CountBonuses(_countBonuses);
        }
        private void RestartGame()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1.0f;
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObject.Length; i++)
            {
                var interactiveObject = _interactiveObject[i];

                if (interactiveObject == null)
                {
                    continue;
                }
                interactiveObject.Execute();
            }
        }

        public void Dispose()
        {
            foreach (var obj in _interactiveObject)
            {
                if (obj is BadBonus badBonus)
                {
                    badBonus.OnCaughtPlayerChange -= CaughtPlayer;
                    badBonus.OnCaughtPlayerChange -= _displayEndGame.GameOver;
                }
                if (obj is GoodBonus goodBonus)
                {
                    goodBonus.OnPointChange -= AddBonus;
                }
                if (obj is TrapBonus trapBonus)
                {
                    trapBonus.OnPoint -= AddForce;
                }
            }
        }
    }

}
