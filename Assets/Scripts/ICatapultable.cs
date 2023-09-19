using UnityEngine;

    public interface ICatapultable
    {
        bool CanCatapult(GameObject caster);
        void Catapult (float strength, GameObject caster);
    }