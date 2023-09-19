using UnityEngine;

    public interface ITrampolineable
    {
        bool CanJump(GameObject caster);
        void Jump (float strength, GameObject caster);
    }