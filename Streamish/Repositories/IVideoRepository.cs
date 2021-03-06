using System;
using System.Collections.Generic;
using Streamish.Models;

namespace Streamish.Repositories
{
    public interface IVideoRepository
    {
         List<Video> GetAll();
         Video GetById(int id);
         void Add(Video video);
         void Update(Video video);
         void Delete(int id);
         List<Video> GetAllWithComments();
         Video GetVideoByIdWithComments(int id);
         List<Video> Search(string criterion, bool sortDescending);
         List<Video> SearchTitle(string criterion, bool sortDescending);
    }
}
