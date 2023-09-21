using UnityEngine;

    public class DestroyAllUnits : MonoBehaviour
    {
        public void DestroyAllExistingUnits()
        {
            var units = FindObjectsOfType<Unit>();

            foreach (var unit in units)
            {
                Destroy(unit.gameObject);
            }
        }
    }