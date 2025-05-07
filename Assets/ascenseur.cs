using UnityEngine;
using DG.Tweening.Plugins.Options;
using DG.Tweening;
using DG.Tweening.Core;
public class ascenseur : MonoBehaviour
{
    public float pointf = -40;
    public float dur�e = 3f;
    public int nbLoop = -1;
    public LoopType loopType;
    public Ease easetruc;

    private void Oncollisionenter(Collision2D collision)
    {
        transform.DOMoveY(pointf, dur�e)
        .SetEase(easetruc)
        .SetLoops(nbLoop, loopType);
    }
}
