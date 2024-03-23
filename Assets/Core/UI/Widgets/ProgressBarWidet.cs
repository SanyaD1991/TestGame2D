using UnityEngine;
using UnityEngine.UI;

namespace Core.UI.Widgets
{
    public class ProgressBarWidet : MonoBehaviour
    {
            [SerializeField] private Image _bar;

            public void SetProgress(float progress)
            {
                 _bar.fillAmount = progress;
            }
     }
}
