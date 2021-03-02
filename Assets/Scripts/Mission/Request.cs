using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Request : MonoBehaviour
{
    // public static string[,] table_requests=new string[1,3];
    public static List<List<string>> table_requests=new List<List<string>>();
    public static int[] tableRequestsHash=new int[100];
    public static int prevCount=0;
    public static List<List<string>> awaitingRequest=new List<List<string>>{
        new List<string>{"Kill 5 green bacteria","In progress","HP +50"},
        new List<string>{"Kill 5 bats","In progress","SP +50"},
        new List<string>{"Complete tutorial","In progress","HP +100"},
        new List<string>{"kill 10 bats","In progress","Oxygen +50"},
        new List<string>{"Kill 10 green bacteria","In progress","Oxygen +100"}};

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
