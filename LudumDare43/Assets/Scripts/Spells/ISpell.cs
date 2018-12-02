using UnityEngine;

public abstract class ISpell : MonoBehaviour
{
	public int cooldown { get; set; }

	abstract public void Execute();
}
