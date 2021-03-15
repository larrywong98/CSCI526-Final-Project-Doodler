using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Request : MonoBehaviour
{
    // public static string[,] table_requests=new string[1,3];
    public static int ranVal=0;
    public static List<List<string>> table_requests=new List<List<string>>();
    // public static int[] tableRequestsHash=new int[100];
    // public static int prevCount=0;
    //  awaitingreqeust id, 任务内容, 进度, 状态， //table request id,
    public static List<List<string>> awaitingRequest=new List<List<string>>{
        new List<string>{"0","Kill 5 green bacteria","5","0"},
        new List<string>{"1","kill 5 bats","5","0"},
        new List<string>{"2","Kill 10 green bacteria","10","0"},
        new List<string>{"3","Kill 10 bats","10","0"},
        new List<string>{"4","Kill 20 green bacteria","20","0"}
        };

    public void AddRow(string id,string request,string reward,string status){
        List<string> tmp=new List<string>();
        tmp.Add(id);
        tmp.Add(request);
        tmp.Add(reward);
        tmp.Add(status);
        tmp.Add(""+table_requests.Count);
        // tableRequestsHash[val]=1;
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
