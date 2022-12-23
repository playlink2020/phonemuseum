namespace ChristopherCreates.DragQueen2D
{
	/// <summary>
	/// The type of drag action to perform.
	/// </summary>
	public enum Drag
	{
		Position,
		Rotation
	}


	/// <summary>
	/// The type of lerp return to use when lacking a valid drop target.
	/// </summary>
	public enum Lerp
	{
		Speed,
		Time
	}


	/// <summary>
	/// The position to start target casting from.
	/// </summary>
	public enum Origin
	{
		GameObjectCenter,
		ColliderCenter,
		ColliderEdge
	}


	/// <summary>
	/// The target(s) to send a message to.
	/// </summary>
	public enum Recipient
	{
		Target,
		Self,
		Both
	}


	/// <summary>
	/// The type of return to use when lacking a valid drop target.
	/// </summary>
	public enum Return
	{
		Snap,
		Lerp,
		Message
	}


	/// <summary>
	/// The shape to use when casting for targets.
	/// </summary>
	public enum Shape
	{
		Box,
		Circle,
		Ray
	}


	/// <summary>
	/// The type of size for the shape used to cast for targets.
	/// </summary>
	public enum Size
	{
		Normalized,
		Fixed
	}


	/// <summary>
	/// The space used to measure a given property.
	/// </summary>
	public enum Space
	{
		Screen,
		World,
		Viewport
	}


	/// <summary>
	/// The type of value to send with a message.
	/// </summary>
	public enum ValueType
	{
		SelfGameObject,
		AnimationCurve,
		Bool,
		Bounds,
		Color,
		Double,
		Float,
		Int,
		Long,
		Rect,
		String,
		Vector2,
		Vector3,
		Vector4
	}
}
