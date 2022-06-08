using cnpmnc.shared;

namespace cnpmnc.backend.DTOs.AssignmentGradeDTOs
{
    public class AssignmentGradeQueryCriteria : BaseQueryCriteria
    {
        public int[] State { get; set; }
        public DateTime AssignedDate { get; set; }
    }
}
