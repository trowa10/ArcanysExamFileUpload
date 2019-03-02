using DragAndDrapMVC.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DragAndDrapMVC.Models;

namespace DragAndDrapMVC
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationContext context = new ApplicationContext();
        private FileRepository<File> _fileRepository;
        public FileRepository<File> Repository
        {
            get
            {
                return this._fileRepository ?? new FileRepository<File>(context);
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}