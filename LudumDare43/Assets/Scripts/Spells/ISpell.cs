using UnityEngine;

public abstract class ISpell : MonoBehaviour
{
	abstract public int cooldown { get; set; }

	abstract public void Execute();
}
