using System.Collections;
using UnityEngine;

public class Shard : MonoBehaviour
{
    public bool IsPickable { get; private set; } = false;


    [SerializeField]
    private float Force = 100;

    [SerializeField]
    private Rigidbody Rigidbody;


    private void Awake()
    {
        StartCoroutine(ApplyPickable());
    }

    private void Start()
    {
        Rigidbody.AddForce(RandomVector() * Force);
    }

    private IEnumerator ApplyPickable()
    {
        yield return new WaitForSeconds(1);

        IsPickable = true;
    }

    private static Vector3 RandomVector()
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(0.5f, 1f);
        float z = Random.Range(-1f, 1f);
        return new Vector3(x, y, z).normalized;
    }
}
