namespace StringCheck.Models
{
    // Request model to hold both lists C(A) and C(S)
    public class DuplicateCheckRequest<T> where T : IEquatable<T>
    {
        public List<T> CA { get; set; } // Collection A
        public List<T> CS { get; set; } // Collection S
    }

   
}
