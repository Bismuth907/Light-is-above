using UnityEngine;
using DG.Tweening;
public class verticalscript : MonoBehaviour
{
    public float pointf = -40;
    public float dur�e = 3f;
    public int nbLoop = -1;
    public LoopType loopType;
    public Ease easetruc;

    private void Start()
    {
        transform.DOMoveY(pointf, dur�e)
        .SetEase(easetruc)
        .SetLoops(nbLoop, loopType);
    }
}
