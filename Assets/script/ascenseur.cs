using UnityEngine;
using DG.Tweening;
public class ascenseur : MonoBehaviour
{
    public float pointf = -40;
    public float durée = 3f;
    public int nbLoop = -1;
    public LoopType loopType;
    public Ease easetruc;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.DOMoveY(pointf, durée)
        .SetEase(easetruc)
        .SetLoops(nbLoop, loopType);
    }
}
