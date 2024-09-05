using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float coinRotation;
    [SerializeField] private Transform player;
    [SerializeField] private int coinValue = 1;
    [SerializeField] private AudioSource coinColSound;
    [SerializeField] private float attractionRange = 40f;
    [SerializeField] private float attractionSpeed = 50f;
    [SerializeField] private Vector3 minScale = new Vector3(0.1f,0.1f, 0.1f);

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        //CoinRotation();
        ComeToPlayer();
    }

    private void CoinRotation()
    {
        transform.Rotate(0f, 0f, coinRotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coinColSound.Play();
            StartCoroutine(DelayDestroy());
        }
    }

    private void ComeToPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= attractionRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, attractionSpeed);
            float scale = Mathf.Lerp(1f, 0f, 1f - (distanceToPlayer / attractionRange));
            transform.localScale = Vector3.Max(minScale, new Vector3(scale, scale, scale));
        }
    }

    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(0.2f);
        PlayerController.Instance.AddCoin(coinValue);
        Destroy(gameObject);
    }
}
