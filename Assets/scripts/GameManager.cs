using UnityEngine;

public class GameManager : MonoBehaviour
{
	public Ghost[] ghosts;
	public Pacman pacman;
	public Transform pellets;

	public int score { get; private set;}

	public int lives { get; private set;}

	private void Start()
	{
		NewGame()
	}

	private void NewGame()
	{
		SetScore(0);
		SetLives(3);
		NewRound();

	}

	private void SetScore(int score)
	{
		this.score = score;
	}

	private void SetLives(int lives)
	{
		this.lives = lives;
	}

	private void NewRound(int round )
	{
		foreach(Transform pellet in this.pellets){
			pellet.gameObject.SetActive(true);
		}
		ResetState()
	}

	private void ResetState()
	{
		for (int i = o; i < this.ghosts.Length; i++){
			this.ghosts.gameObject.SetActive(true);
		}
		
		this.pacman.gameObject.SetActive(true);
	}

}