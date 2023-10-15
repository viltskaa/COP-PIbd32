using EnterpriseContracts.BindingModels;
using EnterpriseContracts.StorageContracts;
using EnterpriseContracts.ViewModels;
using EnterpriseDataBaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseDataBaseImplement.Implements
{
    public class SkillStorage : ISkillStorage
    {
        public bool Delete(SkillBindingModel model)
        {
            var context = new EnterpriseDataBase();
            var skill = context.Skills.FirstOrDefault(rec => rec.Id == model.Id);
            if (skill != null)
            {
                context.Skills.Remove(skill);
                context.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("Навык не найден");
                return false;
            }
        }

        public SkillViewModel GetElement(SkillBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new EnterpriseDataBase();

            var skill = context.Skills
                    .ToList()
                    .FirstOrDefault(rec => rec.Id == model.Id || rec.Name == model.Name);
            return skill != null ? CreateModel(skill) : null;
        }

        public List<SkillViewModel> GetFilteredList(SkillBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new EnterpriseDataBase();
            return context.Skills
                .Where(rec => rec.Name.Contains(model.Name))
                .Select(CreateModel)
                .ToList();
        }

        public List<SkillViewModel> GetFullList()
        {
            using var context = new EnterpriseDataBase();
            return context.Skills
                .Select(CreateModel)
                .ToList();
        }

        public void Insert(SkillBindingModel model)
        {
            var context = new EnterpriseDataBase();
            var transaction = context.Database.BeginTransaction();
            try
            {
                context.Skills.Add(CreateModel(model, new Skill()));
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(SkillBindingModel model)
        {
            var context = new EnterpriseDataBase();
            var transaction = context.Database.BeginTransaction();
            try
            {
                var skill = context.Skills.FirstOrDefault(rec => rec.Id == model.Id);
                if (skill == null)
                {
                    throw new Exception("Навык не найден");
                }
                CreateModel(model, skill);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        private static Skill CreateModel(SkillBindingModel model, Skill skill)
        {
            skill.Name = model.Name;
            return skill;
        }

        private static SkillViewModel CreateModel(Skill skill)
        {
            return new SkillViewModel
            {
                Id = skill.Id,
                Name = skill.Name
            };
        }
    }
}
