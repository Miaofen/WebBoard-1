using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBoard.Models;

namespace WebBoard.Models
{
    
    public class DBservices
    {
       
        /*public static create_data(string name, string subject, string memo)
        {
           
        }
        public static update_data(string name, string subject, string memo)
        {

        }
        public static delete_data(string name, string subject, string memo)
        {

        }*/



    }
}
  //讀取並返回messageEntity中的資料 public List<Article> GetData() { return (db.Article.ToList()); } //把從User接受的資料寫入messageEnitity public void DBCreate(string strTitle,string strContent) { //例項化Artile物件 Article newData=new Article(); //給Artile物件的屬性賦值 newData.Title=strTitle; newData.Content=strContent; newData.time=DateTime.Now; //實體新增到Entity中 db.Article.Add(newData); //儲存到資料庫 db.SaveChanges(); } }}