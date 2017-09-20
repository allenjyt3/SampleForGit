using AssessmentMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssessmentMvc.Controllers
{
    public class BlogPostController : Controller
    {
        // GET: BlogPost
     

        public ActionResult CreateBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBlog(Blog blog)
        {
            SchoolEntities dbContext = new SchoolEntities();
            dbContext.Blogs.Add(blog);
            dbContext.SaveChanges();
            return RedirectToAction("PostView");
        }


        [HttpGet]
        public ActionResult EditPost(int id)
        {
            SchoolEntities dbContext = new SchoolEntities();
            Post post = dbContext.Posts.Where(p => p.PostId == id).FirstOrDefault();
            return View(post);
        }

        [HttpPost]
        public ActionResult EditPost(Post pos)
        {

            SchoolEntities dbContext = new SchoolEntities();
            Post post = dbContext.Posts.Where(p => p.PostId ==pos.PostId).FirstOrDefault();
            dbContext.Entry(post).CurrentValues.SetValues(pos);
            dbContext.SaveChanges();
            return RedirectToAction("PostView");

        }
        public ActionResult DeletePost(int id)
        {
            SchoolEntities dbContext = new SchoolEntities();
             Post post = dbContext.Posts.Where(p => p.PostId == id).FirstOrDefault();
            dbContext.Posts.Remove(post);
            dbContext.SaveChanges();
            return RedirectToAction("PostView");
        }

        public ActionResult CreatePost()
        {
            SchoolEntities dbContext = new SchoolEntities();
            List<SelectListItem> selectedlist = new List<SelectListItem>();
            foreach (Blog blog in dbContext.Blogs)
            {
                SelectListItem selectlistitem = new SelectListItem
                {
                    Text = blog.BlogName,
                    Value = blog.BlogId.ToString(),
                    // Selected=department.IsSelected.HasValue ? department.IsSelected.Value :false
                };
                selectedlist.Add(selectlistitem);
            }
            ViewBag.blog = selectedlist;
            return View();
        }

   


        [HttpPost]
        //[ActionName("Create")]
        public ActionResult CreatePost(Post po, string blog)
        {
            SchoolEntities dbContext = new SchoolEntities();
            po.BlogId = Convert.ToInt32(blog);
            dbContext.Posts.Add(po);



            dbContext.SaveChanges();
            return RedirectToAction("PostView");
        }

        public ActionResult PostView()
        {
            SchoolEntities dbContext = new SchoolEntities();
            List<Post> postlist = dbContext.Posts.ToList();
            return View(postlist);



        }

    }
}


    
