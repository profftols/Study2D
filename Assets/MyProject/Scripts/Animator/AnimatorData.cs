using UnityEngine;

public class AnimatorData : MonoBehaviour
{
    public class Player
    {
        public static readonly int Speed = Animator.StringToHash(nameof(Speed));
    }

    public class Enemy
    {
        public static readonly int Speed = Animator.StringToHash(nameof(Speed));
    }
}
