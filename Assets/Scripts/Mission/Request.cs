using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Request : MonoBehaviour
{
    // public static string[,] table_requests=new string[1,3];
    public static List<List<string>> table_requests=new List<List<string>>();
    public void AddRow(string request,string status,string reward){
        // table_requests[table_requests.GetLength(0)-1,0]=request;
        // table_requests[table_requests.GetLength(0)-1,1]=status;
        // table_requests[table_requests.GetLength(0)-1,2]=reward;
        // Debug.Log(table_requests.GetLength(0));
        List<string> tmp=new List<string>();
        tmp.Add(request);
        tmp.Add(status);
        tmp.Add(reward);
        table_requests.Add(tmp);
    }
    public void ModifyRow(int rowid,string status){
        // table_requests[rowid-1,1]=status;
    }
    public void show(){
        for(int i=0;i<table_requests.Count;i++){
            for(int j=0;j<table_requests[i].Count;j++){
                Debug.Log(table_requests[i][j]);
            }
        }
    }
    public void delete(){

    }

}
