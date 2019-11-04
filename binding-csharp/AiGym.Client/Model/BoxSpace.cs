using System.Collections.Generic;

namespace AiGym.Client.Model
{
    public class BoxSpace : ISpace
    {
        public List<double> Values { get; set; }

        public override string ToString()
        {
            var values = string.Join(", ", Values);
            return $"[{values}]";
        }
    }
}
