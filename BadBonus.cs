using System;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Labyrinth
{
    public class BadBonus : InteractiveObject, IFlay, IRotation
    {
        private float _lengthFlay;
        private float _speedRotation;

        public event Action<string, Color> OnCaughtPlayerChange = delegate(string str, Color color){ };

        private void Awake()
        {
            _lengthFlay = Random.Range(1.0f, 5.0f);
            _speedRotation = Random.Range(10.0f, 50.0f);
        }

        protected override void Interaction()
        {
            OnCaughtPlayerChange.Invoke(gameObject.name, _color);
        }
        public override void Execute()
        {
            if (!IsInteractable) { return; }
            Flay();
            Rotation();
        }

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
             Mathf.PingPong(Time.time, _lengthFlay),
             transform.localPosition.z);
        }

        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }
    }
}


