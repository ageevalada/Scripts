using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;


namespace Labyrinth
{
    public sealed class Reference
    {
        private PlayerBall _playerBall;
        private Camera _mainCamera;
        private GameObject _bonuse;
        private GameObject _endGame;
        private GameObject _victory;
        private Canvas _canvas;
        private Button _restartButton; 


        public PlayerBall PlayerBall
        {
            get
            {
                if (_playerBall == null)
                {
                    var gameObject = Resources.Load<PlayerBall>("Player/PlayerBall");              
                    _playerBall = Object.Instantiate(gameObject);
                }
                return _playerBall;
            }
        }

        public Camera MainCamera
        {
            get
            {
                if (_mainCamera == null)
                {
                    _mainCamera = Camera.main; 
                }
                return _mainCamera;
            }
        }
        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas;
            }
        }

        public GameObject Bonuse
        {
            get
            {
                if (_bonuse == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/Bonuse");
                    _bonuse = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _bonuse;
            }
        }

        public GameObject EndGame
        {
            get
            {
                if (_endGame == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/EndGame");
                    _endGame = Object.Instantiate(gameObject, Canvas.transform);
                }
                
                return _endGame;
            }
        }

        public GameObject Victory
        {
            get
            {
                if (_victory == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/Victory");
                    _victory = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _victory;
            }
        }

        public Button RestartButton
        {
            get
            {
                if (_restartButton == null)
                {
                    var gameObject = Resources.Load<Button>("UI/RestartButton");
                    _restartButton = Object.Instantiate(gameObject, Canvas.transform);
                }
                return _restartButton;
            }
        }
    }
}
