using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DapperExample.Models;

namespace DapperExample.Repositories
{
    public interface ISampleRepositories{
void Create();
Persons GetOne();
List<Persons> GetAll();
void Update();
void Delete();
    }
    public class SampleRepositories:ISampleRepositories
    {
        public void Create(){
string sqlPersonsInsert = "INSERT INTO Persons (Name,Surname) Values (@Name,@Surname);";

using (var connection = new SqlConnection("Data Source=ExampleDapper.sdf"))
{
   
    var SomePersons =new List<Persons>(){
        new Persons(){Name = "Vitaliy", Surname = "Zayarniy"},
        new Persons(){Name = "Jeffry",  Surname = "Richter"},
        new Persons(){Name = "Purum", Surname = "Badum"}
    };
    foreach(var item in SomePersons){
	var identity = connection.Execute(sqlPersonsInsert,new{ Name = item.Name,Surname= item.Surname});
    }
}
        }
        public Persons GetOne(){
            using (var connection = new SqlConnection("Data Source=ExampleDapper.sdf"))
{
   
         string SqlGetPerson = "Select * From Persons Where Name = @Name;";
         var identity = connection.QuerySingleOrDefault<Persons>(SqlGetPerson,new {Name= "Vitaliy"});
         return identity;
}
        }
public List<Persons> GetAll(){
 using (var connection = new SqlConnection("Data Source=ExampleDapper.sdf"))
{
   
         string SqlGetPerson = "Select * From Persons Where Name = @Parameter;";
         //Can get this async, if you write not a Query, you must write QueryAsync:
         //var identity = connection.QueryAsync<Persons>(SqlGetPerson).ToList();
         var identity = connection.Query<Persons>(SqlGetPerson).ToList();
         return identity;
}

}
public void Update(){
    using (var connection = new SqlConnection("Data Source=ExampleDapper.sdf"))
{
   
         string SqlGetPerson = "Update Persons Set  Name = @Name, Surname = @Surname where ID = @Id;";
       
         var identity = connection.Execute(SqlGetPerson,new {Name = "sss",Surname="sdsdsa",ID=1});
         
}
        
    }
    public void Delete(){
    using (var connection = new SqlConnection("Data Source=ExampleDapper.sdf"))
{
   
         string SqlGetPerson = "DELETE FROM Persons WHERE Name=@Name;";
       
         var identity = connection.Execute(SqlGetPerson,new{Name = "Vitaliy"});
         
}
        
    }
}
}