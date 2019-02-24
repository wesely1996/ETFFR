using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumberGenerator : MonoBehaviour
{
	public GameObject panel;
	public Text text, CC, IC;
	public Text textUser;
	public float speed = 1f, sec2t = 2f;

	private bool lockedKey = true;
	private int userNumber = 0, N = 0;
	private int round = 1, dig = 2;
	private int Correct = 0, Incorrect = 0;

	private float x, i, sec2timer;
	private bool T=false, a=true, s2t = false;

	private void Start()
	{
		panel.SetActive(false);
		x = 0f;
		i = Time.time;
		sec2timer = 0f;
	}

	// Update is called once per frame
	void Update()
	{

		if(Input.GetKeyDown(KeyCode.A) && a){

			a = false;
			Correct = 0;
			Incorrect = 0;
			CC.text = "0";
			IC.text = "0";
			GenerateNumber();
		}

		if (!lockedKey)
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				textUser.text += "1";
				userNumber = userNumber * 10 + 1;
			}
			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				textUser.text += "2";
				userNumber = userNumber * 10 + 2;
			}
			if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				textUser.text += "3";
				userNumber = userNumber * 10 + 3;
			}
			if (Input.GetKeyDown(KeyCode.Alpha4))
			{
				textUser.text += "4";
				userNumber = userNumber * 10 + 4;
			}
			if (Input.GetKeyDown(KeyCode.Alpha5))
			{
				textUser.text += "5";
				userNumber = userNumber * 10 + 5;
			}
			if (Input.GetKeyDown(KeyCode.Alpha6))
			{
				textUser.text += "6";
				userNumber = userNumber * 10 + 6;
			}
			if (Input.GetKeyDown(KeyCode.Alpha7))
			{
				textUser.text += "7";
				userNumber = userNumber * 10 + 7;
			}
			if (Input.GetKeyDown(KeyCode.Alpha8))
			{
				textUser.text += "8";
				userNumber = userNumber * 10 + 8;
			}
			if (Input.GetKeyDown(KeyCode.Alpha9))
			{
				textUser.text += "9";
				userNumber = userNumber * 10 + 9;
			}
			if (Input.GetKeyDown(KeyCode.Alpha0))
			{
				textUser.text += "0";
				userNumber = userNumber * 10 + 0;
			}
			if (Input.GetKeyDown(KeyCode.Backspace))
			{
				textUser.text = textUser.text.Substring(0, textUser.text.Length - 1); ;
				userNumber = (int)(userNumber / 10);
				Debug.Log(userNumber);
			}
			if (Input.GetKeyDown(KeyCode.Return))
			{
				EndInput();
				textUser.text = "";
				panel.SetActive(false);
			}
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			SceneManager.LoadScene("Main");
		}

		if (i < x && T)
		{
			i += Time.deltaTime;
		}
		if( i >= x && T)
		{
			Timer();
			T = false;
		}

		if (Time.time >= sec2timer && s2t)
		{
			GenerateNumber();
			s2t = false;
		}
	}

	private void InputN(int N)
	{
		text.text = N.ToString();
	}

	private void GenerateNumber()
	{
		N = 0;
		text.text = "";
		text.color = Color.white;

		for (int i=1; i <= dig; i++)
		{
			int rand = Mathf.RoundToInt(Random.Range(-0.5f, 9.5f));

			if (rand == 10)
			{
				rand = 9;
			}

			if (rand == -1)
			{
				rand = 0;
			}

			N = N * 10 + rand;
			Debug.Log(N);
		}

		InputN(N);

		if (round % 20 == 0)
		{
			dig++;
			round++;
		}
		else
		{
			round++;
		}

		i = Time.time;
		x = speed + i;
		T = true;
	}

	private void Timer()
	{
		userNumber = 0;
		lockedKey = false;
		panel.SetActive(true);
		textUser.text = "";
	}

	private void EndInput()
	{
		Debug.Log("EndInput");
		lockedKey = true;
		if (N != userNumber)
		{
			Incorrect++;
			IC.text = Incorrect.ToString();
			text.text = "WRONG";
			text.color = Color.red;

		}
		else
		{
			Correct++;
			CC.text = Correct.ToString();
			text.text = "CORRECT";
			text.color = Color.green;
		}

		if (round < 100)
		{
			sec2timer = Time.time + sec2t;
			s2t = true;
		}
		else
		{
			text.text = "Correct: " + Correct + "\nIncorrect: " + Incorrect;
			a = true;
		}
	}
}
