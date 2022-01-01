using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFTechLink.Interface;

namespace EFTechLink.Implementation
{
    public class DataContextAction : IDataContextAction
    {
        public bool Delete(ImportTransaction transaction)
        {
            if (transaction is null)
                throw new ArgumentNullException("ImportTransaction model is null");

            using (var context = new EFSOFTModel())
            {
                context.ImportTransactions.Attach(transaction);
                context.Entry(transaction).State = System.Data.Entity.EntityState.Deleted;
                var result = context.SaveChanges();
                return true;
            };

        }

        public bool Insert(ImportTransaction transaction)
        {
            if (transaction is null)
                throw new ArgumentNullException("ImportTransaction model is null");

            using (var context = new EFSOFTModel())
            {

                try
                {
                    context.ImportTransactions.Add(transaction);
                    var result = context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
                return true;
            };
        }

        public ImportTransaction select(string qRCode, string headerCode, string headerNo, string headerSTT)
        {
            using (var context = new EFSOFTModel())
            {
                var transaction = context.ImportTransactions.Where(d => d.QRCode == qRCode && d.HeaderCode == headerCode 
                                                                && d.HeaderNo == headerNo && d.HeaderSTT == headerSTT)
                                                            .FirstOrDefault();

                return transaction;
            };
        }

        public bool Update(ImportTransaction transaction)
        {
            if (transaction is null)
                throw new ArgumentNullException("ImportTransaction model is null");

            using (var context = new EFSOFTModel())
            {
                context.ImportTransactions.Attach(transaction);
                context.Entry(transaction).State = System.Data.Entity.EntityState.Modified;
                var result = context.SaveChanges();
                return true;
            };
        }
    }
}
