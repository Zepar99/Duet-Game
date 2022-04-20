using UnityEngine;
using DG.Tweening;

public class ObstacleRotation : MonoBehaviour
{
    [SerializeField] float rotationDuration;
    // Start is called before the first frame update
    void Start()
    {
        transform
            .DORotate(new Vector3(0, 0, 1f), rotationDuration)
            .SetLoops(-1, LoopType.Incremental);
    }
}
