using System.Collections.Generic;

namespace AiGym.Client.Http.Messages
{
    internal class StepResponse
    {
        public List<double> observation { get; set; }
        public double reward { get; set; }
        public bool done { get; set; }
    }
}
