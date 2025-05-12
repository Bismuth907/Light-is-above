using UnityEngine;
using DG.Tweening;
public class verticalscript : MonoBehaviour
{
    public float pointf = -40;
    public float durée = 3f;
    public int nbLoop = -1;
    public LoopType loopType;
    public Ease easetruc;

    private void Start()
    {
        transform.DOMoveY(pointf, durée)
        .SetEase(easetruc)
        .SetLoops(nbLoop, loopType);
    }
}
