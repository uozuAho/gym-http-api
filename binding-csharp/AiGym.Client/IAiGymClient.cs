using System.Threading.Tasks;
using AiGym.Client.Model;

namespace AiGym.Client
{
    public interface IAiGymClient
    {
        /// <summary>
        /// Creates an ai gym environment such as CartPole, and returns an id of the created environment
        /// </summary>
        Task<string> CreateEnvironment(string enironmentName);

        /// <summary>
        /// Reset the environment to an initial state, returning the initial observation
        /// </summary>
        Task<ISpace> ResetEnvironment(string environmentId);

        Task<object> GetActionSpaceInfo(string environmentId);
        Task<object> GetObservationSpaceInfo(string environmentId);
    }
}