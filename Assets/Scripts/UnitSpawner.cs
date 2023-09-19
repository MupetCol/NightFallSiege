using Unity.Mathematics;
using UnityEngine;

    public class UnitSpawner : MonoBehaviour
    {
        [SerializeField] private Transform unitSpawnPoint;

        public void SpawnUnit(GameObject unit)
        {
            Instantiate(unit, unitSpawnPoint.position, quaternion.identity);
        }
    }