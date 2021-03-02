using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Request : MonoBehaviour
{
    // public static string[,] table_requests=new string[1,3];
    public static List<List<string>> table_requests=new List<List<string>>();
    public static int[] tableRequestsHash=new int[100];
    public static int prevCount=0;
    public void AddRow(string request,string status,string reward,int val){
        List<string> tmp=new List<string>();
        tmp.Add(request);
        tmp.Add(status);
        tmp.Add(reward);
        tableRequestsHash[val]=1;
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
