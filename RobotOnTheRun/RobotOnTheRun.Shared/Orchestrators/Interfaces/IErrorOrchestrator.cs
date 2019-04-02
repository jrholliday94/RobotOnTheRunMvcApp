using RobotOnTheRun.Shared.ViewModels;
using System.Threading.Tasks;

namespace RobotOnTheRun.Shared.Orchestrators.Interfaces
{
    public interface IErrorOrchestrator
    {
        Task<int> CreateErrorLog(ErrorViewModel error);
        void ForceError();
    }
}
