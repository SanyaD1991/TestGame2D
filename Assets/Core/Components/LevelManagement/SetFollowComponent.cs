using Cinemachine;
using Core.Creatures.Player;
using UnityEngine;


namespace Core.Components.LevelManagement {

    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class SetFollowComponent : MonoBehaviour
    {
        private void Start()
        {
            var vCamera = GetComponent<CinemachineVirtualCamera>();
            vCamera.Follow = FindObjectOfType<Player>().transform;
        }
    }
}
