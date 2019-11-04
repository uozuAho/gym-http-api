using System.Threading.Tasks;

namespace AiGym.Client
{
    public interface IAiGymClient
    {
        /// <summary>
        /// Creates an ai gym environment such as CartPole, and returns an id of the created environment
        /// </summary>
        Task<string> CreateEnvironment(string enironmentName);
    }
}