using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UnityEngine;

public class DBManager : MonoBehaviour
{
	private static string dbPath;
	
	void Start ()
	{
		dbPath = "URI = file://" + Application.dataPath + "/Highscores.sqlite";
		GetScores();
	}

	public static void GetScores()
	{
		using (IDbConnection dbConnection = new SqlConnection(dbPath))
		{
			
			dbConnection.Open();

			using (IDbCommand dbCommand = dbConnection.CreateCommand())
			{
				
				string sqlQuery = "select * from HS";
		
				dbCommand.CommandText = sqlQuery;

				using (IDataReader reader = dbCommand.ExecuteReader())
				{
					
					while (reader.Read())	
					{
						Debug.Log(reader.GetString(1) + " - " + reader.GetInt32(2));
					}
					
					dbConnection.Close();
					reader.Close();
				}
		
		
			}
	
		}
		

	}
}
