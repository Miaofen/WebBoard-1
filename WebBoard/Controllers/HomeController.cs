using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebBoard.Models;
using WebBoard;

namespace WebBoard.Controllers
{
    public class HomeController : Controller
    {


        private readonly ILogger<HomeController> _logger;
        private readonly WebBoardContext _WebBoard;


        public HomeController(ILogger<HomeController> logger, WebBoardContext webBoard)
        {
            _logger = logger;
            _WebBoard = webBoard;
        }

        public WebBoardContext db = new WebBoardContext();

        public IActionResult Index()//檢視頁面
        {
            var List = _WebBoard.BoardTitle.ToList();

            return View(List);
        }
        /// <summary>
        /// 顯示新增的頁面
        /// </summary>
        /// <returns></returns>
        public IActionResult BoardCreate()
        {
          
            return View();
        }
        /// <summary>
        /// 新增資料，資料不能為空白
        /// </summary>
        /// <param name="db">Entity屬性資料包裝成db當作參數</param>
        /// <returns>Index</returns>
        
        [HttpPost]
        public IActionResult BoardPost(BoardTitle db)
        {
            if (string.IsNullOrEmpty(Convert.ToString(db.Id)))
            {
                return Content("Not found Id");
            }
            if (string.IsNullOrEmpty(Convert.ToString(db.Name)))
            {
                return Content("Not found Name");
            }
            if (string.IsNullOrEmpty(Convert.ToString(db.Subject)))
            {
                return Content("Not found Subject");
            }
            if (string.IsNullOrEmpty(Convert.ToString(db.Memo)))
            {
                return Content("Not found Memo");
            }
            _WebBoard.Add(db);
            _WebBoard.SaveChanges();

            return RedirectToAction("Index");
        }
        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="id">以Id為索引值刪除單筆資料<param>
        /// <returns>Index</returns>
        public IActionResult Delete(int id) 
        {
            BoardTitle temp = _WebBoard.BoardTitle.Single(e => e.Id == id);
            _WebBoard.Remove(temp);
            _WebBoard.SaveChanges();
            return RedirectToAction("Index");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">J</param>
        /// <param name="name"></param>
        /// <param name="subject"></param>
        /// <param name="memo"></param>
        /// <returns></returns>
        public IActionResult Edit(BoardTitle db)
        {
            return View();
        }
        [HttpPost]
        public IActionResult EditPost(int id, string name, string subject, string memo)
        {
            BoardTitle change = _WebBoard.BoardTitle.Single(x => x.Id == id);
            change.Id = id;
            change.Name = name;
            change.Subject = subject;
            change.Memo = memo;
            _WebBoard.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            BoardTitle data = _WebBoard.BoardTitle.Single(m => m.Id == id);
            return View(data);
        }
        


    }
}