using UnityEngine;
using System.Collections;

public class ParticleColliderOnSystem : MonoBehaviour {

    public MosquitoMovement mm;


	void OnParticleCollision( GameObject other)
    {
        if ( other.Equals( GameObject.FindWithTag( "Player" ) ) )
        {
            mm.increaseMovementSpeedTemporarily();
       }
    }
}
