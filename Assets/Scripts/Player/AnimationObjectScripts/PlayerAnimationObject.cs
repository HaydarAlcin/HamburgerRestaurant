using UnityEngine;

public class PlayerAnimationObject : MonoBehaviour
{
    [SerializeField] private PlayerAction playerAction;
    public void TakeAnimationStarted()
    {
        AnimationSignals.Instance.onTakeItemAnimationEvent?.Invoke();
        playerAction.SetRelax(true);

    }

    public void KnifeSliced()
    {
        CoreGameSignals.Instance.OnItemSliced?.Invoke();
        playerAction.SetRelax(true);
    }
}
