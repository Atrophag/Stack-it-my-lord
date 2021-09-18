using UnityEngine;

public static class Utils
{
	public static DraggableItem CastDraggableItem(GameObject gameObject)
	{
		return gameObject.GetComponent(typeof(DraggableItem)) as DraggableItem;
	}

	public static Rigidbody2D CastRigidBody(GameObject gameObject)
	{
		return gameObject.GetComponent<Rigidbody2D>();
	}
}