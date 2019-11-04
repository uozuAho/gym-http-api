using System.Threading.Tasks;

namespace AiGym.Client
{
    public interface IAiGymClient
    {
        Task<string> CreateEnvironment(string enironmentName);
    }
}