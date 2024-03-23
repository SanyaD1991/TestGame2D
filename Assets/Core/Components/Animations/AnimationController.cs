using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Components.Animations
{
    [RequireComponent(typeof(Animation))]
    public class AnimationController : MonoBehaviour
    {

        private Animation _animation;

        private void Awake()
        {
            _animation = GetComponent<Animation>();
        }
       
        public void Play(string name)
        {
            _animation.Play(name);
        }
    }
}
