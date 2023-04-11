using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_CORE.Model;
using MVC_CORE.Models;


namespace MVC_CORE.Controllers
{
 
    public class MyController : Controller
    {
        private readonly MYDbContext context;

        public MyController(MYDbContext context)
        {
            this.context = context;
        }
        static string x;
        static int y;
        static int data_id;
       
        public IActionResult Profile()
        {
            return View();
        }


        public IActionResult Course(string data)
        {
            //display all courses
            if (data != null)
            {
                x = data;
            }
            return View(context.courses.ToList());
        }
        public IActionResult allVideos(int id)
        {
            y = id;
            //display all videos in a course clicked on
              var result = context.videos.OrderBy(x => x.Num).Where(x => x.CourseId == id).ToList();
              return View(result);
        }

        public IActionResult re_sort()
        {
            
            //display all videos in a course clicked on
            var result = context.videos.OrderByDescending(x => x.Rate).ToList();
            return View(result);
        }
        public IActionResult Video(int Id)
        {
            data_id = Id;
              //display video clicked on
              var v= context.videos.Where(x=>x.Id==Id).ToList();
            //display comments on this video
            ViewBag.k = context.comments.Where(x => x.VideoId == Id).ToList();
            return View(v);
        }
       
        public async Task<IActionResult> AddCommentAsync(string comment,int id)
        {
           
           if(x != null) {
            var input = new ModelInput();
            input.Col0 = comment;
            var predictionResult = ConsumeModel.Predict(input);

            if (Convert.ToInt16(predictionResult.Prediction) == 1)
            {
                var v = await context.videos.FindAsync(data_id);
                if (id <= 0)
                {
                    return NotFound();
                }
                else {

                if (v == null)
                {
                   // return NotFound();
                }


                else
                {
                      
                   v.Rate= v.Rate+1;
                    context.Update(v);
                    await context.SaveChangesAsync();

                    try
                    {
                       
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        
                    }



                }
                }
            }
            else
            {



            }

            context.comments.Add(new Comments()
            {
                VideoId=id,
                useremail= x,
                Contents = comment
            });
            context.SaveChanges();
            return Redirect("~/My/Video?id="+(id).ToString());
            }
            else
            {

                return Redirect("~/My/Video?id=" + (id).ToString());

            }
        }





  
    }
      
}
