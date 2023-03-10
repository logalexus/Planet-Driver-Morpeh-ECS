using DG.Tweening;
using UnityEngine;

namespace Codebase.Animation
{
    public class X2Anim : MonoBehaviour
    {
        private void Start()
        {
            transform.DOScale(1.3f, 0.3f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutQuart);
        }

    }
}
