using cnpmnc.shared;

namespace cnpmnc.backend.DTOs.AssignmentDTOs
{
    public class AssignmentQueryCriteria : BaseQueryCriteria
    {
        public int[] State { get; set; }
        public DateTime AssignedDate { get; set; }
    }
}
