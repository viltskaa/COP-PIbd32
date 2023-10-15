using EmployeesContracts.BindingModels;
using EmployeesContracts.StorageContracts;
using EmployeesContracts.ViewModels;
using EmployeesDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesDatabaseImplement.Implements
{
    public class PostStorage : IPostStorage
    {
        public void Delete(PostBindingModel model)
        {
            var context = new EmployeesDatabase();
            var post = context.Posts.FirstOrDefault(rec => rec.Id == model.Id);
            if (post != null)
            {
                context.Posts.Remove(post);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Должность не найдена");
            }
        }

        public PostViewModel GetElement(PostBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new EmployeesDatabase();

            var post = context.Posts
                    .ToList()
                    .FirstOrDefault(rec => rec.Id == model.Id || rec.Name == model.Name);
            return post != null ? CreateModel(post) : null;
        }


        public List<PostViewModel> GetFilteredList(PostBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new EmployeesDatabase();
            return context.Posts
                .Where(rec => rec.Name.Contains(model.Name))
                .Select(CreateModel)
                .ToList();
        }

        public List<PostViewModel> GetFullList()
        {
            using var context = new EmployeesDatabase();
            return context.Posts
                .Select(CreateModel)
                .ToList();
        }

        public void Insert(PostBindingModel model)
        {
            var context = new EmployeesDatabase();
            var transaction = context.Database.BeginTransaction();
            try
            {
                context.Posts.Add(CreateModel(model, new Post()));
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(PostBindingModel model)
        {
            var context = new EmployeesDatabase();
            var transaction = context.Database.BeginTransaction();
            try
            {
                var post = context.Posts.FirstOrDefault(rec => rec.Id == model.Id);
                if (post == null)
                {
                    throw new Exception("Должность не найдена");
                }
                CreateModel(model, post);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        private static Post CreateModel(PostBindingModel model, Post post)
        {
            post.Name = model.Name;
            return post;
        }

        private static PostViewModel CreateModel(Post post)
        {
            return new PostViewModel
            {
                Id = post.Id,
                Name = post.Name
            };
        }
    }
}
