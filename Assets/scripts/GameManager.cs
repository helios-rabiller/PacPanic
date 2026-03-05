using System.Dynamic;
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
		NewGame();
	}

	private void Update()
	{
		if (this.Input.anyKeyDown)
		{
			NewGame();
		}


	}
	private void NewGame()
	{
		SetScore(0);
		SetLives(3);
		NewRound(0);

	}
	private void NewRound(int round )
	{
		foreach(Transform pellet in this.pellets){
			pellet.gameObject.SetActive(true);
		}
		ResetState();
		
	}

	private void ResetState()
	{
		for (int i = 0; i < this.ghosts.Length; i++){
			// this.ghosts.gameObject.SetActive(true);
		}
		
		this.pacman.gameObject.SetActive(true);
	}

	private void GameOver()
	{
		for (int i = 0; i < this.ghosts.Length; i++){
			//this.ghosts.gameObject.SetActive(false);
		}
		
		this.pacman.gameObject.SetActive(false);
	}
	private void SetScore(int score)
	{
		this.score = score;
	}

	private void SetLives(int lives)
	{
		this.lives = lives;
	}
	public void GhostEaten()
	{
		//SetScore(this.score +ghosts.points);
	}
	public void PacmanEaten()
	{
		this.pacman.gameObject.SetActive(false);
		SetLives(this.lives-1);

		if (this.lives > 0)
		{
			Invoke(nameof(ResetState), 2.0f);
		} else {
			GameOver();
		}

	}
}