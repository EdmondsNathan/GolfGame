public class SaveObject_Level
{
	#region Fields
	public string Name;

	public int Score;

	public float RealTimeTaken;

	public float GameTimeTaken;

	public string GolfBall;

	public string Ability;
	#endregion

	#region Constructors
	public SaveObject_Level()
	{ }

	public SaveObject_Level(string name, int score, float realTimeTaken, float gameTimeTaken, string golfBall, string ability)
	{
		Name = name;
		Score = score;
		RealTimeTaken = realTimeTaken;
		GameTimeTaken = gameTimeTaken;
		GolfBall = golfBall;
		Ability = ability;
	}

	public SaveObject_Level(SO_SceneReference sceneReference, int score, float realTimeTaken, float gameTimeTaken, string golfBall, string ability) :
		this(sceneReference.Name, score, realTimeTaken, gameTimeTaken, golfBall, ability)
	{ }
	#endregion
}