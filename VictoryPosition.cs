using System;
using UnityEngine;
using static UnityEngine.Random;


namespace Labyrinth
{
    public sealed class VictoryPosition : InteractiveObject, IFlicker
    {
        private Material _material;
        //public event Action<int> OnPointChange = delegate (int i) { };

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
        }

        public override void Execute()
        {
            
        }
        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,
                Mathf.PingPong(Time.time, 1.0f));
        }
        protected override void Interaction()
        {
            throw new NotImplementedException();
        }
    }
}
