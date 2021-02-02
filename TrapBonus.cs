using System;
using UnityEngine;
using static UnityEngine.Random;

namespace Labyrinth
{
    internal class TrapBonus : InteractiveObject, IFlicker
    {
        private Material _material;
        private float _force;
        private float _upforce;
        private float _radius;
        public event Action<float, float, float> OnPoint = delegate (float i, float k, float j) { };

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _force = Range(1.0f, 10.0f);
            _upforce = Range(1.0f, 10.0f);
            _radius = Range(1.0f, 10.0f);
        }

        public override void Execute()
        {
            if (!IsInteractable) { return; }
            Flicker();
        }

        
        protected override void Interaction()
        {
            OnPoint.Invoke(_force, _upforce, _radius);
        }
        
        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,
                Mathf.PingPong(Time.time, 1.0f));
        }

    }
}
