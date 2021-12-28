using UnityEngine;
using Random = UnityEngine.Random;

public class PickupSplitter : MonoBehaviour
{
    [SerializeField]
    private Transform Shard;

    [SerializeField]
    private int MinimumShards = 3;

    [SerializeField]
    private int MaximumShards = 6;

    public void Split()
    {
        int shardCount = Random.Range(MinimumShards, MaximumShards);

        for (int i = 0; i < shardCount; i++)
        {
            var shard = Instantiate(Shard);
            shard.localPosition = transform.localPosition;
        }

        Destroy(this.gameObject);
    }
}
