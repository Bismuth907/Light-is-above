using UnityEngine;
using DG.Tweening.Plugins.Options;
using DG.Tweening;
using DG.Tweening.Core;
public class horizontal : MonoBehaviour
{
    public float pointf = -40;
    public float dur�e = 3f;
    public int nbLoop = -1;
    public LoopType loopType;
    public Ease easetruc;

    private void Start()
    {
        transform.DOMoveX(pointf, dur�e)
        .SetEase(easetruc)
        .SetLoops(nbLoop, loopType);
    }
}

