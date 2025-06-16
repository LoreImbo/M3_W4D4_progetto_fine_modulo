using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private GameObject _weaponPrefab;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Transform weaponHolder = other.transform.Find("WeaponHolder");

            if (weaponHolder.childCount > 0)
            {
                foreach (Transform child in weaponHolder)
                {
                    Destroy(child.gameObject);
                }
            }

            Instantiate(_weaponPrefab, weaponHolder.position, Quaternion.identity, weaponHolder);

            Destroy(gameObject);
        }
    }
}

