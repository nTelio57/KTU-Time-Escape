using UnityEngine;

public class PickupController : MonoBehaviour
{
    [SerializeField]
    private GameManager Manager;

    [SerializeField]
    private int PickupScore = 5;

    [SerializeField]
    private int ShardScore = 1;

    private int _pickupLayer;
    private int _shardLayer;

    [SerializeField]
    private AudioSource PickupAudio;

    private void Awake()
    {
        _pickupLayer = LayerMask.NameToLayer("Interactable");
        _shardLayer = LayerMask.NameToLayer("Shard");
    }

    private void OnTriggerEnter(Collider other)
    {
        var obj = other.gameObject;
        if (obj.layer == _pickupLayer)
        {
            PickupAudio.Play();
            var pickup = obj.GetComponent<PickupSplitter>();
            pickup.Split();
            Manager.Score += PickupScore;
            Manager.PickupCount++;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == _shardLayer)
        {
            var shard = other.gameObject.GetComponent<Shard>();
            if (shard.IsPickable)
            {
                PickupAudio.Play();
                Destroy(other.gameObject);
                Manager.Score += ShardScore;
                Manager.PickupCount++;
            }
        }
    }
}
