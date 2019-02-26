using RobotOnTheRun.Domain;
using RobotOnTheRun.Domain.Entities;
using RobotOnTheRun.Shared.Orchestrators.Interfaces;
using RobotOnTheRun.Shared.ViewModels;
using System;
using System.Threading.Tasks;

namespace RobotOnTheRun.Shared.Orchestrators
{
    public class ErrorOrchestrator : IErrorOrchestrator
    {

        private readonly PersonContext _personContext;

        public ErrorOrchestrator()
        {
            _personContext = new PersonContext();
        }

        public async Task<int> CreateErrorLog(ErrorViewModel error)
        {
            _personContext.Errors.Add(new Error
            {
                ErrorDate = DateTime.Now,
                ErrorId = error.ErrorId,
                ErrorMessage = error.ErrorMessage,
                InnerExceptions = error.InnerExceptions,
                StackTrace = error.StackTrace
            });

            return await _personContext.SaveChangesAsync();
        }

        public void ForceError()
        {
            throw new OutOfMemoryException();
        }
    }
}
