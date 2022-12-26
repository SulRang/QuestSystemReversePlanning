using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.Data.SqlClient;

public class DBController : MonoBehaviour
{
    static string ipAddress = "127.0.0.1";
    static string db_id = "root";
    static string db_pw = "0000";
    static string db_name = "quest";
    SqlConnection sqlCon;
    List<DBData> dbDatas = new List<DBData>();

    private void Awake()
    {
        sqlCon = new SqlConnection("Server=127.0.0.1; Database=quest; uid=root; pwd=0000");
        
        try
        {
            sqlCon.Open();
        }
        catch(System.Exception e)
        {
            Debug.Log(e.ToString());
        }
        Debug.Log(sqlCon.State);
        sqlCon.Close();
        PackDB();
    }

    private DataSet SelectDB()
    {
        sqlCon.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlCon;
        cmd.CommandText = "SELECT * FROM dbo.basic";

        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
        DataSet data = new DataSet();
        dataAdapter.Fill(data, "dbo.basic");

        sqlCon.Close();

        return data;
    }

    private void PackDB()
    {
        DataSet datas = SelectDB();
        for (int i = 0; i < datas.Tables[0].Rows.Count; i++)
        {
            dbDatas.Add(new DBData(datas.Tables[0].Rows[i].ItemArray));
        }
        Debug.Log(dbDatas.Count);
    }

    public List<DBData> GetDBDatas()
    {
        return dbDatas;
    }

}
